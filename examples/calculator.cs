// Kalkulator Interaktif
// File: calculator.cs

tulis("=== Kalkulator CastleScript ===")
tulis("")

var angka1 = ke_angka(baca("Masukkan angka pertama: "))
var angka2 = ke_angka(baca("Masukkan angka kedua: "))

tulis("")
tulis("Hasil Operasi:")
tulis("Penjumlahan: ")
tulis(angka1 + angka2)

tulis("Pengurangan: ")
tulis(angka1 - angka2)

tulis("Perkalian: ")
tulis(angka1 * angka2)

jika (angka2 != 0) {
    tulis("Pembagian: ")
    tulis(angka1 / angka2)
} jika_tidak {
    tulis("Pembagian: Tidak bisa dibagi dengan 0")
}

tulis("Modulo: ")
tulis(angka1 % angka2)
