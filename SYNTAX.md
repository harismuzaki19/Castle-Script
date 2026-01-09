# Referensi Sintaks CastleScript

Dokumentasi lengkap sintaks bahasa pemrograman CastleScript.

## Daftar Isi

- [Komentar](#komentar)
- [Variabel](#variabel)
- [Tipe Data](#tipe-data)
- [Operator](#operator)
- [Kondisi](#kondisi)
- [Perulangan](#perulangan)
- [Fungsi](#fungsi)
- [Input/Output](#inputoutput)
- [Fungsi Bawaan](#fungsi-bawaan)

---

## Komentar

Komentar digunakan untuk dokumentasi dan tidak akan dieksekusi.

```castlescript
// Ini adalah komentar satu baris

// Komentar bisa digunakan untuk menjelaskan kode
var nama = "Haris"  // Komentar juga bisa di akhir baris
```

**Catatan:** Saat ini CastleScript hanya mendukung komentar satu baris dengan `//`.

---

## Variabel

Variabel digunakan untuk menyimpan nilai. Gunakan kata kunci `var` untuk mendeklarasikan variabel.

### Deklarasi Variabel

```castlescript
var nama = "Haris"
var umur = 25
var tinggi = 175.5
var aktif = benar
```

### Assignment

```castlescript
var x = 10
x = 20          // Mengubah nilai x
x = x + 5       // x sekarang 25
```

---

## Tipe Data

CastleScript mendukung beberapa tipe data dasar:

### 1. Angka (Number)

Integer dan floating-point:

```castlescript
var bilangan_bulat = 42
var desimal = 3.14159
var negatif = -10
```

### 2. Teks (String)

String menggunakan tanda petik ganda (`"`) atau tunggal (`'`):

```castlescript
var nama = "Haris"
var pesan = 'Halo Dunia'
var gabungan = "Nama saya " + nama
```

**Escape sequences:**

- `\n` - Newline (baris baru)
- `\t` - Tab
- `\\` - Backslash
- `\"` - Tanda petik ganda
- `\'` - Tanda petik tunggal

```castlescript
var multiline = "Baris 1\nBaris 2\nBaris 3"
```

### 3. Boolean

Nilai kebenaran:

```castlescript
var aktif = benar
var selesai = salah
```

### 4. Kosong (Null)

Nilai kosong/null:

```castlescript
var data = kosong
```

---

## Operator

### Operator Aritmatika

| Operator | Deskripsi          | Contoh   | Hasil |
| -------- | ------------------ | -------- | ----- |
| `+`      | Penjumlahan        | `5 + 3`  | `8`   |
| `-`      | Pengurangan        | `5 - 3`  | `2`   |
| `*`      | Perkalian          | `5 * 3`  | `15`  |
| `/`      | Pembagian          | `10 / 2` | `5`   |
| `%`      | Modulo (sisa bagi) | `10 % 3` | `1`   |

```castlescript
var hasil = (5 + 3) * 2     // 16
var sisa = 17 % 5            // 2
```

### Operator Perbandingan

| Operator | Deskripsi             | Contoh   | Hasil   |
| -------- | --------------------- | -------- | ------- |
| `==`     | Sama dengan           | `5 == 5` | `benar` |
| `!=`     | Tidak sama dengan     | `5 != 3` | `benar` |
| `<`      | Lebih kecil           | `3 < 5`  | `benar` |
| `>`      | Lebih besar           | `5 > 3`  | `benar` |
| `<=`     | Lebih kecil atau sama | `5 <= 5` | `benar` |
| `>=`     | Lebih besar atau sama | `5 >= 5` | `benar` |

### Operator Logika

| Operator | Deskripsi  | Contoh                       |
| -------- | ---------- | ---------------------------- |
| `dan`    | AND logika | `benar dan salah` → `salah`  |
| `atau`   | OR logika  | `benar atau salah` → `benar` |
| `tidak`  | NOT logika | `tidak benar` → `salah`      |

```castlescript
var a = 5
var b = 10

jika (a > 0 dan b > 0) {
    tulis("Kedua angka positif")
}

jika (a < 0 atau b < 0) {
    tulis("Salah satu negatif")
}

jika (tidak (a == b)) {
    tulis("a dan b tidak sama")
}
```

### Operator Unary

```castlescript
var x = 5
var y = -x      // y = -5
var z = +x      // z = 5

var aktif = benar
var nonaktif = tidak aktif  // salah
```

---

## Kondisi

### If Statement

```castlescript
jika (kondisi) {
    // kode jika kondisi benar
}
```

**Contoh:**

```castlescript
var nilai = 85

jika (nilai >= 80) {
    tulis("Lulus dengan baik!")
}
```

### If-Else Statement

```castlescript
jika (kondisi) {
    // kode jika kondisi benar
} jika_tidak {
    // kode jika kondisi salah
}
```

**Contoh:**

```castlescript
var umur = 17

jika (umur >= 18) {
    tulis("Anda sudah dewasa")
} jika_tidak {
    tulis("Anda masih di bawah umur")
}
```

### Nested If

```castlescript
var nilai = 75

jika (nilai >= 80) {
    tulis("Nilai A")
} jika_tidak {
    jika (nilai >= 70) {
        tulis("Nilai B")
    } jika_tidak {
        jika (nilai >= 60) {
            tulis("Nilai C")
        } jika_tidak {
            tulis("Nilai D")
        }
    }
}
```

---

## Perulangan

### While Loop (selama)

```castlescript
selama (kondisi) {
    // kode yang akan diulang
}
```

**Contoh:**

```castlescript
var i = 1
selama (i <= 5) {
    tulis(i)
    i = i + 1
}
// Output: 1 2 3 4 5
```

### For Loop (ulangi)

```castlescript
ulangi (inisialisasi; kondisi; increment) {
    // kode yang akan diulang
}
```

**Contoh:**

```castlescript
ulangi (var i = 1; i <= 5; i = i + 1) {
    tulis(i)
}
// Output: 1 2 3 4 5
```

**Contoh Loop Mundur:**

```castlescript
ulangi (var i = 10; i >= 1; i = i - 1) {
    tulis(i)
}
// Countdown dari 10 ke 1
```

### Nested Loops

```castlescript
ulangi (var i = 1; i <= 3; i = i + 1) {
    ulangi (var j = 1; j <= 3; j = j + 1) {
        tulis(i)
        tulis(",")
        tulis(j)
        tulis(" ")
    }
    tulis("")
}
// Output:
// 1,1 1,2 1,3
// 2,1 2,2 2,3
// 3,1 3,2 3,3
```

---

## Fungsi

### Definisi Fungsi

```castlescript
fungsi nama_fungsi(parameter1, parameter2) {
    // kode fungsi
    kembalikan nilai
}
```

### Fungsi Tanpa Parameter

```castlescript
fungsi sapa() {
    kembalikan "Halo!"
}

var pesan = sapa()
tulis(pesan)  // Output: Halo!
```

### Fungsi Dengan Parameter

```castlescript
fungsi tambah(a, b) {
    kembalikan a + b
}

var hasil = tambah(5, 3)
tulis(hasil)  // Output: 8
```

### Fungsi Dengan Multiple Parameters

```castlescript
fungsi info_lengkap(nama, umur, kota) {
    var info = "Nama: " + nama + ", Umur: " + ke_teks(umur) + ", Kota: " + kota
    kembalikan info
}

var data = info_lengkap("Haris", 25, "Jakarta")
tulis(data)
```

### Rekursi

Fungsi yang memanggil dirinya sendiri:

```castlescript
fungsi faktorial(n) {
    jika (n <= 1) {
        kembalikan 1
    }
    kembalikan n * faktorial(n - 1)
}

tulis(faktorial(5))  // Output: 120
```

### Fungsi Tanpa Return

```castlescript
fungsi cetak_garis() {
    tulis("====================")
}

cetak_garis()
tulis("Judul")
cetak_garis()
```

---

## Input/Output

### Output

#### tulis()

Print dengan newline di akhir:

```castlescript
tulis("Halo")
tulis(" ")
tulis("Dunia")
// Output:
// Halo
//
// Dunia
```

### Input

#### baca()

Membaca input dari user:

```castlescript
var nama = baca("Masukkan nama Anda: ")
tulis("Halo, " + nama)
```

**Input angka:**

```castlescript
var input = baca("Masukkan angka: ")
var angka = ke_angka(input)
tulis("Angka yang dimasukkan: " + ke_teks(angka))
```

---

## Fungsi Bawaan

### tulis(...)

Print satu atau lebih nilai dengan newline.

```castlescript
tulis("Halo")
tulis(" ", "Dunia", "!")
// Output:
// Halo
//   Dunia !
```

### baca(prompt)

Membaca input dari user dengan optional prompt.

```castlescript
var nama = baca("Nama: ")
var umur = baca()  // Tanpa prompt
```

### panjang(nilai)

Mengembalikan panjang string.

```castlescript
var teks = "CastleScript"
var len = panjang(teks)
tulis(len)  // Output: 12
```

### tipe(nilai)

Mengembalikan tipe data sebagai string.

```castlescript
tulis(tipe(123))        // Output: angka
tulis(tipe("halo"))     // Output: teks
tulis(tipe(benar))      // Output: boolean
tulis(tipe(kosong))     // Output: kosong
```

### ke_angka(nilai)

Konversi nilai menjadi angka.

```castlescript
var angka = ke_angka("123")
tulis(angka + 5)  // Output: 128

var desimal = ke_angka("3.14")
tulis(desimal)  // Output: 3.14
```

### ke_teks(nilai)

Konversi nilai menjadi string.

```castlescript
var teks = ke_teks(123)
tulis("Nilai: " + teks)  // Output: Nilai: 123
```

---

## Contoh Program Lengkap

### Program Quiz Sederhana

```castlescript
fungsi tanya(pertanyaan, jawaban_benar) {
    var jawaban = baca(pertanyaan + " ")

    jika (jawaban == jawaban_benar) {
        tulis("✓ Benar!")
        kembalikan 1
    } jika_tidak {
        tulis("✗ Salah. Jawaban: " + jawaban_benar)
        kembalikan 0
    }
}

tulis("=== Quiz Matematika ===")
tulis("")

var skor = 0

skor = skor + tanya("Berapa 5 + 3?", "8")
skor = skor + tanya("Berapa 10 - 4?", "6")
skor = skor + tanya("Berapa 3 * 4?", "12")

tulis("")
tulis("Skor Anda: ")
tulis(skor)
tulis(" dari 3")
tulis("")
```

### Menebak Angka

```castlescript
var angka_rahasia = 7
var tebakan = 0
var percobaan = 0

tulis("=== Game Tebak Angka ===")
tulis("Saya memikirkan angka antara 1-10")
tulis("")

selama (tebakan != angka_rahasia) {
    tebakan = ke_angka(baca("Tebak angka: "))
    percobaan = percobaan + 1

    jika (tebakan < angka_rahasia) {
        tulis("Terlalu kecil!")
    } jika_tidak {
        jika (tebakan > angka_rahasia) {
            tulis("Terlalu besar!")
        }
    }
}

tulis("")
tulis("Selamat! Anda benar!")
tulis("Jumlah percobaan: ")
tulis(percobaan)
```

---

## Tips dan Best Practices

### 1. Penamaan Variabel

Gunakan nama yang deskriptif:

```castlescript
// ✓ Baik
var jumlah_siswa = 30
var nama_lengkap = "Haris"

// ✗ Kurang baik
var x = 30
var n = "Haris"
```

### 2. Indentasi

Gunakan indentasi yang konsisten:

```castlescript
fungsi hitung_luas(panjang, lebar) {
    var luas = panjang * lebar
    kembalikan luas
}
```

### 3. Komentar

Tambahkan komentar untuk kode yang kompleks:

```castlescript
// Menghitung faktorial menggunakan rekursi
fungsi faktorial(n) {
    jika (n <= 1) {
        kembalikan 1
    }
    kembalikan n * faktorial(n - 1)
}
```

### 4. Validasi Input

Selalu validasi input dari user:

```castlescript
var input = baca("Masukkan angka positif: ")
var angka = ke_angka(input)

jika (angka <= 0) {
    tulisln("Error: Angka harus positif!")
} jika_tidak {
    tulisln("Anda memasukkan: " + ke_teks(angka))
}
```

---

## Kesalahan Umum

### 1. Variabel Tidak Dideklarasikan

```castlescript
// ✗ Error: variabel 'x' belum dideklarasikan
x = 10

// ✓ Benar
var x = 10
```

### 2. Pembagian Dengan Nol

```castlescript
var hasil = 10 / 0  // Error: Pembagian dengan nol

// ✓ Validasi sebelum membagi
jika (pembagi != 0) {
    var hasil = 10 / pembagi
}
```

### 3. String Tidak Ditutup

```castlescript
// ✗ Error
var nama = "Haris

// ✓ Benar
var nama = "Haris"
```

---

## Penutup

Dokumentasi ini mencakup semua fitur utama CastleScript. Untuk contoh program lebih lanjut, lihat folder `examples/`.

Selamat coding! 🎉
