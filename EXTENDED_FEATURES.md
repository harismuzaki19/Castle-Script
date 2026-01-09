# CastleScript - Extended Features Guide

Panduan lengkap untuk menggunakan fitur-fitur extended CastleScript.

## Status Implementasi

**✅ SELESAI:**

- Arrays & Lists (7 functions)
- String Methods (11 functions)
- Math Functions (10 functions)
- File I/O (7 functions)
- Date & Time (6 functions)
- JSON Operations (2 functions)

**Total: 43 built-in functions baru!**

---

## 1. ARRAYS & LISTS

### Membuat Array

```castlescript
var angka = [1, 2, 3, 4, 5]
var nama = ["Ali", "Budi", "Citra"]
var campur = [1, "dua", benar, 4.5]
```

### Mengakses Element

```castlescript
tulis(angka[0])  // 1
tulis(angka[2])  // 3
tulis(nama[1])   // "Budi"
```

### Fungsi Array

**tambah(array, item)** - Menambah element ke akhir array

```castlescript
var arr = [1, 2, 3]
tambah(arr, 4)
tulis(ke_teks(arr))  // [1, 2, 3, 4]
```

**hapus(array, index)** - Menghapus element berdasarkan index

```castlescript
var arr = [10, 20, 30]
hapus(arr, 1)  // Hapus index 1
tulis(ke_teks(arr))  // [10, 30]
```

**sisip(array, index, item)** - Menyisipkan element di posisi tertentu

```castlescript
var arr = [1, 2, 4]
sisip(arr, 2, 3)  // Sisip 3 di index 2
tulis(ke_teks(arr))  // [1, 2, 3, 4]
```

**gabung(array1, array2)** - Menggabungkan dua array

```castlescript
var arr1 = [1, 2, 3]
var arr2 = [4, 5, 6]
var hasil = gabung(arr1, arr2)
tulis(ke_teks(hasil))  // [1, 2, 3, 4, 5, 6]
```

**irisan(array, start, end)** - Mengambil sebagian array (slice)

```castlescript
var arr = [1, 2, 3, 4, 5]
var bagian = irisan(arr, 1, 4)
tulis(ke_teks(bagian))  // [2, 3, 4]
```

**balik(array)** - Membalik urutan array

```castlescript
var arr = [1, 2, 3, 4]
var terbalik = balik(arr)
tulis(ke_teks(terbalik))  // [4, 3, 2, 1]
```

**urutkan(array)** - Mengurutkan array

```castlescript
var arr = [5, 2, 8, 1, 9]
var terurut = urutkan(arr)
tulis(ke_teks(terurut))  // [1, 2, 5, 8, 9]
```

---

## 2. STRING METHODS

**potong(text, start, end)** - Substring

```castlescript
var teks = "Halo Dunia"
tulis(pot ong(teks, 0, 4))  // "Halo"
tulis(potong(teks, 5))      // "Dunia"
```

**pisah(text, separator)** - Split string menjadi array

```castlescript
var teks = "satu,dua,tiga"
var kata = pisah(teks, ",")
tulis(ke_teks(kata))  // ["satu", "dua", "tiga"]
```

**gabung_teks(array, separator)** - Join array jadi string

```castlescript
var kata = ["Halo", "Dunia"]
var teks = gabung_teks(kata, " ")
tulis(teks)  // "Halo Dunia"
```

**ganti(text, old, new)** - Replace substring

```castlescript
var teks = "Halo Dunia"
var baru = ganti(teks, "Dunia", "World")
tulis(baru)  // "Halo World"
```

**huruf_besar(text) / huruf_kecil(text)** - Case conversion

```castlescript
tulis(huruf_besar("halo"))   // "HALO"
tulis(huruf_kecil("DUNIA"))  // "dunia"
```

**rapikan(text)** - Trim whitespace

```castlescript
var teks = "  halo  "
tulis(rapikan(teks))  // "halo"
```

**mengandung(text, substring)** - Check if contains

```castlescript
var teks = "Halo Dunia"
tulis(ke_teks(mengandung(teks, "Dunia")))  // benar
tulis(ke_teks(mengandung(teks, "World")))  // salah
```

**mulai_dengan(text, prefix)** - Check if starts with

```castlescript
tulis(ke_teks(mulai_dengan("Halo", "H")))  // benar
```

**akhiri_dengan(text, suffix)** - Check if ends with

```castlescript
tulis(ke_teks(akhiri_dengan("Halo", "o")))  // benar
```

**indeks(text, substring)** - Find position

```castlescript
var teks = "Halo Dunia"
tulis(ke_teks(indeks(teks, "Dunia")))  // 5
```

---

## 3. MATH FUNCTIONS

**absolut(x)** - Nilai absolut

```castlescript
tulis(ke_teks(absolut(-5)))  // 5
```

**pangkat(base, exp)** - Perpangkatan

```castlescript
tulis(ke_teks(pangkat(2, 3)))  // 8.0
```

**akar(x)** - Akar kuadrat

```castlescript
tulis(ke_teks(akar(16)))  // 4.0
```

**bulatkan(x, digits)** - Pembulatan

```castlescript
tulis(ke_teks(bulatkan(3.7)))     // 4
tulis(ke_teks(bulatkan(3.14159, 2)))  // 3.14
```

**lantai(x)** - Floor (pembulatan ke bawah)

```castlescript
tulis(ke_teks(lantai(3.9)))  // 3
```

**langit(x)** - Ceil (pembulatan ke atas)

