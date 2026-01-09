// ============================================================================
// KALKULATOR CASTLESCRIPT
// Versi Terminal dengan Bahasa Indonesia
// ============================================================================

tulis("╔════════════════════════════════════════╗")
tulis("║     KALKULATOR CASTLESCRIPT 🏰        ║")
tulis("║   Bahasa Pemrograman Indonesia 🇮🇩     ║")
tulis("╚════════════════════════════════════════╝")
tulis("")

// Fungsi-fungsi kalkulator
fungsi tambah(a, b) {
    kembalikan a + b
}

fungsi kurang(a, b) {
    kembalikan a - b
}

fungsi kali(a, b) {
    kembalikan a * b
}

fungsi bagi(a, b) {
    jika (b == 0) {
        tulis("Error: Tidak bisa membagi dengan 0!")
        kembalikan 0
    }
    kembalikan a / b
}

fungsi modulo(a, b) {
    jika (b == 0) {
        tulis("Error: Tidak bisa modulo dengan 0!")
        kembalikan 0
    }
    kembalikan a % b
}

fungsi pangkat(a, b) {
    var hasil = 1
    var i = 0
    selama (i < b) {
        hasil = hasil * a
        i = i + 1
    }
    kembalikan hasil
}

fungsi akar_kuadrat(a) {
    jika (a < 0) {
        tulis("Error: Tidak bisa akar dari bilangan negatif!")
        kembalikan 0
    }
    
    // Metode Newton untuk akar kuadrat
    var tebakan = a / 2
    var presisi = 0.00001
    var iterasi = 0
    
    selama (iterasi < 100) {
        var tebakan_baru = (tebakan + a / tebakan) / 2
        var selisih = tebakan - tebakan_baru
        
        jika (selisih < 0) {
            selisih = -selisih
        }
        
        jika (selisih < presisi) {
            kembalikan tebakan_baru
        }
        
        tebakan = tebakan_baru
        iterasi = iterasi + 1
    }
    
    kembalikan tebakan
}

fungsi persentase(nilai, persen) {
    kembalikan nilai * persen / 100
}

fungsi faktorial(n) {
    jika (n < 0) {
        tulis("Error: Faktorial tidak terdefinisi untuk bilangan negatif!")
        kembalikan 0
    }
    
    jika (n == 0 atau n == 1) {
        kembalikan 1
    }
    
    var hasil = 1
    var i = 2
    selama (i <= n) {
        hasil = hasil * i
        i = i + 1
    }
    
    kembalikan hasil
}

// Fungsi menu utama
fungsi tampilkan_menu() {
    tulis("")
    tulis("┌────────────────────────────────────────┐")
    tulis("│         OPERASI KALKULATOR             │")
    tulis("├────────────────────────────────────────┤")
    tulis("│ 1. Penjumlahan      (+)                │")
    tulis("│ 2. Pengurangan      (-)                │")
    tulis("│ 3. Perkalian        (×)                │")
    tulis("│ 4. Pembagian        (÷)                │")
    tulis("│ 5. Modulo           (%)                │")
    tulis("│ 6. Pangkat          (^)                │")
    tulis("│ 7. Akar Kuadrat     (√)                │")
    tulis("│ 8. Persentase       (%)                │")
    tulis("│ 9. Faktorial        (!)                │")
    tulis("│ 0. Keluar                              │")
    tulis("└────────────────────────────────────────┘")
}

