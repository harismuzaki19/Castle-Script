# Chess Relay Server

WebSocket-based relay server for online chess multiplayer.

## Features

- ✅ Room-based matchmaking
- ✅ 6-character room codes
- ✅ Automatic move relay
- ✅ Color negotiation
- ✅ Auto-cleanup expired rooms
- ✅ Free cloud hosting

## Deployment

### Option 1: Render.com (Recommended)

1. Create account at [render.com](https://render.com)
2. Click "New +" → "Web Service"
3. Connect this GitHub repo
4. Render auto-detects `render.yaml`
5. Click "Create Web Service"
6. Wait ~2 minutes for deployment
7. Get URL: `https://chess-relay.onrender.com`

### Option 2: Railway.app

1. Create account at [railway.app](https://railway.app)
2. "New Project" → "Deploy from GitHub repo"
3. Select this repo
4. Railway auto-detects `Procfile`
5. Deploy automatically
6. Get URL from settings
7. Set custom domain (optional)

### Option 3: Local Testing

```bash
cd server
pip install -r requirements.txt
python relay_server.py
```

Server runs on `http://localhost:8080`

## API

### WebSocket Messages

**Client → Server:**

Create room:

```json
{
  "type": "create_room",
  "color": "white"
}
```

Join room:

```json
{
  "type": "join_room",
  "room_code": "ABC123"
}
```

Send move:

```json
{
  "type": "move",
  "room_code": "ABC123",
  "from": { "row": 1, "col": 4 },
  "to": { "row": 3, "col": 4 }
}
```

**Server → Client:**

Room created:

```json
{
  "type": "room_created",
  "room_code": "ABC123",
  "your_color": "white",
  "opponent_color": "black"
}
```

Opponent joined:

```json
{
  "type": "opponent_joined",
  "opponent_color": "black"
}
```

Opponent move:

```json
{
  "type": "opponent_move",
  "from": { "row": 6, "col": 4 },
  "to": { "row": 4, "col": 4 }
}
```

## Configuration

Environment variables:

- `PORT` - Server port (default: 8080)

## Monitoring

Check logs in Render/Railway dashboard to monitor:

- Room creation/joins
- Move relay activity
- Disconnections
- Expired room cleanup

## Free Tier Limits

**Render.com:**

- ✅ 750 hours/month free
- ✅ Auto-sleep after 15min inactivity
- ✅ Free SSL

**Railway.app:**

- ✅ 500 hours/month free
- ✅ $5 credit/month
- ✅ Fast deployments

Both are sufficient for hobby/testing use!

## Support

For issues, check logs in deployment dashboard.
