// ============================================================================
// CATUR ONLINE - Multiplayer Chess via Network
// Based on catur.cs with networking support
// ============================================================================

tulis("🌐 Initializing Online Chess...")

// Import all functions from catur.cs by including logic here
// Konfigurasi
var ukuran_kotak = 60
var margin = 20
var warna_terang = "#F0D9B5"
var warna_gelap = "#B58863"

// Game state
var papan = []
var giliran_putih = benar
var terpilih = kosong
var langkah_legal = []
var game_selesai = salah

// Online mode variables
var mode_online = "" // "host" atau "join"
var koneksi = kosong
var warna_saya = "" // "putih" atau "hitam"
var server_id = kosong

// GUI IDs
var id_jendela = 0
var id_canvas = 0
var id_label_status = 0
var id_input = 0
var id_label_ip = 0

tulis("✓ Loaded base configuration")

// Note: Due to file size, this is a STREAMLINED version
// Core chess logic (init, draw, move, etc.) would be here
// For now, showing networking integration points

fungsi init_papan() {
    papan = []
    tambah(papan, ["r", "n", "b", "q", "k", "b", "n", "r"])
    tambah(papan, ["p", "p", "p", "p", "p", "p", "p", "p"])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, ["P", "P", "P", "P", "P", "P", "P", "P"])
    tambah(papan, ["R", "N", "B", "Q", "K", "B", "N", "R"])
}

// Minimal chess functions for demo
fungsi adalah_huruf_besar(c) {
    var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    kembalikan indeks(upper, c) >= 0
}

fungsi bidak_ke_simbol(bidak) {
    // Convert piece letters to Unicode chess symbols
    jika (bidak == "K") { kembalikan "♔" }
    jika (bidak == "Q") { kembalikan "♕" }
    jika (bidak == "R") { kembalikan "♖" }
    jika (bidak == "B") { kembalikan "♗" }
    jika (bidak == "N") { kembalikan "♘" }
    jika (bidak == "P") { kembalikan "♙" }
    jika (bidak == "k") { kembalikan "♚" }
    jika (bidak == "q") { kembalikan "♛" }
    jika (bidak == "r") { kembalikan "♜" }
    jika (bidak == "b") { kembalikan "♝" }
    jika (bidak == "n") { kembalikan "♞" }
    jika (bidak == "p") { kembalikan "♟" }
    kembalikan bidak
}

// ============================================================================
// ONLINE NETWORKING FUNCTIONS
// ============================================================================

fungsi kirim_langkah(dari_b, dari_k, ke_b, ke_k) {
    jika (koneksi == kosong) { kembalikan salah }
    
    // Create JSON message
    var msg = "{"
    msg = msg + "\"type\":\"move\","
    msg = msg + "\"dari_b\":" + ke_teks(dari_b) + ","
    msg = msg + "\"dari_k\":" + ke_teks(dari_k) + ","
    msg = msg + "\"ke_b\":" + ke_teks(ke_b) + ","
    msg = msg + "\"ke_k\":" + ke_teks(ke_k)
    msg = msg + "}"
    
    tulis("📤 Sending: " + msg)
    kembalikan kirim(koneksi, msg)
}

fungsi terima_langkah() {
    jika (koneksi == kosong) { kembalikan kosong }
    
    var data = terima(koneksi, 100)
    jika (data == kosong) { kembalikan kosong }
    
    tulis("📥 Received: " + data)
    
    // Parse JSON (simple manual parsing)
    var move = decode_json(data)
    kembalikan move
}

fungsi cek_pesan_lawan() {
    jika (koneksi == kosong) { kembalikan 0 }
    
    jika (ada_data(koneksi)) {
        var move = terima_langkah()
        jika (move != kosong) {
            // Parse move data
            tulis("🎮 Opponent moved!")
            
            // Get move coordinates from JSON
            var dari_b = move["dari_b"]
            var dari_k = move["dari_k"]
            var ke_b = move["ke_b"]
            var ke_k = move["ke_k"]
            
            // Apply move to board
            var bidak = papan[dari_b][dari_k]
            ubah(papan[ke_b], ke_k, bidak)
            ubah(papan[dari_b], dari_k, ".")
            
            // Switch turn
            giliran_putih = tidak giliran_putih
            
            // Redraw board
            gambar_papan_simple()
            
            // Update status
            var status_text = "Your turn!"
            jika ((warna_saya == "putih") dan (tidak giliran_putih)) {
                status_text = "Opponent's turn"
            }
            jika ((warna_saya == "hitam") dan giliran_putih) {
                status_text = "Opponent's turn"
            }
            ubah_teks_label(id_label_status, status_text)
        }
    }
}

