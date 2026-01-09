// ============================================================================
// TEST ARRAYS - Testing semua fitur array
// ============================================================================

tulis("=== TEST ARRAYS ===")
tulis("")

// Membuat array
var angka = [1, 2, 3, 4, 5]
tulis("Array angka: " + ke_teks(angka))
tulis("Panjang: " + ke_teks(panjang(angka)))

// Indexing
tulis("angka[0] = " + ke_teks(angka[0]))
tulis("angka[2] = " + ke_teks(angka[2]))

// Tambah element
tambah(angka, 6)
tambah(angka, 7)
tulis("Setelah ditambah: " + ke_teks(angka))

// Gabung arrays
var angka2 = [8, 9, 10]
var semua = gabung(angka, angka2)
tulis("Gabungan: " + ke_teks(semua))

// Irisan
var sebagian = irisan(semua, 2, 5)
tulis("Irisan[2:5]: " + ke_teks(sebagian))

// Balik dan urutkan
var acak = [5, 2, 8, 1, 9, 3]
tulis("Array acak: " + ke_teks(acak))
tulis("Diurutkan: " + ke_teks(urutkan(acak)))
tulis("Dibalik: " + ke_teks(balik(acak)))

tulis("")
tulis("=== TEST STRING METHODS ===")
tulis("")

// String operations
var teks = "Halo Dunia"
tulis("Teks: " + teks)
tulis("Huruf besar: " + huruf_besar(teks))
tulis("Huruf kecil: " + huruf_kecil(teks))
tulis("Potong[0:4]: " + potong(teks, 0, 4))

// Split dan join
var kata = pisah(teks, " ")
tulis("Pisah: " + ke_teks(kata))
tulis("Gabung: " + gabung_teks(kata, "-"))

// Replace dan contains
tulis("Ganti 'Dunia' dengan 'World': " + ganti(teks, "Dunia", "World"))
tulis("Mengandung 'Halo': " + ke_teks(mengandung(teks, "Halo")))

tulis("")
tulis("=== TEST MATH FUNCTIONS ===")
tulis("")

// Math operations
tulis("Akar 16: " + ke_teks(akar(16)))
tulis("Pangkat(2, 3): " + ke_teks(pangkat(2, 3)))
tulis("Absolut(-5): " + ke_teks(absolut(-5)))
tulis("Bulatkan(3.7): " + ke_teks(bulatkan(3.7)))
tulis("Lantai(3.7): " + ke_teks(lantai(3.7)))
tulis("Langit(3.2): " + ke_teks(langit(3.2)))
tulis("Minimal(5, 3, 8): " + ke_teks(minimal(5, 3, 8)))
tulis("Maksimal(5, 3, 8): " + ke_teks(maksimal(5, 3, 8)))
tulis("Random: " + ke_teks(angka_acak()))
tulis("Random 1-10: " + ke_teks(acak_antara(1, 10)))

tulis("")
tulis("=== TEST OBJECTS ===")
tulis("")

// Objects
var orang = {
    nama: "Budi",
    umur: 25,
    kota: "Jakarta"
}
tulis("Object: " + ke_teks(orang))
tulis("Nama: " + orang["nama"])
tulis("Umur: " + ke_teks(orang["umur"]))

tulis("")
tulis("✅ Semua test selesai!")
