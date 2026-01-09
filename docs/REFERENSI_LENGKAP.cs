// ============================================================================
// REFERENSI LENGKAP CASTLESCRIPT
// File: REFERENSI_LENGKAP.cs
// Berisi SEMUA sintaks, fungsi, variabel, dan fitur bahasa CastleScript
// ============================================================================

// ============================================================================
// 1. KOMENTAR
// ============================================================================

// Ini adalah komentar satu baris
// Komentar tidak akan dieksekusi oleh interpreter
// Gunakan untuk dokumentasi dan penjelasan kode


// ============================================================================
// 2. VARIABEL & TIPE DATA
// ============================================================================

// --- Deklarasi Variabel ---
// Gunakan kata kunci 'var' untuk membuat variabel baru

var nama_variabel = nilai

// --- Tipe Data: ANGKA (Number) ---
// Integer (bilangan bulat)
var bilangan_bulat = 42
var angka_negatif = -100
var angka_nol = 0

// Float/Decimal (bilangan desimal)
var bilangan_desimal = 3.14159
var nilai_pi = 3.14
var suhu = -5.5

// --- Tipe Data: TEKS (String) ---
// String dengan tanda petik ganda
var teks1 = "Halo Dunia"
var teks2 = "CastleScript"

// String dengan tanda petik tunggal
var teks3 = 'Bahasa Indonesia'

// String kosong
var teks_kosong = ""

// Escape sequences dalam string
var baris_baru = "Baris 1\nBaris 2\nBaris 3"
var tab = "Kolom1\tKolom2\tKolom3"
var backslash = "Path: C:\\Users\\Folder"
var petik_ganda = "Dia berkata \"Halo\""
var petik_tunggal = 'It\'s okay'

// Penggabungan string (concatenation)
var nama_depan = "Budi"
var nama_belakang = "Santoso"
var nama_lengkap = nama_depan + " " + nama_belakang

// --- Tipe Data: BOOLEAN ---
// Nilai kebenaran (true/false)
var benar_value = benar      // true
var salah_value = salah      // false
var aktif = benar
var selesai = salah

// --- Tipe Data: KOSONG (Null) ---
// Nilai kosong/tidak ada
var data_kosong = kosong
var hasil = kosong


// ============================================================================
// 3. OPERATOR
// ============================================================================

// --- Operator Aritmatika ---
var a = 10
var b = 3

var penjumlahan = a + b        // 13
var pengurangan = a - b        // 7
var perkalian = a * b          // 30
var pembagian = a / b          // 3.333...
var modulo = a % b             // 1 (sisa bagi)

// Operator dengan prioritas
var hasil1 = 5 + 3 * 2         // 11 (perkalian dulu)
var hasil2 = (5 + 3) * 2       // 16 (kurung dulu)

// --- Operator Perbandingan ---
var x = 10
var y = 20

var sama_dengan = x == y           // salah (false)
var tidak_sama = x != y            // benar (true)
var lebih_kecil = x < y            // benar (true)
var lebih_besar = x > y            // salah (false)
var lebih_kecil_sama = x <= 10     // benar (true)
var lebih_besar_sama = y >= 20     // benar (true)

// --- Operator Logika ---
var kondisi1 = benar
var kondisi2 = salah

// DAN (AND) - semua harus benar
var hasil_dan = kondisi1 dan kondisi2    // salah

// ATAU (OR) - salah satu benar
var hasil_atau = kondisi1 atau kondisi2  // benar

// TIDAK (NOT) - kebalikan
var hasil_tidak = tidak kondisi1         // salah

// Kombinasi operator logika
var umur = 25
var punya_sim = benar
var boleh_nyetir = umur >= 17 dan punya_sim

// --- Operator Unary ---
var angka = 5
var negatif = -angka       // -5
var positif = +angka       // 5

var aktif2 = benar
var nonaktif = tidak aktif2   // salah


// ============================================================================
// 4. STRUKTUR KONTROL - KONDISI
// ============================================================================

// --- IF (JIKA) ---
// Sintaks: jika (kondisi) { kode }

var nilai = 85

jika (nilai >= 80) {
    tulis("Lulus dengan nilai A")
}

// --- IF-ELSE (JIKA-JIKA_TIDAK) ---
// Sintaks: jika (kondisi) { kode1 } jika_tidak { kode2 }

var umur2 = 20

jika (umur2 >= 18) {
    tulis("Dewasa")
} jika_tidak {
    tulis("Di bawah umur")
}

// --- NESTED IF (IF Bersarang) ---
var skor = 75

