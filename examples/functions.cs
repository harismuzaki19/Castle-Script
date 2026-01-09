// Contoh Fungsi dalam CastleScript
// File: functions.cs

// Fungsi menghitung faktorial
fungsi faktorial(n) {
    jika (n <= 1) {
        kembalikan 1
    }
    kembalikan n * faktorial(n - 1)
}

// Fungsi menyapa
fungsi salam(nama) {
    kembalikan "Halo, " + nama + "!"
}

// Fungsi cek bilangan genap
fungsi adalah_genap(angka) {
    kembalikan angka % 2 == 0
}

// Main program
tulis("=== Contoh Penggunaan Fungsi ===")
tulis("")

var nama = baca("Siapa nama Anda? ")
tulis(salam(nama))
tulis("")

var angka = ke_angka(baca("Masukkan sebuah angka: "))

tulis("Faktorial dari ")
tulis(angka)
tulis(" adalah: ")
tulis(faktorial(angka))

jika (adalah_genap(angka)) {
    tulis(angka)
    tulis(" adalah bilangan genap")
} jika_tidak {
    tulis(angka)
    tulis(" adalah bilangan ganjil")
}