// Fungsi untuk menjalankan kalkulator
fungsi jalankan_kalkulator() {
    var lanjut = benar
    
    selama (lanjut) {
        tampilkan_menu()
        tulis("")
        
        var pilihan = baca("Pilih operasi (0-9): ")
        
        jika (pilihan == "0") {
            tulis("")
            tulis("╔════════════════════════════════════════╗")
            tulis("║  Terima kasih telah menggunakan       ║")
            tulis("║     KALKULATOR CASTLESCRIPT!            ║")
            tulis("╚════════════════════════════════════════╝")
            lanjut = salah
        } jika_tidak {
            jika (pilihan == "1") {
                tulis("")
                tulis("─── PENJUMLAHAN ───")
                var angka1 = ke_angka(baca("Angka pertama: "))
                var angka2 = ke_angka(baca("Angka kedua: "))
                var hasil = tambah(angka1, angka2)
                tulis("")
                tulis("┌─────────────────────────────┐")
                tulis("│ Hasil: " + ke_teks(angka1) + " + " + ke_teks(angka2) + " = " + ke_teks(hasil))
                tulis("└─────────────────────────────┘")
            } jika_tidak {
                jika (pilihan == "2") {
                    tulis("")
                    tulis("─── PENGURANGAN ───")
                    var angka1 = ke_angka(baca("Angka pertama: "))
                    var angka2 = ke_angka(baca("Angka kedua: "))
                    var hasil = kurang(angka1, angka2)
                    tulis("")
                    tulis("┌─────────────────────────────┐")
                    tulis("│ Hasil: " + ke_teks(angka1) + " - " + ke_teks(angka2) + " = " + ke_teks(hasil))
                    tulis("└─────────────────────────────┘")
                } jika_tidak {
                    jika (pilihan == "3") {
                        tulis("")
                        tulis("─── PERKALIAN ───")
                        var angka1 = ke_angka(baca("Angka pertama: "))
                        var angka2 = ke_angka(baca("Angka kedua: "))
                        var hasil = kali(angka1, angka2)
                        tulis("")
                        tulis("┌─────────────────────────────┐")
                        tulis("│ Hasil: " + ke_teks(angka1) + " × " + ke_teks(angka2) + " = " + ke_teks(hasil))
                        tulis("└─────────────────────────────┘")
                    } jika_tidak {
                        jika (pilihan == "4") {
                            tulis("")
                            tulis("─── PEMBAGIAN ───")
                            var angka1 = ke_angka(baca("Angka pembilang: "))
                            var angka2 = ke_angka(baca("Angka penyebut: "))
                            var hasil = bagi(angka1, angka2)
                            jika (angka2 != 0) {
                                tulis("")
                                tulis("┌─────────────────────────────┐")
                                tulis("│ Hasil: " + ke_teks(angka1) + " ÷ " + ke_teks(angka2) + " = " + ke_teks(hasil))
                                tulis("└─────────────────────────────┘")
                            }
                        } jika_tidak {
                            jika (pilihan == "5") {
                                tulis("")
                                tulis("─── MODULO ───")
                                var angka1 = ke_angka(baca("Angka pertama: "))
                                var angka2 = ke_angka(baca("Angka kedua: "))
                                var hasil = modulo(angka1, angka2)
                                jika (angka2 != 0) {
                                    tulis("")
                                    tulis("┌─────────────────────────────┐")
                                    tulis("│ Hasil: " + ke_teks(angka1) + " % " + ke_teks(angka2) + " = " + ke_teks(hasil))
                                    tulis("└─────────────────────────────┘")
                                }
                            } jika_tidak {
                                jika (pilihan == "6") {
                                    tulis("")
                                    tulis("─── PANGKAT ───")
                                    var basis = ke_angka(baca("Bilangan basis: "))
                                    var eksponen = ke_angka(baca("Eksponen: "))
                                    var hasil = pangkat(basis, eksponen)
                                    tulis("")
                                    tulis("┌─────────────────────────────┐")
                                    tulis("│ Hasil: " + ke_teks(basis) + "^" + ke_teks(eksponen) + " = " + ke_teks(hasil))
                                    tulis("└─────────────────────────────┘")
                                } jika_tidak {
                                    jika (pilihan == "7") {
                                        tulis("")
                                        tulis("─── AKAR KUADRAT ───")
                                        var angka = ke_angka(baca("Masukkan angka: "))
                                        var hasil = akar_kuadrat(angka)
                                        jika (angka >= 0) {
                                            tulis("")
                                            tulis("┌─────────────────────────────┐")
                                            tulis("│ Hasil: √" + ke_teks(angka) + " = " + ke_teks(hasil))
                                            tulis("└─────────────────────────────┘")
                                        }
                                    } jika_tidak {
                                        jika (pilihan == "8") {
                                            tulis("")
                                            tulis("─── PERSENTASE ───")
                                            var nilai = ke_angka(baca("Nilai: "))
                                            var persen = ke_angka(baca("Persentase: "))
                                            var hasil = persentase(nilai, persen)
                                            tulis("")
                                            tulis("┌─────────────────────────────┐")
                                            tulis("│ Hasil: " + ke_teks(persen) + "% dari " + ke_teks(nilai) + " = " + ke_teks(hasil))
                                            tulis("└─────────────────────────────┘")
                                        } jika_tidak {
                                            jika (pilihan == "9") {
                                                tulis("")
                                                tulis("─── FAKTORIAL ───")
                                                var angka = ke_angka(baca("Masukkan angka: "))
                                                var hasil = faktorial(angka)
                                                jika (angka >= 0) {
                                                    tulis("")
                                                    tulis("┌─────────────────────────────┐")
                                                    tulis("│ Hasil: " + ke_teks(angka) + "! = " + ke_teks(hasil))
                                                    tulis("└─────────────────────────────┘")
                                                }
                                            } jika_tidak {
                                                tulis("")
                                                tulis("❌ Pilihan tidak valid!")
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        tulis("")
        var input_lanjut = baca("Tekan Enter untuk melanjutkan...")
    }
}

// Jalankan kalkulator
jalankan_kalkulator()