```castlescript
tulis(ke_teks(langit(3.1)))  // 4
```

**minimal(...)** - Nilai terkecil

```castlescript
tulis(ke_teks(minimal(5, 2, 8, 3)))  // 2
```

**maksimal(...)** - Nilai terbesar

```castlescript
tulis(ke_teks(maksimal(5, 2, 8, 3)))  // 8
```

**angka_acak()** - Random 0-1

```castlescript
var angka = angka_acak()
tulis(ke_teks(angka))  // 0.xxx
```

**acak_antara(min, max)** - Random dalam range

```castlescript
var angka = acak_antara(1, 10)
tulis("Random 1-10: " + ke_teks(angka))
```

---

## 4. FILE I/O

**baca_file(path)** - Membaca file

```castlescript
var isi = baca_file("data.txt")
tulis(isi)
```

**tulis_file(path, content)** - Menulis file (overwrite)

```castlescript
tulis_file("output.txt", "Hello World")
```

**tambah_file(path, content)** - Append ke file

```castlescript
tambah_file("log.txt", "Log entry\\n")
```

**hapus_file(path)** - Menghapus file

```castlescript
hapus_file("temp.txt")
```

**ada_file(path)** - Cek apakah file exists

```castlescript
jika (ada_file("config.ini")) {
    tulis("Config ditemukan")
}
```

**buat_folder(path)** - Membuat direktori

```castlescript
buat_folder("data/backup")
```

**daftar_file(directory)** - List files

```castlescript
var files = daftar_file(".")
tulis(ke_teks(files))
```

---

## 5. DATE & TIME

**waktu_sekarang()** - Waktu saat ini

```castlescript
var sekarang = waktu_sekarang()
tulis(ke_teks(sekarang))
```

**tanggal_sekarang()** - Tanggal hari ini

```castlescript
var hari_ini = tanggal_sekarang()
tulis(ke_teks(hari_ini))
```

**format_waktu(datetime, format)** - Format waktu

```castlescript
var sekarang = waktu_sekarang()
var formatted = format_waktu(sekarang, "%Y-%m-%d %H:%M:%S")
tulis(formatted)
```

**tahun(datetime) / bulan(datetime) / hari(datetime)** - Extract components

```castlescript
var tahun_sekarang = tahun()
var bulan_sekarang = bulan()
tulis("Tahun: " + ke_teks(tahun_sekarang))
```

---

## 6. OBJECTS/DICTIONARIES

### Membuat Object

```castlescript
var orang = {
    nama: "Budi",
    umur: 25,
    kota: "Jakarta"
}
```

### Mengakses Property

```castlescript
tulis(orang["nama"])  // "Budi"
tulis(ke_teks(orang["umur"]))  // 25
```

### Modify Object

```castlescript
orang["email"] = "budi@example.com"  // Tambah property baru (akan ditambahkan di future update)
```

---

## 7. JSON OPERATIONS

**dari_json(string)** - Parse JSON

```castlescript
var json_str = "{\"nama\": \"Ali\", \"umur\": 30}"
var obj = dari_json(json_str)
tulis(obj["nama"])
```

**ke_json(object)** - Convert ke JSON string

```castlescript
var orang = {nama: "Budi", umur: 25}
var json_str = ke_json(orang)
tulis(json_str)
```

---

## Contoh Program Lengkap

### Program: Analisis Data Sederhana

```castlescript
// Program analisis data sederhana
tulis("=== ANALISIS DATA ===")

// Data angka
var data = [45, 67, 23, 89, 12, 56, 78, 34]

// Statistik
var total = 0
ulangi(var i = 0; i < panjang(data); i = i + 1) {
    total = total + data[i]
}

var rata = total / panjang(data)
var maks = maksimal(45, 67, 23, 89, 12, 56, 78, 34)
var minim = minimal(45, 67, 23, 89, 12, 56, 78, 34)

tulis("Jumlah data: " + ke_teks(panjang(data)))
tulis("Total: " + ke_teks(total))
tulis("Rata-rata: " + ke_teks(rata))
tulis("Maksimal: " + ke_teks(maks))
tulis("Minimal: " + ke_teks(minim))

// Urutkan data
var terurut = urutkan(data)
tulis("Data terurut: " + ke_teks(terurut))

// Simpan hasil
var hasil = "Analisis Data\\n"
hasil = hasil + "Total: " + ke_teks(total) + "\\n"
hasil = hasil + "Rata-rata: " + ke_teks(rata) + "\\n"
tulis_file("hasil_analisis.txt", hasil)
tulis("Hasil disimpan ke hasil_analisis.txt")
```

---

## Tips & Best Practices

1. **Arrays**: Gunakan `panjang(arr)` untuk iterasi
2. **Strings**: Gunakan `pisah()` dan `gabung_teks()` untuk parsing data
3. **Math**: Gunakan `bulatkan()` untuk tampilan angka yang rapi
4. **File I/O**: Selalu cek `ada_file()` sebelum baca
5. **Objects**: Gunakan untuk struktur data kompleks

---

## Troubleshooting

**Error: "Index di luar jangkauan"**

- Pastikan index < panjang(array)

**Error: "File tidak ditemukan"**

- Gunakan `ada_file()` untuk cek sebelum baca

**Error: "Tidak bisa mengakar bilangan negatif"**

- Gunakan `absolut()` dulu jika perlu

---

**Versi**: CastleScript Extended v1.0
**Bahasa**: 100% Indonesia 🇮🇩