// ============================================================================
// MENU & CONNECTION
// ============================================================================

fungsi tampilkan_menu_online() {
    buat_jendela("Online Chess - Menu", 400, 300)
    atur_warna_latar("#2c3e50")
    
    buat_label("CASTLE SCRIPT CHESS", 100, 20, 18, "white", "#2c3e50")
    buat_label("Online Multiplayer", 135, 50, 12, "#95a5a6", "#2c3e50")
    
    buat_tombol("HOST GAME", mulai_host, 100, 100, 200, 50, "#27ae60", "white", 14)
    buat_tombol("JOIN GAME", mulai_join, 100, 160, 200, 50, "#3498db", "white", 14)
    buat_tombol("BACK", kembali_menu, 100, 220, 200, 40, "#95a5a6", "white", 12)
    
    tulis("📋 Menu displayed")
    jalankan()
}

fungsi mulai_host() {
    tulis("🏠 Starting HOST mode...")
    mode_online = "host"
    warna_saya = "putih"
    
    // Create server
    server_id = buat_server(5555)
    
    jika (server_id == kosong) {
        tampilkan_pesan("Error", "Failed to create server!")
        kembalikan 0
    }
    
    tutup_jendela(id_jendela)
    
    // Show waiting screen
    buat_jendela("Waiting for Player", 400, 250)
    atur_warna_latar("#2c3e50")
    
    buat_label("Hosting Game...", 120, 50, 16, "white", "#2c3e50")
    buat_label("Share your IP with your friend:", 80, 90, 11, "#95a5a6", "#2c3e50")
    buat_label("Port: 5555", 150, 115, 12, "#f39c12", "#2c3e50")
    buat_label("(Run 'ipconfig' in CMD to find IP)", 80, 140, 9, "#7f8c8d", "#2c3e50")
    id_label_ip = buat_label("Waiting for connection...", 95, 170, 12, "#3498db", "#2c3e50")
    
    tulis("🌐 Server created, waiting...")
    tulis("💡 Share your IP address with opponent")
    
    // Start checking for connections BEFORE running GUI loop
    atur_waktu(1000, cek_koneksi_host)
    
    jalankan()
}

fungsi cek_koneksi_host() {
    tulis("⏳ Checking for connection...")
    koneksi = tunggu_koneksi(server_id, 1000)
    
    jika (koneksi != kosong) {
        tulis("✅ Player connected!")
        tampilkan_pesan("Connected!", "Opponent joined. Starting game...")
        atur_waktu(2000, mulai_game)
    } jika_tidak {
        // Try again
        atur_waktu(1000, cek_koneksi_host)
    }
}

fungsi mulai_join() {
    tulis("🔌 Starting JOIN mode...")
    mode_online = "join"
    warna_saya = "hitam"
    
    tutup_jendela(id_jendela)
    
    // Show connection screen
    buat_jendela("Connect to Game", 400, 250)
    atur_warna_latar("#2c3e50")
    
    buat_label("Join Online Game", 120, 30, 16, "white", "#2c3e50")
    buat_label("Enter host IP address:", 100, 80, 12, "#95a5a6", "#2c3e50")
    
    id_input = buat_input(100, 110, 14, 16)
    atur_nilai_input(id_input, "127.0.0.1")
    
    fungsi sambung_sekarang() {
        var ip = ambil_nilai_input(id_input)
        tulis("🌐 Connecting to " + ip + ":5555...")
        
        koneksi = sambung_ke(ip, 5555, 5000)
        
        jika (koneksi != kosong) {
            tulis("✅ Connected!")
            tampilkan_pesan("Success!", "Connected to opponent!")
            atur_waktu(2000, mulai_game)
        } jika_tidak {
            tulis("❌ Connection failed")
            tampilkan_pesan("Error", "Could not connect to " + ip)
        }
    }
    
    buat_tombol("CONNECT", sambung_sekarang, 125, 160, 150, 45, "#27ae60", "white", 14)
    
    jalankan()
}

