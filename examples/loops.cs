// Contoh Loop dalam CastleScript
// File: loops.cs

tulis("=== Contoh Perulangan ===")
tulis("")

// Loop dengan 'ulangi' (for loop)
tulis("1. Loop dengan 'ulangi':")
ulangi (var i = 1; i <= 5; i = i + 1) {
    tulis("Iterasi ke-")
    tulis(i)
}

tulis("")

// Loop dengan 'selama' (while loop)
tulis("2. Loop dengan 'selama':")
var counter = 1
selama (counter <= 5) {
    tulis("Counter: ")
    tulis(counter)
    counter = counter + 1
}

tulis("")

// Membuat pola bintang
tulis("3. Pola Bintang:")
var baris = 1
selama (baris <= 5) {
    var kolom = 1
    selama (kolom <= baris) {
        tulis("* ")
        kolom = kolom + 1
    }
    tulis("")
    baris = baris + 1
}
