// Program Fibonacci
// File: fibonacci.cs

tulis("=== Deret Fibonacci ===")
tulis("")

var n = ke_angka(baca("Berapa angka Fibonacci yang ingin ditampilkan? "))

tulis("")
tulis("Deret Fibonacci:")

var a = 0
var b = 1

jika (n >= 1) {
    tulis(a)
    tulis(" ")
}

jika (n >= 2) {
    tulis(b)
    tulis(" ")
}

var i = 3
selama (i <= n) {
    var c = a + b
    tulis(c)
    tulis(" ")
    
    a = b
    b = c
    i = i + 1
}

tulisln("")
