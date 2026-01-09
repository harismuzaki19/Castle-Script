# Kebijakan Keamanan

## Versi yang Didukung

Versi Castle-Script yang saat ini didukung:

| Versi | Status             |
| ----- | ------------------ |
| 0.9.x | :white_check_mark: |
| < 0.9 | :x:                |

## Melaporkan Kerentanan

Kami menganggap keamanan dengan serius. Jika Anda menemukan kerentanan keamanan di Castle-Script, harap laporkan secara bertanggung jawab.

### Cara Melaporkan

**JANGAN membuat issue publik di GitHub untuk kerentanan keamanan.**

Sebagai gantinya, laporkan masalah keamanan melalui:

1. **Email**: Buat issue dengan label "security" dan kami akan menghubungi Anda secara pribadi
2. **GitHub Security Advisory**: Gunakan tab "Security" → "Report a vulnerability"

### Informasi yang Harus Disertakan

Saat melaporkan kerentanan, harap sertakan:

- Deskripsi kerentanan
- Langkah-langkah untuk mereproduksi masalah
- Versi yang terpengaruh
- Potensi dampak
- Saran perbaikan (jika ada)

### Timeline Respons

- **Respons Awal**: Dalam 48 jam
- **Update Status**: Dalam 7 hari
- **Timeline Perbaikan**: Tergantung tingkat keparahan
  - Kritis: 1-7 hari
  - Tinggi: 1-14 hari
  - Sedang: 1-30 hari
  - Rendah: Best effort

### Praktik Keamanan Terbaik

Saat menggunakan Castle-Script:

1. **Validasi Input**: Selalu validasi input pengguna dalam program Anda
2. **Operasi File**: Hati-hati dengan path file dan permissions
3. **Eksekusi**: Jangan jalankan file .cs yang tidak dipercaya
4. **Dependencies**: Jaga agar sistem tetap update

## Pertimbangan Keamanan yang Perlu Diketahui

### Akses File System

Castle-Script memiliki fungsi file I/O (`baca_file`, `tulis_file`, dll). Pengguna harus:

- Validasi path file sebelum digunakan
- Gunakan absolute path jika memungkinkan
- Periksa permissions sebelum operasi file
- Sanitasi nama file yang diberikan pengguna

### Eksekusi Kode

Castle-Script mengeksekusi kode. Saat menjalankan file .cs:

- Hanya jalankan kode yang dipercaya
- Review kode sebelum dijalankan
- Waspadai akses file system dalam script
- Gunakan sandboxing untuk kode yang tidak dipercaya

### Aplikasi GUI

Fungsi GUI menggunakan Tkinter. Perlu diperhatikan:

- Aplikasi GUI dapat mengakses resource sistem
- Input field harus divalidasi
- Jangan percaya input pengguna tanpa validasi

## Update Keamanan

Patch keamanan akan dirilis sebagai:

- Patch versions (misal 0.9.1 → 0.9.2) untuk masalah minor
- Minor versions (misal 0.9.x → 0.10.x) untuk masalah signifikan
- Pengumuman di GitHub Releases

## Cakupan

Kebijakan keamanan ini berlaku untuk:

- Interpreter Castle-Script (`src/castlescript.py`)
- Fungsi built-in (semua file `src/castlescript_*.py`)
- Launcher resmi (`cs`, `cs.bat`, dll)

Di luar cakupan:

- Program .cs yang dibuat pengguna
- Ekstensi pihak ketiga
- Environment deployment

## Kontak

Untuk masalah keamanan: Gunakan GitHub issues dengan label "security"

Untuk pertanyaan umum: Gunakan GitHub Discussions atau issues reguler

---

Terima kasih telah membantu menjaga Castle-Script dan penggunanya tetap aman!
