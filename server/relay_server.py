"""
Chess Relay Server
WebSocket-based relay server for online chess multiplayer.
Supports room-based matchmaking and move relay.
Deploy to Render.com or Railway.app for free hosting.
"""

import asyncio
import websockets
import json
import random
import string
import logging
from datetime import datetime, timedelta
from typing import Dict, Set, Optional

# Configure logging
logging.basicConfig(
    level=logging.INFO,
    format='%(asctime)s - %(levelname)s - %(message)s'
)
logger = logging.getLogger(__name__)

# Game rooms storage
rooms: Dict[str, 'GameRoom'] = {}

class GameRoom:
    """Represents a chess game room"""
    
    def __init__(self, room_code: str, host_color: str):
        self.room_code = room_code
        self.host_color = host_color
        self.host_ws: Optional[websockets.WebSocketServerProtocol] = None
        self.join_ws: Optional[websockets.WebSocketServerProtocol] = None
        self.created_at = datetime.now()
        self.last_activity = datetime.now()
        
    @property
    def is_full(self) -> bool:
        return self.host_ws is not None and self.join_ws is not None
    
    @property
    def is_expired(self) -> bool:
        # Expire after 2 hours of inactivity
        return datetime.now() - self.last_activity > timedelta(hours=2)
    
    def update_activity(self):
        self.last_activity = datetime.now()
    
    def get_opponent(self, websocket) -> Optional[websockets.WebSocketServerProtocol]:
        """Get opponent's websocket"""
        if websocket == self.host_ws:
            return self.join_ws
        elif websocket == self.join_ws:
            return self.host_ws
        return None

def generate_room_code() -> str:
    """Generate a unique 6-character room code"""
    while True:
        code = ''.join(random.choices(string.ascii_uppercase + string.digits, k=6))
        if code not in rooms:
            return code

async def handle_create_room(websocket, data: dict) -> dict:
    """Handle room creation request"""
    host_color = data.get('color', 'white')
    room_code = generate_room_code()
    
    room = GameRoom(room_code, host_color)
    room.host_ws = websocket
    rooms[room_code] = room
    
    logger.info(f"Room created: {room_code} (host color: {host_color})")
    
    return {
        'type': 'room_created',
        'room_code': room_code,
        'your_color': host_color,
        'opponent_color': 'black' if host_color == 'white' else 'white'
    }

async def handle_join_room(websocket, data: dict) -> dict:
    """Handle room join request"""
    room_code = data.get('room_code', '').upper()
    
    if room_code not in rooms:
        return {
            'type': 'error',
            'message': 'Room not found'
        }
    
    room = rooms[room_code]
    
    if room.is_full:
        return {
            'type': 'error',
            'message': 'Room is full'
        }
    
    room.join_ws = websocket
    room.update_activity()
    
    join_color = 'black' if room.host_color == 'white' else 'white'
    
    logger.info(f"Player joined room: {room_code}")
    
    # Notify host that opponent joined
    if room.host_ws:
        await room.host_ws.send(json.dumps({
            'type': 'opponent_joined',
            'opponent_color': join_color
        }))
    
    return {
        'type': 'joined_room',
        'room_code': room_code,
        'your_color': join_color,
        'opponent_color': room.host_color
    }

async def handle_move(websocket, data: dict, room_code: str):
    """Handle move relay"""
    if room_code not in rooms:
        return
    
    room = rooms[room_code]
    room.update_activity()
    
    opponent = room.get_opponent(websocket)
    if opponent:
        # Relay move to opponent
        move_data = {
            'type': 'opponent_move',
            'from': data.get('from'),
            'to': data.get('to'),
            'promotion': data.get('promotion')
        }
        await opponent.send(json.dumps(move_data))
        logger.info(f"Move relayed in room {room_code}")

async def handle_message(websocket, message: str):
    """Handle incoming WebSocket message"""
    try:
        data = json.loads(message)
        msg_type = data.get('type')
        
        if msg_type == 'create_room':
            response = await handle_create_room(websocket, data)
            await websocket.send(json.dumps(response))
            
        elif msg_type == 'join_room':
            response = await handle_join_room(websocket, data)
            await websocket.send(json.dumps(response))
            
        elif msg_type == 'move':
            room_code = data.get('room_code')
            await handle_move(websocket, data, room_code)
            
        elif msg_type == 'ping':
            await websocket.send(json.dumps({'type': 'pong'}))
            
    except json.JSONDecodeError:
        logger.error(f"Invalid JSON received: {message}")
    except Exception as e:
        logger.error(f"Error handling message: {e}")

async def handle_disconnect(websocket):
    """Handle client disconnect"""
    # Find and cleanup rooms with this websocket
    for room_code, room in list(rooms.items()):
        if websocket in (room.host_ws, room.join_ws):
            # Notify opponent about disconnect
            opponent = room.get_opponent(websocket)
            if opponent:
                try:
                    await opponent.send(json.dumps({
                        'type': 'opponent_disconnected'
                    }))
                except:
                    pass
            
            # Remove room
            del rooms[room_code]
            logger.info(f"Room {room_code} closed due to disconnect")
            break

async def cleanup_expired_rooms():
    """Periodically cleanup expired rooms"""
    while True:
        await asyncio.sleep(300)  # Check every 5 minutes
        
        expired = [code for code, room in rooms.items() if room.is_expired]
        for code in expired:
            del rooms[code]
            logger.info(f"Room {code} expired")

async def handler(websocket, path):
    """Main WebSocket handler"""
    try:
        logger.info(f"Client connected from {websocket.remote_address}")
        
        async for message in websocket:
            await handle_message(websocket, message)
            
    except websockets.exceptions.ConnectionClosed:
        logger.info("Client disconnected")
    finally:
        await handle_disconnect(websocket)

async def main():
    """Start the relay server"""
    # Get port from environment or use default
    import os
    port = int(os.environ.get('PORT', 8080))
    
    # Start cleanup task
    asyncio.create_task(cleanup_expired_rooms())
    
    logger.info(f"Starting Chess Relay Server on port {port}")
    
    async with websockets.serve(handler, "0.0.0.0", port):
        await asyncio.Future()  # Run forever

if __name__ == "__main__":
    asyncio.run(main())