jika (skor >= 90) {
    tulis("Nilai: A")
} jika_tidak {
    jika (skor >= 80) {
        tulis("Nilai: B")
    } jika_tidak {
        jika (skor >= 70) {
            tulis("Nilai: C")
        } jika_tidak {
            jika (skor >= 60) {
                tulis("Nilai: D")
            } jika_tidak {
                tulis("Nilai: E")
            }
        }
    }
}

// --- IF dengan Operator Logika ---
var nilai_uas = 80
var nilai_tugas = 85
var kehadiran = 90

jika (nilai_uas >= 70 dan nilai_tugas >= 70 dan kehadiran >= 80) {
    tulis("LULUS")
} jika_tidak {
    tulis("TIDAK LULUS")
}


// ============================================================================
// 5. STRUKTUR KONTROL - PERULANGAN
// ============================================================================

// --- WHILE LOOP (SELAMA) ---
// Sintaks: selama (kondisi) { kode }
// Loop akan terus berjalan selama kondisi benar

var counter = 1
selama (counter <= 5) {
    tulis("Hitungan: " + ke_teks(counter))
    counter = counter + 1
}

// Contoh: Countdown
var waktu = 10
selama (waktu > 0) {
    tulis("Sisa waktu: " + ke_teks(waktu))
    waktu = waktu - 1
}
tulis("WAKTU HABIS!")

// --- FOR LOOP (ULANGI) ---
// Sintaks: ulangi (init; kondisi; increment) { kode }

// Loop naik
ulangi (var i = 1; i <= 10; i = i + 1) {
    tulis("Iterasi ke-" + ke_teks(i))
}

// Loop turun
ulangi (var j = 10; j >= 1; j = j - 1) {
    tulis("Countdown: " + ke_teks(j))
}

// Loop dengan step berbeda
ulangi (var k = 0; k <= 20; k = k + 2) {
    tulis("Angka genap: " + ke_teks(k))
}

// --- NESTED LOOP (Loop Bersarang) ---
// Loop di dalam loop

// Tabel perkalian
ulangi (var baris2 = 1; baris2 <= 5; baris2 = baris2 + 1) {
    ulangi (var kolom = 1; kolom <= 5; kolom = kolom + 1) {
        var hasil_kali = baris2 * kolom
        tulis(ke_teks(hasil_kali) + " ")
    }
    tulis("")
}

// Pola bintang (segitiga)
ulangi (var baris3 = 1; baris3 <= 5; baris3 = baris3 + 1) {
    ulangi (var kolom2 = 1; kolom2 <= baris3; kolom2 = kolom2 + 1) {
        tulis("* ")
    }
    tulis("")
}


// ============================================================================
// 6. FUNGSI (FUNCTIONS)
// ============================================================================

// --- Definisi Fungsi Dasar ---
// Sintaks: fungsi nama_fungsi(parameter1, parameter2, ...) { kode }

fungsi sapa() {
    tulis("Halo dari fungsi!")
}

// Memanggil fungsi
sapa()

// --- Fungsi dengan Parameter ---
fungsi sapa_nama(nama2) {
    tulis("Halo, " + nama2 + "!")
}

sapa_nama("Budi")
sapa_nama("Ani")

// Fungsi dengan multiple parameter
fungsi tambah(angka1, angka2) {
    var hasil_tambah = angka1 + angka2
    tulis("Hasil: " + ke_teks(hasil_tambah))
}

tambah(5, 3)
tambah(10, 20)

// --- Fungsi dengan Return Value ---
// Gunakan 'kembalikan' untuk mengembalikan nilai

fungsi kali(a2, b2) {
    kembalikan a2 * b2
}

var hasil_perkalian = kali(6, 7)
tulis("6 x 7 = " + ke_teks(hasil_perkalian))

// Fungsi matematika
fungsi luas_persegi(sisi) {
    kembalikan sisi * sisi
}

fungsi luas_persegi_panjang(panjang2, lebar) {
    kembalikan panjang2 * lebar
}

fungsi luas_lingkaran(jari_jari) {
    var pi = 3.14159
    kembalikan pi * jari_jari * jari_jari
}

var luas1 = luas_persegi(5)
var luas2 = luas_persegi_panjang(10, 5)
var luas3 = luas_lingkaran(7)

// --- Fungsi dengan Kondisi ---
fungsi cek_genap(angka3) {
    jika (angka3 % 2 == 0) {
        kembalikan benar
    } jika_tidak {
        kembalikan salah
    }
}

var angka_test = 10
jika (cek_genap(angka_test)) {
    tulis(ke_teks(angka_test) + " adalah genap")
} jika_tidak {
    tulis(ke_teks(angka_test) + " adalah ganjil")
}

