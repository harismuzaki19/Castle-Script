# 🎨 GUI CastleScript

**CastleScript sekarang mendukung GUI NATIVE!** Buat aplikasi dengan jendela, tombol, dan interface grafis menggunakan bahasa Indonesia.

## 🚀 Fitur GUI

CastleScript telah diperluas dengan library GUI menggunakan Tkinter dengan sintaks bahasa Indonesia:

### Fungsi Jendela

- `buat_jendela(judul, lebar, tinggi)` - Membuat jendela baru
- `tutup_jendela(id)` - Menutup jendela
- `jalankan()` - Menjalankan event loop GUI
- `atur_warna_latar(warna)` - Mengatur warna background

### Fungsi Label

- `buat_label(teks, x, y)` - Membuat label teks
- `ubah_teks_label(id, teks)` - Mengubah teks label

### Fungsi Tombol

- `buat_tombol(teks, fungsi, x, y, lebar)` - Membuat tombol dengan callback

### Fungsi Input

- `buat_input(x, y, lebar)` - Membuat input field
- `ambil_nilai_input(id)` - Mengambil nilai input
- `atur_nilai_input(id, nilai)` - Mengatur nilai input

### Fungsi Pesan

- `tampilkan_pesan(judul, pesan)` - Message box info
- `tampilkan_error(judul, pesan)` - Message box error
- `tampilkan_konfirmasi(judul, pesan)` - Konfirmasi Ya/Tidak

### Fungsi Canvas (Menggambar)

- `buat_kanvas(x, y, lebar, tinggi)` - Membuat canvas
- `gambar_persegi(id, x1, y1, x2, y2, warna)` - Gambar persegi
- `gambar_lingkaran(id, x1, y1, x2, y2, warna)` - Gambar lingkaran
- `gambar_garis(id, x1, y1, x2, y2, warna, tebal)` - Gambar garis

## 📝 Contoh Penggunaan

### Hello World GUI

```castlescript
// Buat jendela
buat_jendela("Hello World", 400, 200)

// Tambah label
buat_label("Halo dari CastleScript!", 80, 30)

// Fungsi untuk tombol
fungsi klik_tombol() {
    tampilkan_pesan("Info", "Tombol diklik!")
}

// Tambah tombol
buat_tombol("Klik Saya!", klik_tombol, 150, 80, 12)

// Jalankan
jalankan()
```

**Jalankan:**

```cmd
python castlescript.py examples\hello_gui.cs
```

### Kalkulator GUI

File `kalkulator_gui.cs` adalah kalkulator lengkap dengan GUI yang dibuat **100% dengan CastleScript**!

**Jalankan:**

```cmd
python castlescript.py calkulator\kalkulator_gui.cs
```

**Fitur:**

- ✅ Tombol angka 0-9
- ✅ Operasi +, -, \*, /
- ✅ Tombol Clear (C)
- ✅ Tombol Hapus (⌫)
- ✅ Tombol Desimal (.)
- ✅ Display hasil
- ✅ Error handling

## 🔧 Cara Menggunakan

1. **Buat jendela:**

   ```castlescript
   var window = buat_jendela("Judul App", 500, 400)
   ```

2. **Tambah widget:**

   ```castlescript
   var label = buat_label("Hello!", 10, 10)
   var input = buat_input(10, 50, 20)
   ```

3. **Buat fungsi callback:**

   ```castlescript
   fungsi tombol_diklik() {
       var nilai = ambil_nilai_input(input)
       tampilkan_pesan("Info", "Nilai: " + nilai)
   }
   ```

4. **Tambah tombol:**

   ```castlescript
   var tombol = buat_tombol("Submit", tombol_diklik, 10, 90, 10)
   ```

5. **Jalankan aplikasi:**
   ```castlescript
   jalankan()
   ```

## 🎯 Contoh Program

### Input Form Sederhana

```castlescript
buat_jendela("Form Input", 400, 300)

buat_label("Nama:", 20, 20)
var input_nama = buat_input(20, 50, 30)

buat_label("Umur:", 20, 90)
var input_umur = buat_input(20, 120, 30)

fungsi submit() {
    var nama = ambil_nilai_input(input_nama)
    var umur = ambil_nilai_input(input_umur)

    jika (nama == "") {
        tampilkan_error("Error", "Nama tidak boleh kosong!")
    } jika_tidak {
        tampilkan_pesan("Data", "Nama: " + nama + "\nUmur: " + umur)
    }
}

buat_tombol("Submit", submit, 20, 170, 15)

jalankan()
```

### Aplikasi Menggambar

```castlescript
buat_jendela("Aplikasi Gambar", 500, 500)

var kanvas = buat_kanvas(10, 10, 480, 480)

// Gambar bentuk-bentuk
gambar_persegi(kanvas, 50, 50, 150, 150, "red")
gambar_lingkaran(kanvas, 200, 50, 300, 150, "blue")
gambar_garis(kanvas, 50, 200, 300, 300, "green", 3)

jalankan()
```

## 📁 File Penting

- `castlescript_gui.py` - Library GUI extension
- `castlescript.py` - Interpreter (sudah include GUI)
- `examples/hello_gui.cs` - Contoh Hello World
- `calkulator/kalkulator_gui.cs` - Kalkulator GUI lengkap

## 💡 Tips

1. **Callback Functions:** Setiap tombol membutuhkan fungsi callback
2. **Koordinat:** Gunakan koordinat x,y untuk positioning manual
3. **Window ID:** Simpan ID window jika perlu close manual
4. **Warna:** Gunakan nama warna seperti "red", "blue", "#ff0000"

## 🎨 Warna yang Tersedia

Gunakan nama warna atau kode hex:

- Nama: `"red"`, `"blue"`, `"green"`, `"yellow"`, `"purple"`, dll
- Hex: `"#ff0000"`, `"#00ff00"`, `"#0000ff"`, dll
- RGB tidak didukung (gunakan hex)

## 🐛 Troubleshooting

**Error: Tkinter tidak tersedia**

- Pastikan Python Anda ter-install dengan Tkinter
- Windows: Tkinter biasanya sudah include
- Linux: `sudo apt-get install python3-tk`
- macOS: Tkinter sudah include

**GUI tidak muncul**

- Pastikan memanggil `jalankan()` di akhir program
- Pastikan `buat_jendela()` dipanggil pertama kali

**Tombol tidak bekerja**

- Pastikan fungsi callback sudah didefinisikan sebelum `buat_tombol()`
- Pastikan nama fungsi benar (case-sensitive)

## 🎓 Tutorial Lengkap

Lihat contoh lengkap di:

- `examples/hello_gui.cs` - Basic GUI
- `calkulator/kalkulator_gui.cs` - Aplikasi kompleks

## 🌟 Keunggulan

✅ **Full Bahasa Indonesia** - Semua fungsi dalam bahasa Indonesia
✅ **Native GUI** - Tidak perlu browser, langsung desktop app
✅ **Cross-platform** - Windows, Linux, macOS
✅ **Mudah Dipelajari** - Sintaks sederhana
✅ **Tkinter-based** - Stabil dan matang

---

**Selamat membuat aplikasi GUI dengan CastleScript! 🏰**
