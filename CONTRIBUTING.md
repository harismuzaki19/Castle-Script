# Berkontribusi ke Castle-Script

Terima kasih atas minat Anda untuk berkontribusi ke Castle-Script! Dokumen ini memberikan panduan untuk berkontribusi ke proyek.

## Cara Berkontribusi

### Melaporkan Bug

Menemukan bug? Silakan buat issue dengan:

- Judul dan deskripsi yang jelas
- Langkah-langkah untuk mereproduksi
- Perilaku yang diharapkan vs aktual
- Versi Castle-Script
- Sistem operasi
- Contoh kode (jika ada)

### Mengusulkan Fitur

Punya ide? Buka issue dengan:

- Deskripsi fitur yang jelas
- Use case dan contoh
- Mengapa fitur ini berguna
- Pendekatan implementasi yang mungkin

### Kontribusi Kode

1. Fork repository
2. Buat feature branch (`git checkout -b feature/fitur-keren`)
3. Buat perubahan Anda
4. Test perubahan Anda
5. Commit dengan pesan yang jelas
6. Push ke fork Anda
7. Buka Pull Request

## Setup Development

```bash
# Clone fork Anda
git clone https://github.com/username-anda/Castle-Script.git
cd Castle-Script

# Test interpreter
cs examples/hello.cs

# Run tests
cs examples/test_features.cs
```

## Style Kode

### Kode CastleScript

- Gunakan keyword Indonesia secara konsisten
- Ikuti naming conventions yang ada
- Tambahkan komentar untuk logika yang kompleks
- Test kode Anda sebelum submit

### Kode Python (untuk kontributor core)

- Ikuti pedoman PEP 8
- Gunakan nama variabel yang bermakna
- Tambahkan komentar untuk logika kompleks
- Jaga fungsi tetap fokus dan kecil

## Testing

Sebelum submit:

1. Test di platform target Anda
2. Jalankan file test yang ada
3. Tambahkan test untuk fitur baru
4. Verifikasi tidak ada regresi

## Dokumentasi

- Update file .md yang relevan
- Tambahkan contoh untuk fitur baru
- Jaga dokumentasi tetap jelas dan ringkas
- Gunakan Bahasa Indonesia untuk contoh

## Proses Pull Request

1. Update dokumentasi jika diperlukan
2. Tambahkan diri Anda ke contributors (jika mau)
3. Pastikan semua test pass
4. Minta review dari maintainers
5. Tangani komentar review
6. Tunggu approval dan merge

## Pedoman Komunitas

- Bersikap hormat dan konstruktif
- Bantu orang lain belajar
- Bagikan pengetahuan
- Berikan kredit yang layak
- Have fun coding!

## Pertanyaan?

- Buka GitHub Discussion
- Buat issue dengan label "question"
- Periksa dokumentasi yang ada terlebih dahulu

## Lisensi

Dengan berkontribusi, Anda setuju bahwa kontribusi Anda akan dilisensikan di bawah lisensi yang sama dengan proyek.

---

Terima kasih telah membuat Castle-Script lebih baik! 🚀
