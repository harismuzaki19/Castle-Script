// ============================================================================
// KALKULATOR GUI - PIXEL-PERFECT LAYOUT
// Menggunakan ukuran pixel eksplisit untuk layout yang rapi
// ============================================================================

tulis(" Memulai Kalkulator CastleScript...")
tulis("")

// Buat jendela
buat_jendela("Kalkulator CastleScript", 340, 520)
atur_warna_latar("#2c3e50")

// Header
var label_title = buat_label("KALKULATOR", 100, 15, 16, "#ecf0f1", "#2c3e50")
var label_sub = buat_label("By Code CastleScript", 120, 45, 10, "#95a5a6", "#2c3e50")

// Display - dipendekkan dan diratakan
var input_display = buat_input(20, 75, 22, 18)
atur_nilai_input(input_display, "0")

// State variables
var angka_pertama = 0
var operator = ""
var reset_tampilan = salah

fungsi update_tampilan(nilai) {
    atur_nilai_input(input_display, nilai)
}

fungsi tekan_angka(angka) {
    var tampilan_sekarang = ambil_nilai_input(input_display)
    jika (reset_tampilan) {
        update_tampilan(ke_teks(angka))
        reset_tampilan = salah
    } jika_tidak {
        jika (tampilan_sekarang == "0") {
            update_tampilan(ke_teks(angka))
        } jika_tidak {
            update_tampilan(tampilan_sekarang + ke_teks(angka))
        }
    }
}

fungsi tekan_operator(op) {
    var tampilan_sekarang = ambil_nilai_input(input_display)
    angka_pertama = ke_angka(tampilan_sekarang)
    operator = op
    reset_tampilan = benar
}

fungsi tekan_sama_dengan() {
    jika (operator != "") {
        var tampilan_sekarang = ambil_nilai_input(input_display)
        var angka_kedua = ke_angka(tampilan_sekarang)
        var hasil = 0
        
        jika (operator == "+") {
            hasil = angka_pertama + angka_kedua
        } jika_tidak {
            jika (operator == "-") {
                hasil = angka_pertama - angka_kedua
            } jika_tidak {
                jika (operator == "*") {
                    hasil = angka_pertama * angka_kedua
                } jika_tidak {
                    jika (operator == "/") {
                        jika (angka_kedua == 0) {
                            tampilkan_error("Error", "Tidak bisa membagi dengan 0!")
                            update_tampilan("0")
                            operator = ""
                            kembalikan 0
                        }
                        hasil = angka_pertama / angka_kedua
                    }
                }
            }
        }
        
        update_tampilan(ke_teks(hasil))
        operator = ""
        reset_tampilan = benar
    }
}

fungsi tekan_clear() {
    update_tampilan("0")
    angka_pertama = 0
    operator = ""
    reset_tampilan = salah
}

fungsi tekan_hapus() {
    update_tampilan("0")
}

fungsi tekan_desimal() {
    var tampilan_sekarang = ambil_nilai_input(input_display)
    update_tampilan(tampilan_sekarang + ".")
}

// Button callbacks
fungsi tombol_0() { tekan_angka(0) }
fungsi tombol_1() { tekan_angka(1) }
fungsi tombol_2() { tekan_angka(2) }
fungsi tombol_3() { tekan_angka(3) }
fungsi tombol_4() { tekan_angka(4) }
fungsi tombol_5() { tekan_angka(5) }
fungsi tombol_6() { tekan_angka(6) }
fungsi tombol_7() { tekan_angka(7) }
fungsi tombol_8() { tekan_angka(8) }
fungsi tombol_9() { tekan_angka(9) }
fungsi tombol_tambah() { tekan_operator("+") }
fungsi tombol_kurang() { tekan_operator("-") }
fungsi tombol_kali() { tekan_operator("*") }
fungsi tombol_bagi() { tekan_operator("/") }

// ============================================================================
// LAYOUT PIXEL-PERFECT - Ukuran dalam pixel
// ============================================================================

// Ukuran tombol (PIXEL)
var btn_w = 70
var btn_h = 50

// Posisi kolom
var col1 = 20
var col2 = 95
var col3 = 170
var col4 = 245

// Posisi baris
var row1 = 135
var row2 = 190
var row3 = 245
var row4 = 300
var row5 = 355

// Warna
var c_num = "#34495e"
var c_op = "#e67e22"
var c_del = "#c0392b"
var c_eq = "#27ae60"

// Row 1: C DEL / ×
buat_tombol("C", tekan_clear, col1, row1, btn_w, btn_h, c_del, "white", 13)
buat_tombol("DEL", tekan_hapus, col2, row1, btn_w, btn_h, c_del, "white", 11)
buat_tombol("/", tombol_bagi, col3, row1, btn_w, btn_h, c_op, "white", 15)
buat_tombol("×", tombol_kali, col4, row1, btn_w, btn_h, c_op, "white", 15)

// Row 2: 7 8 9 −
buat_tombol("7", tombol_7, col1, row2, btn_w, btn_h, c_num, "white", 15)
buat_tombol("8", tombol_8, col2, row2, btn_w, btn_h, c_num, "white", 15)
buat_tombol("9", tombol_9, col3, row2, btn_w, btn_h, c_num, "white", 15)
buat_tombol("−", tombol_kurang, col4, row2, btn_w, btn_h, c_op, "white", 15)

// Row 3: 4 5 6 +
buat_tombol("4", tombol_4, col1, row3, btn_w, btn_h, c_num, "white", 15)
buat_tombol("5", tombol_5, col2, row3, btn_w, btn_h, c_num, "white", 15)
buat_tombol("6", tombol_6, col3, row3, btn_w, btn_h, c_num, "white", 15)
buat_tombol("+", tombol_tambah, col4, row3, btn_w, btn_h, c_op, "white", 15)

// Row 4: 1 2 3 = (equal lebih tinggi)
buat_tombol("1", tombol_1, col1, row4, btn_w, btn_h, c_num, "white", 15)
buat_tombol("2", tombol_2, col2, row4, btn_w, btn_h, c_num, "white", 15)
buat_tombol("3", tombol_3, col3, row4, btn_w, btn_h, c_num, "white", 15)
buat_tombol("=", tekan_sama_dengan, col4, row4, btn_w, 105, c_eq, "white", 18)

// Row 5: 0 .
buat_tombol("0", tombol_0, col1, row5, btn_w, btn_h, c_num, "white", 15)
buat_tombol(".", tekan_desimal, col2, row5, btn_w, btn_h, c_num, "white", 15)

// Footer
buat_label("Bahasa Indonesia", 110, 440, 9, "#95a5a6", "#2c3e50")
buat_label("CastleScript v1.0", 110, 465, 8, "#7f8c8d", "#2c3e50")

tulis("✅ Kalkulator pixel-perfect siap!")
tulis("")

jalankan()