// --- Fungsi Rekursif ---
// Fungsi yang memanggil dirinya sendiri

fungsi faktorial(n) {
    jika (n <= 1) {
        kembalikan 1
    }
    kembalikan n * faktorial(n - 1)
}

tulis("5! = " + ke_teks(faktorial(5)))    // 120
tulis("10! = " + ke_teks(faktorial(10)))  // 3628800

// Fibonacci rekursif
fungsi fibonacci(n2) {
    jika (n2 <= 1) {
        kembalikan n2
    }
    kembalikan fibonacci(n2 - 1) + fibonacci(n2 - 2)
}

tulis("Fibonacci ke-10: " + ke_teks(fibonacci(10)))

// --- Fungsi Utility ---
fungsi garis_pemisah() {
    tulis("=" + "=" + "=" + "=" + "=" + "=" + "=" + "=" + "=" + "=")
}

fungsi judul(teks) {
    garis_pemisah()
    tulis(teks)
    garis_pemisah()
}

judul("SELAMAT DATANG")

// Fungsi untuk validasi
fungsi validasi_umur(umur_input) {
    jika (umur_input < 0) {
        tulis("Error: Umur tidak boleh negatif")
        kembalikan salah
    }
    jika (umur_input > 150) {
        tulis("Error: Umur tidak realistis")
        kembalikan salah
    }
    kembalikan benar
}


// ============================================================================
// 7. FUNGSI BAWAAN (Built-in Functions)
// ============================================================================

// --- TULIS() - Output/Print ---
// Mencetak output ke layar dengan newline otomatis

tulis("Satu argumen")
tulis("Banyak", "argumen", "sekaligus")
tulis("")  // Baris kosong

// --- BACA() - Input dari User ---
// Membaca input dari pengguna

var input_nama = baca("Masukkan nama Anda: ")
tulis("Halo, " + input_nama)

var input_umur = baca("Masukkan umur: ")
var umur_angka = ke_angka(input_umur)

// Baca tanpa prompt
var input_data = baca()

// --- KE_ANGKA() - Konversi ke Number ---
// Mengubah string menjadi angka

var str_angka = "123"
var angka_converted = ke_angka(str_angka)
tulis(angka_converted + 5)  // 128

var str_desimal = "3.14"
var desimal_converted = ke_angka(str_desimal)
tulis(desimal_converted * 2)  // 6.28

// String yang tidak valid akan menjadi 0
var invalid = ke_angka("bukan angka")  // 0

// --- KE_TEKS() - Konversi ke String ---
// Mengubah angka atau nilai lain menjadi string

var angka_asli = 456
var teks_converted = ke_teks(angka_asli)
tulis("Angka: " + teks_converted)

var boolean_val = benar
tulis("Boolean: " + ke_teks(boolean_val))

// --- PANJANG() - Panjang String ---
// Mengembalikan panjang string

var kata = "CastleScript"
var panjang_kata = panjang(kata)
tulis("Panjang: " + ke_teks(panjang_kata))  // 12

var kalimat = "Halo Dunia Indonesia"
tulis("Panjang: " + ke_teks(panjang(kalimat)))  // 20

// --- TIPE() - Cek Tipe Data ---
// Mengembalikan tipe data sebagai string

tulis(tipe(123))        // "angka"
tulis(tipe(3.14))       // "angka"
tulis(tipe("halo"))     // "teks"
tulis(tipe(benar))      // "boolean"
tulis(tipe(salah))      // "boolean"
tulis(tipe(kosong))     // "kosong"


// ============================================================================
// 8. CONTOH PROGRAM LENGKAP
// ============================================================================

// --- Program Calculator ---
fungsi kalkulator() {
    tulis("=== KALKULATOR SEDERHANA ===")
    
    var angka_a = ke_angka(baca("Masukkan angka pertama: "))
    var angka_b = ke_angka(baca("Masukkan angka kedua: "))
    
    tulis("")
    tulis("Hasil Operasi:")
    tulis("Penjumlahan: " + ke_teks(angka_a + angka_b))
    tulis("Pengurangan: " + ke_teks(angka_a - angka_b))
    tulis("Perkalian: " + ke_teks(angka_a * angka_b))
    
    jika (angka_b != 0) {
        tulis("Pembagian: " + ke_teks(angka_a / angka_b))
        tulis("Modulo: " + ke_teks(angka_a % angka_b))
    } jika_tidak {
        tulis("Pembagian: Error (tidak bisa bagi 0)")
    }
}

