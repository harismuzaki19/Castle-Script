// ============================================================================
// CONTOH GUI SEDERHANA - CASTLESCRIPT
// Hello World dengan GUI
// ============================================================================

tulis("Membuat aplikasi GUI Hello World...")

// Buat jendela
buat_jendela("Hello World CastleScript", 400, 200)

// Tambah label judul
buat_label("Selamat Datang di CastleScript!", 80, 30)

// Fungsi untuk tombol
fungsi sapa_pengguna() {
    tampilkan_pesan("Salam", "Halo dari CastleScript! 🏰")
}

// Tambah tombol
buat_tombol("Klik Saya!", sapa_pengguna, 150, 80, 12)

// Label info
buat_label("Program GUI dengan bahasa Indonesia", 70, 130)

// Jalankan
jalankan()