fungsi kembali_menu() {
    tulis("🔙 Back to menu")
    tutup_jendela(id_jendela)
    // TODO: Return to main menu
}

fungsi mulai_game() {
    tulis("🎮 Starting online chess game!")
    tulis("   Your color: " + warna_saya)
    
    init_papan()
    tutup_jendela(id_jendela)
    
    // Create chess board UI
    id_jendela = buat_jendela("Online Chess", 520, 600)
    atur_warna_latar("#34495e")
    
    buat_label("ONLINE CHESS", margin, 10, 14, "#ecf0f1", "#34495e")
    
    var info_text = "You: " + warna_saya
    buat_label(info_text, margin, 35, 10, "#95a5a6", "#34495e")
    id_label_status = buat_label("Game Started!", margin, 560, 12, "#f39c12", "#34495e")
    
    id_canvas = buat_kanvas(margin, 70, 480, 480)
    
    // Simplified board drawing
    gambar_papan_simple()
    
    // Bind click (simplified)
    bind_klik(id_canvas, klik_papan_online)
    
    // Start network check timer
    atur_waktu(500, loop_online)
    
    jalankan()
}

fungsi gambar_papan_simple() {
    bersihkan_kanvas(id_canvas)
    
    // Draw checkerboard
    var b = 0
    ulangi (b = 0; b < 8; b = b + 1) {
        var k = 0
        ulangi (k = 0; k < 8; k = k + 1) {
            var x = k * 60
            var y = b * 60
            
            var warna = warna_terang
            jika ((b + k) % 2 == 1) {
                warna = warna_gelap
            }
            
            gambar_persegi(id_canvas, x, y, x + 60, y + 60, warna)
            
            // Draw piece symbol
            var bidak = papan[b][k]
            jika (bidak != ".") {
                var simbol = bidak_ke_simbol(bidak)
                gambar_teks(id_canvas, x + 25, y + 35, simbol, "black", 32)
            }
        }
    }
}

fungsi klik_papan_online(x, y) {
    jika (game_selesai) { kembalikan 0 }
    
    // Check if it's my turn
    var giliran_saya = salah
    jika ((warna_saya == "putih") dan giliran_putih) { giliran_saya = benar }
    jika ((warna_saya == "hitam") dan (tidak giliran_putih)) { giliran_saya = benar }
    
    jika (tidak giliran_saya) {
        ubah_teks_label(id_label_status, "Wait for opponent...")
        kembalikan 0
    }
    
    // Convert click to board position
    var k = lantai(x / 60)
    var b = lantai(y / 60)
    
    jika (b < 0 atau b > 7 atau k < 0 atau k > 7) { kembalikan 0 }
    
    tulis("Click: " + ke_teks(b) + "," + ke_teks(k))
    
    // Simplified move logic - just demo
    jika (terpilih == kosong) {
        var bidak = papan[b][k]
        jika (bidak != ".") {
            var pos = []
            tambah(pos, b)
            tambah(pos, k)
            terpilih = pos
            tulis("Selected piece at " + ke_teks(b) + "," + ke_teks(k))
        }
    } jika_tidak {
        // Execute move
        var dari_b = terpilih[0]
        var dari_k = terpilih[1]
        
        // Apply move locally
        var bidak = papan[dari_b][dari_k]
        ubah(papan[b], k, bidak)
        ubah(papan[dari_b], dari_k, ".")
        
        // Send to opponent
        kirim_langkah(dari_b, dari_k, b, k)
        
        giliran_putih = tidak giliran_putih
        terpilih = kosong
        
        gambar_papan_simple()
        ubah_teks_label(id_label_status, "Opponent's turn")
    }
}

fungsi loop_online() {
    // Check for opponent moves
    cek_pesan_lawan()
    
    // Continue checking
    jika (tidak game_selesai) {
        atur_waktu(500, loop_online)
    }
}

// ============================================================================
// MAIN ENTRY POINT
// ============================================================================

tulis("✓ All functions loaded")
tulis("🚀 Starting Online Chess Menu...")
tulis("")

tampilkan_menu_online()