// --- Program Nilai Siswa ---
fungsi nilai_siswa() {
    tulis("=== SISTEM NILAI SISWA ===")
    
    var nama_siswa = baca("Nama siswa: ")
    var nilai_siswa = ke_angka(baca("Nilai: "))
    
    var grade = ""
    
    jika (nilai_siswa >= 90) {
        grade = "A"
    } jika_tidak {
        jika (nilai_siswa >= 80) {
            grade = "B"
        } jika_tidak {
            jika (nilai_siswa >= 70) {
                grade = "C"
            } jika_tidak {
                jika (nilai_siswa >= 60) {
                    grade = "D"
                } jika_tidak {
                    grade = "E"
                }
            }
        }
    }
    
    tulis("")
    tulis("Nama: " + nama_siswa)
    tulis("Nilai: " + ke_teks(nilai_siswa))
    tulis("Grade: " + grade)
    
    jika (nilai_siswa >= 60) {
        tulis("Status: LULUS")
    } jika_tidak {
        tulis("Status: TIDAK LULUS")
    }
}

// --- Program Tabel Perkalian ---
fungsi tabel_perkalian(angka_tabel) {
    tulis("=== TABEL PERKALIAN " + ke_teks(angka_tabel) + " ===")
    
    ulangi (var i_tabel = 1; i_tabel <= 10; i_tabel = i_tabel + 1) {
        var hasil_tabel = angka_tabel * i_tabel
        tulis(ke_teks(angka_tabel) + " x " + ke_teks(i_tabel) + " = " + ke_teks(hasil_tabel))
    }
}

// --- Program Deret Fibonacci ---
fungsi cetak_fibonacci(jumlah) {
    tulis("=== DERET FIBONACCI ===")
    
    var fib_a = 0
    var fib_b = 1
    
    tulis(ke_teks(fib_a))
    tulis(ke_teks(fib_b))
    
    var count = 2
    selama (count < jumlah) {
        var fib_c = fib_a + fib_b
        tulis(ke_teks(fib_c))
        
        fib_a = fib_b
        fib_b = fib_c
        count = count + 1
    }
}

// --- Program Bilangan Prima ---
fungsi cek_prima(num) {
    jika (num <= 1) {
        kembalikan salah
    }
    
    jika (num == 2) {
        kembalikan benar
    }
    
    var pembagi = 2
    selama (pembagi < num) {
        jika (num % pembagi == 0) {
            kembalikan salah
        }
        pembagi = pembagi + 1
    }
    
    kembalikan benar
}

fungsi cetak_prima(batas) {
    tulis("=== BILANGAN PRIMA SAMPAI " + ke_teks(batas) + " ===")
    
    ulangi (var p = 2; p <= batas; p = p + 1) {
        jika (cek_prima(p)) {
            tulis(ke_teks(p))
        }
    }
}


// ============================================================================
// 9. KATA KUNCI (KEYWORDS)
// ============================================================================

// Daftar semua kata kunci yang digunakan di CastleScript:
//
// var          - Deklarasi variabel
// fungsi       - Definisi fungsi
// kembalikan   - Return value dari fungsi
// jika         - Kondisi if
// jika_tidak   - Kondisi else
// selama       - While loop
// ulangi       - For loop
// benar        - Boolean true
// salah        - Boolean false
// kosong       - Null value
// dan          - Logical AND
// atau         - Logical OR
// tidak        - Logical NOT


// ============================================================================
// 10. OPERATOR LENGKAP
// ============================================================================

// Aritmatika:
//   +    Penjumlahan
//   -    Pengurangan
//   *    Perkalian
//   /    Pembagian
//   %    Modulo (sisa bagi)

// Perbandingan:
//   ==   Sama dengan
//   !=   Tidak sama dengan
//   <    Lebih kecil
//   >    Lebih besar
//   <=   Lebih kecil atau sama dengan
//   >=   Lebih besar atau sama dengan

// Logika:
//   dan     Logical AND
//   atau    Logical OR
//   tidak   Logical NOT

// Assignment:
//   =    Assignment


// ============================================================================
// 11. BEST PRACTICES & TIPS
// ============================================================================

// 1. Gunakan nama variabel yang deskriptif
var jumlah_siswa = 30        // ✓ Baik
var x = 30                   // ✗ Kurang baik

// 2. Tambahkan komentar untuk kode kompleks
fungsi hitung_kompleks(a3, b3) {
    // Rumus: (a + b)² = a² + 2ab + b²
    var kuadrat_a = a3 * a3
    var kuadrat_b = b3 * b3
    var dua_ab = 2 * a3 * b3
    
    kembalikan kuadrat_a + dua_ab + kuadrat_b
}

// 3. Validasi input dari user
fungsi input_umur_safe() {
    var input = baca("Masukkan umur: ")
    var umur_valid = ke_angka(input)
    
    jika (umur_valid < 0 atau umur_valid > 150) {
        tulis("Error: Umur tidak valid!")
        kembalikan 0
    }
    
    kembalikan umur_valid
}

// 4. Pisahkan logika menjadi fungsi-fungsi kecil
fungsi hitung_diskon(harga, persen_diskon) {
    kembalikan harga * persen_diskon / 100
}

fungsi hitung_pajak(harga, persen_pajak) {
    kembalikan harga * persen_pajak / 100
}

fungsi hitung_total(harga_awal, diskon, pajak) {
    var harga_setelah_diskon = harga_awal - hitung_diskon(harga_awal, diskon)
    var total_pajak = hitung_pajak(harga_setelah_diskon, pajak)
    kembalikan harga_setelah_diskon + total_pajak
}


// ============================================================================
// 12. CONTOH KASUS PENGGUNAAN NYATA
// ============================================================================

// --- Sistem Kasir Sederhana ---
fungsi sistem_kasir() {
    tulis("=== SISTEM KASIR ===")
    tulis("")
    
    var total_belanja = 0
    var jumlah_item = 0
    
    var lanjut = "y"
    selama (lanjut == "y" atau lanjut == "Y") {
        var nama_barang = baca("Nama barang: ")
        var harga_barang = ke_angka(baca("Harga: "))
        var jumlah2 = ke_angka(baca("Jumlah: "))
        
        var subtotal = harga_barang * jumlah2
        total_belanja = total_belanja + subtotal
        jumlah_item = jumlah_item + jumlah2
        
        tulis("Subtotal: " + ke_teks(subtotal))
        tulis("")
        
        lanjut = baca("Tambah item lagi? (y/n): ")
    }
    
    tulis("")
    tulis("========== STRUK ==========")
    tulis("Total item: " + ke_teks(jumlah_item))
    tulis("Total belanja: " + ke_teks(total_belanja))
    
    // Diskon jika belanja > 100000
    jika (total_belanja > 100000) {
        var diskon2 = total_belanja * 10 / 100
        var total_bayar = total_belanja - diskon2
        tulis("Diskon 10%: " + ke_teks(diskon2))
        tulis("Total bayar: " + ke_teks(total_bayar))
    } jika_tidak {
        tulis("Total bayar: " + ke_teks(total_belanja))
    }
    
    tulis("===========================")
}

// --- Konverter Suhu ---
fungsi celsius_ke_fahrenheit(celsius) {
    kembalikan celsius * 9 / 5 + 32
}

fungsi celsius_ke_kelvin(celsius2) {
    kembalikan celsius2 + 273.15
}

fungsi fahrenheit_ke_celsius(fahrenheit) {
    kembalikan (fahrenheit - 32) * 5 / 9
}

fungsi konverter_suhu() {
    tulis("=== KONVERTER SUHU ===")
    tulis("1. Celsius ke Fahrenheit")
    tulis("2. Celsius ke Kelvin")
    tulis("3. Fahrenheit ke Celsius")
    tulis("")
    
    var pilihan = baca("Pilih (1-3): ")
    var suhu_input = ke_angka(baca("Masukkan suhu: "))
    
    jika (pilihan == "1") {
        var hasil_f = celsius_ke_fahrenheit(suhu_input)
        tulis(ke_teks(suhu_input) + "°C = " + ke_teks(hasil_f) + "°F")
    } jika_tidak {
        jika (pilihan == "2") {
            var hasil_k = celsius_ke_kelvin(suhu_input)
            tulis(ke_teks(suhu_input) + "°C = " + ke_teks(hasil_k) + "K")
        } jika_tidak {
            jika (pilihan == "3") {
                var hasil_c = fahrenheit_ke_celsius(suhu_input)
                tulis(ke_teks(suhu_input) + "°F = " + ke_teks(hasil_c) + "°C")
            }
        }
    }
}


// ============================================================================
// AKHIR REFERENSI LENGKAP
// ============================================================================

tulis("")
tulis("========================================")
tulis("REFERENSI LENGKAP CASTLESCRIPT")
tulis("Bahasa Pemrograman Indonesia")
tulis("========================================")
tulis("")
tulis("File ini berisi SEMUA sintaks, fungsi,")
tulis("variabel, operator, dan contoh lengkap")
tulis("untuk bahasa pemrograman CastleScript.")
tulis("")
tulis("Selamat belajar! 🇮🇩")
tulis("========================================")
