// Game Catur (Chess) vs Computer
// Menggunakan CastleScript GUI

// Konfigurasi Papan
var ukuran_kotak = 60
var margin = 20
var ukuran_papan = ukuran_kotak * 8
var warna_terang = "#F0D9B5"
var warna_gelap = "#B58863"
var warna_highlight = "#7B61FF"
var warna_pilih = "#5422D6"

// Status Game
var giliran_putih = benar
var terpilih = kosong
var langkah_legal = []
var papan = []
var game_selesai = salah
var pesan_status = "Giliran: Putih"

// Tracking untuk Castling (Rokade)
var raja_putih_sudah_jalan = salah
var raja_hitam_sudah_jalan = salah
var benteng_putih_kiri_sudah_jalan = salah
var benteng_putih_kanan_sudah_jalan = salah
var benteng_hitam_kiri_sudah_jalan = salah
var benteng_hitam_kanan_sudah_jalan = salah

// Online Mode Variables
var mode_game = "menu" // "menu", "ai", "local", "online_host", "online_join"
var koneksi_online = kosong
var server_online = kosong
var warna_online_saya = "" // "putih" atau "hitam"
var menunggu_lawan = salah
var tunnel_url_global = "" // Store tunnel URL for clipboard access

// Representasi Bidak
// P = Pawn (Pion), R = Rook (Benteng), N = Knight (Kuda), B = Bishop (Gajah)
// Q = Queen (Menteri), K = King (Raja)
// Huruf besar = Putih, Huruf kecil = Hitam, "." = Kosong
var bidak_unicode = {
    "K": "♔", "Q": "♕", "R": "♖", "B": "♗", "N": "♘", "P": "♙",
    "k": "♚", "q": "♛", "r": "♜", "b": "♝", "n": "♞", "p": "♟",
    ".": ""
}

// GUI IDs
var id_jendela = "jendela_catur"
var id_canvas = "canvas_papan"
var id_label_status = "status_game"

// Inisialisasi Papan Catur
fungsi init_papan() {
    papan = []
    tambah(papan, ["r", "n", "b", "q", "k", "b", "n", "r"])
    tambah(papan, ["p", "p", "p", "p", "p", "p", "p", "p"])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, [".", ".", ".", ".", ".", ".", ".", "."])
    tambah(papan, ["P", "P", "P", "P", "P", "P", "P", "P"])
    tambah(papan, ["R", "N", "B", "Q", "K", "B", "N", "R"])
}

// Menggambar Papan dan Bidak
fungsi gambar_papan() {
    // Bersihkan canvas dengan menggambar ulang
    bersihkan_kanvas(id_canvas)
    
    // Determine if board should be flipped (Black at bottom)
    var flip_board = salah
    jika (mode_game == "online_join" dan warna_online_saya == "hitam") {
        flip_board = benar
    }
    
    // Gambar kotak-kotak papan
    var b = 0
    var k = 0
    ulangi (b = 0; b < 8; b = b + 1) {
        ulangi (k = 0; k < 8; k = k + 1) {
            // Calculate display coordinates (flip if needed)
            var display_b = b
            var display_k = k
            jika (flip_board) {
                display_b = 7 - b
                display_k = 7 - k
            }
            
            var x1 = display_k * ukuran_kotak
            var y1 = display_b * ukuran_kotak
            var x2 = x1 + ukuran_kotak
            var y2 = y1 + ukuran_kotak
            
            var warna = warna_terang
            jika ((b + k) % 2 == 1) {
                warna = warna_gelap
            }
            
            // Highlight kotak terpilih
            jika (terpilih != kosong) {
                jika (terpilih.baris == b dan terpilih.kolom == k) {
                    warna = warna_pilih
                }
            }
            
            // Highlight langkah legal
            var i = 0
            ulangi (i = 0; i < panjang(langkah_legal); i = i + 1) {
                var langkah = langkah_legal[i]
                jika (langkah.baris == b dan langkah.kolom == k) {
                    // Beri tint ungu
                    jika ((b + k) % 2 == 1) {
                        warna = "#7D5BA6" // Gelap + highlight
                    } jika_tidak {
                        warna = "#A884D6" // Terang + highlight
                    }
                }
            }
            
            gambar_persegi(id_canvas, x1, y1, x2, y2, warna)
            
            // Gambar bidak
            var bidak = papan[b][k]
            jika (bidak != ".") {
                var warna_teks = "black"
                
                var simbol = ""
                // Putih
                jika (bidak == "K") { simbol = "♔" }
                jika (bidak == "Q") { simbol = "♕" }
                jika (bidak == "R") { simbol = "♖" }
                jika (bidak == "B") { simbol = "♗" }
                jika (bidak == "N") { simbol = "♘" }
                jika (bidak == "P") { simbol = "♙" }
                
                // Hitam
                jika (bidak == "k") { simbol = "♚" }
                jika (bidak == "q") { simbol = "♛" }
                jika (bidak == "r") { simbol = "♜" }
                jika (bidak == "b") { simbol = "♝" }
                jika (bidak == "n") { simbol = "♞" }
                jika (bidak == "p") { simbol = "♟" }
                
                var cx = x1 + (ukuran_kotak / 2)
                var cy = y1 + (ukuran_kotak / 2)
                
                gambar_teks(id_canvas, cx, cy, simbol, "black", 32)
            }
        }
    }
}

fungsi adalah_huruf_besar(huruf) {
    kembalikan huruf == huruf_besar(huruf)
}




// Cek apakah suatu kotak diserang oleh pemain tertentu
fungsi kotak_diserang(baris_target, kolom_target, oleh_putih) {
    // Iterasi semua bidak lawan
    var check_b = 0
    var check_k = 0
    ulangi (check_b = 0; check_b < 8; check_b = check_b + 1) {
        ulangi (check_k = 0; check_k < 8; check_k = check_k + 1) {
            var bidak_musuh = papan[check_b][check_k]
            jika (bidak_musuh == ".") { lanjut }
            
            // Cek apakah ini bidak dari pihak yang benar
            var is_bidak_putih = adalah_huruf_besar(bidak_musuh)
            jika (is_bidak_putih != oleh_putih) { lanjut }
            
            var tipe_musuh = huruf_kecil(bidak_musuh)
            
            // Cek berdasarkan jenis bidak
            // Pawn - cek diagonal attack saja (bukan forward move)
            jika (tipe_musuh == "p") {
                var arah_pawn = -1
                jika (tidak oleh_putih) { arah_pawn = 1 }
                var b_attack = check_b + arah_pawn
                jika (b_attack == baris_target) {
                    jika (check_k - 1 == kolom_target atau check_k + 1 == kolom_target) {
                        kembalikan benar
                    }
                }
            }
            
            // Knight - cek L-shape
            jika (tipe_musuh == "n") {
                var db = baris_target - check_b
                var dk = kolom_target - check_k
                jika ((db == -2 atau db == 2) dan (dk == -1 atau dk == 1)) { kembalikan benar }
                jika ((db == -1 atau db == 1) dan (dk == -2 atau dk == 2)) { kembalikan benar }
            }
            
            // King - cek adjacent (1 square)
            jika (tipe_musuh == "k") {
                var db = baris_target - check_b
                var dk = kolom_target - check_k
                jika (db >= -1 dan db <= 1 dan dk >= -1 dan dk <= 1) {
                    jika (db != 0 atau dk != 0) { kembalikan benar }
                }
            }
            
            // Rook/Queen - cek garis lurus
            jika (tipe_musuh == "r" atau tipe_musuh == "q") {
                jika (check_b == baris_target atau check_k == kolom_target) {
                    // Cek apakah ada penghalang
                    var ada_penghalang = salah
                    var step_b = 0
                    var step_k = 0
                    jika (baris_target > check_b) { step_b = 1 }
                    jika (baris_target < check_b) { step_b = -1 }
                    jika (kolom_target > check_k) { step_k = 1 }
                    jika (kolom_target < check_k) { step_k = -1 }
                    
                    var scan_b = check_b + step_b
                    var scan_k = check_k + step_k
                    selama (scan_b != baris_target atau scan_k != kolom_target) {
                        jika (papan[scan_b][scan_k] != ".") {
                            ada_penghalang = benar
                            henti
                        }
                        scan_b = scan_b + step_b
                        scan_k = scan_k + step_k
                    }
                    
                    jika (tidak ada_penghalang) { kembalikan benar }
                }
            }
            
            // Bishop/Queen - cek diagonal
            jika (tipe_musuh == "b" atau tipe_musuh == "q") {
                var db = baris_target - check_b
                var dk = kolom_target - check_k
                jika (db == dk atau db == -dk) {
                    // Cek apakah ada penghalang
                    var ada_penghalang = salah
                    var step_b = 0
                    var step_k = 0
                    jika (baris_target > check_b) { step_b = 1 } jika_tidak { step_b = -1 }
                    jika (kolom_target > check_k) { step_k = 1 } jika_tidak { step_k = -1 }
                    
                    var scan_b = check_b + step_b
                    var scan_k = check_k + step_k
                    selama (scan_b != baris_target atau scan_k != kolom_target) {
                        jika (papan[scan_b][scan_k] != ".") {
                            ada_penghalang = benar
                            henti
                        }
                        scan_b = scan_b + step_b
                        scan_k = scan_k + step_k
                    }
                    
                    jika (tidak ada_penghalang) { kembalikan benar }
                }
            }
        }
    }
    kembalikan salah
}

// Logika Catur
fungsi dapatkan_langkah_legal(baris, kolom) {
    var bidak = papan[baris][kolom]
    var langkah = []
    
    jika (bidak == ".") { kembalikan [] }
    
    var is_putih = adalah_huruf_besar(bidak)
    var arah = -1 // Putih jalan ke atas (index berkurang)
    jika (tidak is_putih) { arah = 1 } // Hitam jalan ke bawah
    
    var tipe = huruf_kecil(bidak)
    
    // Logika Pion
    jika (tipe == "p") {
        // Maju 1 langkah
        var b_depan = baris + arah
        jika (b_depan >= 0 dan b_depan < 8) {
            jika (papan[b_depan][kolom] == ".") {
                tambah(langkah, {baris: b_depan, kolom: kolom})
                
                // Maju 2 langkah dari posisi awal
                var posisi_awal = 6
                jika (tidak is_putih) { posisi_awal = 1 }
                
                jika (baris == posisi_awal) {
                    var b_depan2 = baris + (arah * 2)
                    jika (papan[b_depan2][kolom] == ".") {
                        tambah(langkah, {baris: b_depan2, kolom: kolom})
                    }
                }
            }
        }
        
        // Makan lawan (diagonal)
        var offset_kolom = []
        tambah(offset_kolom, -1)
        tambah(offset_kolom, 1)
        var i = 0
        ulangi (i = 0; i < 2; i = i + 1) {
            var k_target = kolom + offset_kolom[i]
            var b_target = baris + arah
            
            jika (k_target >= 0 dan k_target < 8 dan b_target >= 0 dan b_target < 8) {
                var target = papan[b_target][k_target]
                jika (target != ".") {
                    var is_lawan = salah
                    jika (is_putih dan tidak adalah_huruf_besar(target)) { is_lawan = benar }
                    jika (tidak is_putih dan adalah_huruf_besar(target)) { is_lawan = benar }
                    
                    jika (is_lawan) {
                        tambah(langkah, {baris: b_target, kolom: k_target})
                    }
                }
            }
        }
    } 
    // Logika Kuda (Knight)
    jika (tipe == "n") {
        var moves = [[-2, -1], [-2, 1], [-1, -2], [-1, 2], [1, -2], [1, 2], [2, -1], [2, 1]]
        var i = 0
        ulangi (i = 0; i < 8; i = i + 1) {
            var b_target = baris + moves[i][0]
            var k_target = kolom + moves[i][1]
            tambah_jika_legal(langkah, b_target, k_target, is_putih)
        }
    }
    // Logika Raja (King)
    jika (tipe == "k") {
        var moves = [[-1, -1], [-1, 0], [-1, 1], [0, -1], [0, 1], [1, -1], [1, 0], [1, 1]]
        var i = 0
        ulangi (i = 0; i < 8; i = i + 1) {
            var b_target = baris + moves[i][0]
            var k_target = kolom + moves[i][1]
            
            // Cek bounds dan apakah kotak legal
            jika (b_target >= 0 dan b_target < 8 dan k_target >= 0 dan k_target < 8) {
                var target = papan[b_target][k_target]
                var boleh_jalan = salah
                
                jika (target == ".") {
                    boleh_jalan = benar
                } jika_tidak {
                    // Cek apakah lawan
                    var is_lawan = salah
                    jika (is_putih dan tidak adalah_huruf_besar(target)) { is_lawan = benar }
                    jika (tidak is_putih dan adalah_huruf_besar(target)) { is_lawan = benar }
                    
                    jika (is_lawan) {
                        boleh_jalan = benar
                    }
                }
                
                // SAFETY CHECK: Jangan jalan ke kotak yang diserang lawan
                jika (boleh_jalan) {
                    var diserang_oleh_lawan = kotak_diserang(b_target, k_target, tidak is_putih)
                    jika (tidak diserang_oleh_lawan) {
                        tambah(langkah, {baris: b_target, kolom: k_target})
                    }
                }
            }
        }
        
        // CASTLING (ROKADE)
        var raja_belum_jalan = salah
        jika (is_putih dan tidak raja_putih_sudah_jalan) { raja_belum_jalan = benar }
        jika (tidak is_putih dan tidak raja_hitam_sudah_jalan) { raja_belum_jalan = benar }
        
        jika (raja_belum_jalan) {
            // Cek apakah king dalam skak sekarang
            var raja_diserang = kotak_diserang(baris, kolom, tidak is_putih)
            jika (tidak raja_diserang) {
                // Kingside Castling (O-O) - ke kanan
                var benteng_kanan_ok = salah
                jika (is_putih dan tidak benteng_putih_kanan_sudah_jalan) { benteng_kanan_ok = benar }
                jika (tidak is_putih dan tidak benteng_hitam_kanan_sudah_jalan) { benteng_kanan_ok = benar }
                
                jika (benteng_kanan_ok) {
                    // Cek path kosong (f dan g untuk putih)
                    jika (papan[baris][kolom+1] == "." dan papan[baris][kolom+2] == ".") {
                        // Cek tidak melewati kotak diserang
                        var aman1 = tidak kotak_diserang(baris, kolom+1, tidak is_putih)
                        var aman2 = tidak kotak_diserang(baris, kolom+2, tidak is_putih)
                        jika (aman1 dan aman2) {
                            tambah(langkah, {baris: baris, kolom: kolom+2})
                        }
                    }
                }
                
                // Queenside Castling (O-O-O) - ke kiri
                var benteng_kiri_ok = salah
                jika (is_putih dan tidak benteng_putih_kiri_sudah_jalan) { benteng_kiri_ok = benar }
                jika (tidak is_putih dan tidak benteng_hitam_kiri_sudah_jalan) { benteng_kiri_ok = benar }
                
                jika (benteng_kiri_ok) {
                    // Cek path kosong (b, c, d untuk putih)
                    jika (papan[baris][kolom-1] == "." dan papan[baris][kolom-2] == "." dan papan[baris][kolom-3] == ".") {
                        // Cek tidak melewati kotak diserang (hanya cek d dan c, b tidak masalah)
                        var aman1 = tidak kotak_diserang(baris, kolom-1, tidak is_putih)
                        var aman2 = tidak kotak_diserang(baris, kolom-2, tidak is_putih)
                        jika (aman1 dan aman2) {
                            tambah(langkah, {baris: baris, kolom: kolom-2})
                        }
                    }
                }
            }
        }
    }
    // Logika Benteng (Rook)
    jika (tipe == "r") {
        tambah_langkah_garis(langkah, baris, kolom, [[-1, 0], [1, 0], [0, -1], [0, 1]], is_putih)
    }
    // Logika Gajah (Bishop)
    jika (tipe == "b") {
        tambah_langkah_garis(langkah, baris, kolom, [[-1, -1], [-1, 1], [1, -1], [1, 1]], is_putih)
    }
    // Logika Menteri (Queen)
    jika (tipe == "q") {
        var arah_semua = [[-1, 0], [1, 0], [0, -1], [0, 1], [-1, -1], [-1, 1], [1, -1], [1, 1]]
        tambah_langkah_garis(langkah, baris, kolom, arah_semua, is_putih)
    }
    
    kembalikan langkah
}

fungsi tambah_jika_legal(langkah_arr, b, k, is_putih) {
    jika (b >= 0 dan b < 8 dan k >= 0 dan k < 8) {
        var target = papan[b][k]
        jika (target == ".") {
            tambah(langkah_arr, {baris: b, kolom: k})
        } jika_tidak {
            // Cek apakah lawan
            var is_lawan = salah
            jika (is_putih dan tidak adalah_huruf_besar(target)) { is_lawan = benar }
            jika (tidak is_putih dan adalah_huruf_besar(target)) { is_lawan = benar }
            
            jika (is_lawan) {
                tambah(langkah_arr, {baris: b, kolom: k})
            }
        }
    }
}

fungsi tambah_langkah_garis(langkah_arr, b_awal, k_awal, arah_arr, is_putih) {
    var i = 0
    ulangi (i = 0; i < panjang(arah_arr); i = i + 1) {
        var db = arah_arr[i][0]
        var dk = arah_arr[i][1]
        var b = b_awal + db
        var k = k_awal + dk
        
        selama (b >= 0 dan b < 8 dan k >= 0 dan k < 8) {
            var target = papan[b][k]
            jika (target == ".") {
                tambah(langkah_arr, {baris: b, kolom: k})
            } jika_tidak {
                // Nabrak bidak
                var is_lawan = salah
                jika (is_putih dan tidak adalah_huruf_besar(target)) { is_lawan = benar }
                jika (tidak is_putih dan adalah_huruf_besar(target)) { is_lawan = benar }
                
                jika (is_lawan) {
                    tambah(langkah_arr, {baris: b, kolom: k})
                }
                henti // Stop scanning arah ini
            }
            b = b + db
            k = k + dk
        }
    }
}

// Input Handler
// Karena castlescript_gui belum punya event handler klik mouse yang proper untuk canvas,
// Kita gunakan tombol input koordinat sebagai fallback yang reliable.
// ATAU kita buat grid tombol transparan? Itu terlalu berat (64 tombol).
// Kita gunakan Input Text sederhana: "e2 e4"

fungsi proses_input() {
    var cmd = ambil_nilai_input(id_input)
    var bagian = pisah(cmd, " ")
    
    jika (panjang(bagian) != 2) {
        tampilkan_pesan("Info", "Format: e2 e4 (asal tujuan)")
        kembalikan 0
    }
    
    var asal = parse_notasi(bagian[0])
    var tujuan = parse_notasi(bagian[1])
    
    jika (asal == kosong atau tujuan == kosong) {
        tampilkan_pesan("Error", "Koordinat tidak valid")
        kembalikan 0
    }
    
    cek_dan_jalankan(asal, tujuan)
}

fungsi parse_notasi(teks) {
    jika (panjang(teks) != 2) { kembalikan kosong }
    
    var col_char = huruf_kecil(potong(teks, 0, 1))
    var row_char = potong(teks, 1, 2)
    
    var cols = "abcdefgh"
    var k = indeks(cols, col_char)
    var b = 8 - ke_angka(row_char)
    
    jika (k < 0 atau b < 0 atau b > 7) { kembalikan kosong }
    
    kembalikan {baris: b, kolom: k}
}

fungsi cek_dan_jalankan(asal, tujuan) {
    var bidak = papan[asal.baris][asal.kolom]
    
    // Validasi dasar
    jika (bidak == ".") {
        tampilkan_pesan("Error", "Kotak asal kosong!")
        kembalikan 0
    }
    
    var is_putih = adalah_huruf_besar(bidak)
    jika (is_putih != giliran_putih) {
        tampilkan_pesan("Error", "Bukan giliran Anda!")
        kembalikan 0
    }
    
    // Cek legalitas
    var legal = dapatkan_langkah_legal(asal.baris, asal.kolom)
    var is_legal = salah
    
    var is_legal = salah
    
    var i = 0
    ulangi (i = 0; i < panjang(legal); i = i + 1) {
        jika (legal[i].baris == tujuan.baris dan legal[i].kolom == tujuan.kolom) {
            is_legal = benar
            henti
        }
    }
    
    jika (is_legal) {
        jalankan_langkah(asal, tujuan)
        gambar_papan()
        
        jika (game_selesai) {
            tampilkan_pesan("Game Over", "Raja tertangkap!")
        } jika_tidak {
            // Giliran AI (only in AI mode)
            jika (mode_game == "ai" dan tidak giliran_putih) {
                status_update("Komputer berpikir...")
                atur_waktu(1000, ai_jalan)
            }
        }
    } jika_tidak {
        tampilkan_pesan("Error", "Langkah tidak legal!")
    }
}

fungsi jalankan_langkah(asal, tujuan) {
    tulis("MOVE: " + asal.baris + "," + asal.kolom + " -> " + tujuan.baris + "," + tujuan.kolom)

    var bidak = papan[asal.baris][asal.kolom]
    var target = papan[tujuan.baris][tujuan.kolom]
    
    // Cek Game Over (Raja dimakan)
    jika (huruf_kecil(target) == "k") {
        game_selesai = benar
        tampilkan_pesan("Selesai", "Permainan Berakhir!")
    }
    
    // Track piece movements untuk castling
    var tipe_bidak = huruf_kecil(bidak)
    jika (tipe_bidak == "k") {
        jika (adalah_huruf_besar(bidak)) {
            raja_putih_sudah_jalan = benar
        } jika_tidak {
            raja_hitam_sudah_jalan = benar
        }
    }
    jika (tipe_bidak == "r") {
        // Cek posisi benteng untuk track yang mana
        jika (adalah_huruf_besar(bidak)) {
            // Benteng putih
            jika (asal.baris == 7 dan asal.kolom == 0) {
                benteng_putih_kiri_sudah_jalan = benar
            }
            jika (asal.baris == 7 dan asal.kolom == 7) {
                benteng_putih_kanan_sudah_jalan = benar
            }
        } jika_tidak {
            // Benteng hitam
            jika (asal.baris == 0 dan asal.kolom == 0) {
                benteng_hitam_kiri_sudah_jalan = benar
            }
            jika (asal.baris == 0 dan asal.kolom == 7) {
                benteng_hitam_kanan_sudah_jalan = benar
            }
        }
    }
    
    // Pindahkan
    ubah(papan[tujuan.baris], tujuan.kolom, bidak)
    ubah(papan[asal.baris], asal.kolom, ".")
    
    // CASTLING (ROKADE) - Pindahkan benteng juga
    jika (tipe_bidak == "k") {
        var jarak_kolom = tujuan.kolom - asal.kolom
        // Jika Raja jalan 2 kotak, ini castling
        jika (jarak_kolom == 2) {
            // Kingside castling - benteng dari kanan (kolom 7) ke kiri Raja (kolom 5)
            var benteng_dari = asal.baris
            var benteng_kolom_asal = 7
            var benteng_kolom_tujuan = tujuan.kolom - 1
            var benteng = papan[benteng_dari][benteng_kolom_asal]
            ubah(papan[benteng_dari], benteng_kolom_tujuan, benteng)
            ubah(papan[benteng_dari], benteng_kolom_asal, ".")
            tulis("Castling Kingside!")
        } jika (jarak_kolom == -2) {
            // Queenside castling - benteng dari kiri (kolom 0) ke kanan Raja (kolom 3)
            var benteng_dari = asal.baris
            var benteng_kolom_asal = 0
            var benteng_kolom_tujuan = tujuan.kolom + 1
            var benteng = papan[benteng_dari][benteng_kolom_asal]
            ubah(papan[benteng_dari], benteng_kolom_tujuan, benteng)
            ubah(papan[benteng_dari], benteng_kolom_asal, ".")
            tulis("Castling Queenside!")
        }
    }
    
    // Promosi Pion (Otomatis jadi Queen)
    jika (huruf_kecil(bidak) == "p") {
        jika (tujuan.baris == 0 atau tujuan.baris == 7) {
            jika (adalah_huruf_besar(bidak)) {
                ubah(papan[tujuan.baris], tujuan.kolom, "Q")
            } jika_tidak {
                ubah(papan[tujuan.baris], tujuan.kolom, "q")
            }
        }
    }
    
    giliran_putih = tidak giliran_putih
    
    // ONLINE SYNC: Send move to opponent
    jika (mode_game == "online_host" atau mode_game == "online_join") {
        kirim_langkah_online(asal.baris, asal.kolom, tujuan.baris, tujuan.kolom)
    }
    
    // CEK KONDISI AKHIR GAME
    var status = cek_status_game(giliran_putih)
    
    jika (status == "checkmate") {
        game_selesai = benar
        var pemenang = "Hitam (Komputer)"
        jika (giliran_putih) {
            pemenang = "Putih (Anda)"
        } jika_tidak {
            pemenang = "Hitam (Komputer)"
        }
        // Yang menang adalah lawan dari yang giliran sekarang
        jika (giliran_putih) {
            tampilkan_pesan("GAME OVER", "SKAK MAT! Komputer Menang!")
            status_update("Komputer Menang - Skak Mat!")
        } jika_tidak {
            tampilkan_pesan("SELAMAT!", "SKAK MAT! Anda Menang!")
            status_update("Anda Menang - Skak Mat!")
        }
    } jika (status == "stalemate") {
        game_selesai = benar
        tampilkan_pesan("SERI", "Stalemate - Permainan Seri!")
        status_update("Game Berakhir - Stalemate (Seri)")
    } jika (status == "check") {
        var siapa = "Putih (Anda)"
        jika (tidak giliran_putih) { siapa = "Hitam (Komputer)" }
        status_update("SKAK! - Giliran: " + siapa)
    } jika_tidak {
        update_status_label()
    }
}

fungsi update_status_label() {
    var teks_status = ""
    
    // AI Mode
    jika (mode_game == "ai") {
        jika (giliran_putih) {
            teks_status = "Giliran: Putih (Anda)"
        } jika_tidak {
            teks_status = "Giliran: Hitam (Komputer)"
        }
    }
    
    // Local Mode - kedua pemain bisa main
    jika (mode_game == "local") {
        jika (giliran_putih) {
            teks_status = "Giliran: Putih"
        } jika_tidak {
            teks_status = "Giliran: Hitam"
        }
    }
    
    // Online Mode - show dari perspektif player
    jika (mode_game == "online_host" atau mode_game == "online_join") {
        var giliran_saya = salah
        
        // Cek apakah giliran kita
        jika (warna_online_saya == "putih" dan giliran_putih) {
            giliran_saya = benar
        }
        jika (warna_online_saya == "hitam" dan tidak giliran_putih) {
            giliran_saya = benar
        }
        
        // Set status text
        jika (giliran_saya) {
            teks_status = "Giliran: Anda"
        } jika_tidak {
            teks_status = "Giliran: Lawan"
        }
    }
    
    ubah_teks_label(id_label_status, teks_status)
}

fungsi status_update(teks) {
    ubah_teks_label(id_label_status, teks)
}

// Helper AI
fungsi clone_papan(src) {
    var dest = []
    var ci = 0
    ulangi(ci=0; ci<8; ci=ci+1) {
        var row = []
        var cj = 0
        ulangi(cj=0; cj<8; cj=cj+1) {
            tambah(row, src[ci][cj])
        }
        tambah(dest, row)
    }
    kembalikan dest
}

fungsi get_nilai_bidak(bidak) {
    var tipe = huruf_kecil(bidak)
    jika(tipe == "p") { kembalikan 10 }
    jika(tipe == "n") { kembalikan 30 }
    jika(tipe == "b") { kembalikan 30 }
    jika(tipe == "r") { kembalikan 50 }
    jika(tipe == "q") { kembalikan 90 }
    jika(tipe == "k") { kembalikan 900 }
    kembalikan 0
}

fungsi evaluasi_posisi(board_data) {
    var total = 0
    var eb = 0
    var ek = 0
    ulangi(eb=0; eb<8; eb=eb+1) {
        ulangi(ek=0; ek<8; ek=ek+1) {
            var bidak = board_data[eb][ek]
            jika (bidak != ".") {
                var nilai = get_nilai_bidak(bidak)
                // Positional bonus for center control (simple)
                jika ((eb==3 atau eb==4) dan (ek==3 atau ek==4)) { nilai = nilai + 2 }
                
                jika (adalah_huruf_besar(bidak)) {
                    // Putih (Lawan) -> Kurangi score
                    total = total - nilai
                } jika_tidak {
                    // Hitam (AI) -> Tambah score
                    total = total + nilai
                }
            }
        }
    }
    
    // PENALTY BESAR jika Raja dalam skak
    var raja_hitam_skak = raja_dalam_skak(salah)
    var raja_putih_skak = raja_dalam_skak(benar)
    
    jika (raja_hitam_skak) {
        total = total - 200  // Penalty besar untuk AI yang dalam skak
    }
    jika (raja_putih_skak) {
        total = total + 200  // Bonus besar jika lawan dalam skak
    }
    
    kembalikan total
}

// Helper untuk cari posisi Raja
fungsi cari_raja(is_putih) {
    var target_raja = "K"
    jika (tidak is_putih) { target_raja = "k" }
    
    var fr = 0
    var fk = 0
    ulangi (fr = 0; fr < 8; fr = fr + 1) {
        ulangi (fk = 0; fk < 8; fk = fk + 1) {
            jika (papan[fr][fk] == target_raja) {
                kembalikan {baris: fr, kolom: fk}
            }
        }
    }
    kembalikan kosong
}

// Cek apakah Raja dalam skak
fungsi raja_dalam_skak(is_putih) {
    var pos_raja = cari_raja(is_putih)
    jika (pos_raja == kosong) { kembalikan salah }
    
    var diserang = kotak_diserang(pos_raja.baris, pos_raja.kolom, tidak is_putih)
    kembalikan diserang
}

// Cek apakah pemain punya langkah legal
fungsi ada_langkah_legal(is_putih) {
    var legal_b = 0
    var legal_k = 0
    ulangi (legal_b = 0; legal_b < 8; legal_b = legal_b + 1) {
        ulangi (legal_k = 0; legal_k < 8; legal_k = legal_k + 1) {
            var bidak = papan[legal_b][legal_k]
            jika (bidak == ".") { lanjut }
            
            var is_bidak_putih = adalah_huruf_besar(bidak)
            jika (is_bidak_putih != is_putih) { lanjut }
            
            var moves = dapatkan_langkah_legal(legal_b, legal_k)
            
            // Cek setiap move apakah legal (tidak membuat Raja dalam skak)
            var legal_idx = 0
            ulangi (legal_idx = 0; legal_idx < panjang(moves); legal_idx = legal_idx + 1) {
                var mv = moves[legal_idx]
                
                // Simulasi move
                var bidak_src = papan[legal_b][legal_k]
                var bidak_dst = papan[mv.baris][mv.kolom]
                
                ubah(papan[mv.baris], mv.kolom, bidak_src)
                ubah(papan[legal_b], legal_k, ".")
                
                var raja_aman = tidak raja_dalam_skak(is_putih)
                
                // Undo
                ubah(papan[legal_b], legal_k, bidak_src)
                ubah(papan[mv.baris], mv.kolom, bidak_dst)
                
                jika (raja_aman) {
                    kembalikan benar  // Ada setidaknya 1 langkah legal
                }
            }
        }
    }
    kembalikan salah  // Tidak ada langkah legal
}

// Cek status game (checkmate/stalemate/normal)
fungsi cek_status_game(giliran_siapa_putih) {
    var dalam_skak = raja_dalam_skak(giliran_siapa_putih)
    var ada_move = ada_langkah_legal(giliran_siapa_putih)
    
    jika (tidak ada_move) {
        jika (dalam_skak) {
            kembalikan "checkmate"  // Skak mat - lawan menang
        } jika_tidak {
            kembalikan "stalemate"  // Seri
        }
    }
    
    jika (dalam_skak) {
        kembalikan "check"  // Dalam skak tapi masih bisa jalan
    }
    
    kembalikan "normal"
}

// AI Sederhana (Upgrade ke Greedy/Minimax Depth 1)
fungsi ai_jalan() {
    coba {
        var best_score = -999999
        var best_move = kosong
        
        // Kumpulkan semua langkah legal Hitam
        var ai_b = 0
        var ai_k = 0
        ulangi (ai_b = 0; ai_b < 8; ai_b = ai_b + 1) {
            ulangi (ai_k = 0; ai_k < 8; ai_k = ai_k + 1) {
                var bidak = papan[ai_b][ai_k]
                jika (bidak != "." dan tidak adalah_huruf_besar(bidak)) {
                    var moves = dapatkan_langkah_legal(ai_b, ai_k)
                    
                    var i = 0
                    ulangi (i = 0; i < panjang(moves); i = i + 1) {
                        var mv = moves[i]
                        
                        // Simulasi Move (Do)
                        var target_row = mv.baris
                        var target_col = mv.kolom
                        
                        // Safety check
                        jika (target_row < 0 atau target_row > 7 atau target_col < 0 atau target_col > 7) {
                            lanjut
                        }
                        
                        // Simpan state SEBELUM modifikasi
                        var bidak_src_asli = papan[ai_b][ai_k]
                        var bidak_dst_asli = papan[target_row][target_col]
                        
                        // Handle Promosi
                        var bidak_jalan = bidak
                        jika (huruf_kecil(bidak)=="p" dan (target_row==0 atau target_row==7)) {
                            bidak_jalan = "q"
                        }
                        
                        coba {
                            ubah(papan[target_row], target_col, bidak_jalan)
                            ubah(papan[ai_b], ai_k, ".")
                            
                            // CRITICAL: Cek apakah langkah ini membuat Raja sendiri dalam skak
                            var raja_masih_aman = tidak raja_dalam_skak(salah)
                            
                            jika (raja_masih_aman) {
                                // Evaluasi
                                var score = evaluasi_posisi(papan)
                                
                                // BONUS BESAR jika langkah ini menyelamatkan Raja dari skak
                                var raja_diselamatkan = raja_dalam_skak(salah)
                                jika (tidak raja_diselamatkan) {
                                    // Jika sebelumnya Raja dalam skak tapi setelah move ini tidak
                                    // (ini dideteksi di luar loop, tapi kita beri bonus untuk move yang baik)
                                    score = score + 50
                                }
                                
                                // Bonus kecil random untuk variasi
                                score = score + acak_antara(0, 5)
                                
                                jika (score > best_score) {
                                    best_score = score
                                    best_move = {
                                        asal: {baris: ai_b, kolom: ai_k},
                                        tujuan: mv
                                    }
                                }
                            }
                            // Jika move ini membuat Raja dalam skak, skip (illegal move)
                        } akhirnya {
                            // Undo Move - WAJIB dijalankan
                            ubah(papan[ai_b], ai_k, bidak_src_asli)
                            ubah(papan[target_row], target_col, bidak_dst_asli)
                        }
                    }
                }
            }
        }
        
        // Fallback jika tidak ada move (Checkmate/Stalemate handled logic elsewhere but safe here)
        jika (best_move == kosong) {
             // Coba cari move random apapun yang legal sebagai fallback terakhir crisis
             tampilkan_pesan("Info", "Komputer menyerah atau stalemate!")
             kembalikan 0
        }
        
        tulis("AI Executing: " + best_move.asal.baris + "," + best_move.asal.kolom + " -> " + best_move.tujuan.baris + "," + best_move.tujuan.kolom)
        jalankan_langkah(best_move.asal, best_move.tujuan)
        gambar_papan()
        
    } tangkap(err) {
        tulis("CRITICAL AI CRASH: " + err)
        // Recover state?
    }
}


// Event Handler Klik
fungsi klik_papan(x, y) {
    jika (game_selesai) { kembalikan 0 }
    
    // Konversi koordinat pixel ke baris/kolom
    var k = lantai(x / ukuran_kotak)
    var b = lantai(y / ukuran_kotak)
    
    // Account for board flip when playing as Black
    var flip_board = salah
    jika (mode_game == "online_join" dan warna_online_saya == "hitam") {
        flip_board = benar
    }
    jika (flip_board) {
        b = 7 - b
        k = 7 - k
    }
    
    // Validasi bounds
    jika (b < 0 atau b > 7 atau k < 0 atau k > 7) { kembalikan 0 }
    
    // Cegah input saat giliran komputer (AI mode only)
    jika (mode_game == "ai" dan tidak giliran_putih) { kembalikan 0 }
    
    // Cegah input saat giliran lawan (Online mode only)
    jika (mode_game == "online_host" atau mode_game == "online_join") {
        // Check if it's our turn based on our color
        jika (warna_online_saya == "putih" dan tidak giliran_putih) { kembalikan 0 }
        jika (warna_online_saya == "hitam" dan giliran_putih) { kembalikan 0 }
    }
    
    // Logika Seleksi
    jika (terpilih == kosong) {
        // Belum ada yang dipilih -> Pilih bidak
        var bidak = papan[b][k]
        jika (bidak != ".") {
            jika (adalah_huruf_besar(bidak) == giliran_putih) {
                // Pilih bidak sendiri
                terpilih = {baris: b, kolom: k}
                langkah_legal = dapatkan_langkah_legal(b, k)
                gambar_papan()
            }
        }
    } jika_tidak {
        // Sudah ada yang dipilih -> Cek tujuan
        var asal = terpilih
        var tujuan = {baris: b, kolom: k}
        
        // Batalkan jika klik bidak sendiri yang lain (ganti pilihan)
        var bidak_tujuan = papan[b][k]
        var ganti_pilih = salah
        jika (bidak_tujuan != ".") {
            jika (adalah_huruf_besar(bidak_tujuan) == giliran_putih) {
                terpilih = {baris: b, kolom: k}
                langkah_legal = dapatkan_langkah_legal(b, k)
                gambar_papan()
                kembalikan 0
            }
        }
        
        // Coba jalan
        cek_dan_jalankan(asal, tujuan)
        
        // Reset pilihan setelah jalan (berhasil atau gagal)
        terpilih = kosong
        langkah_legal = []
        gambar_papan()
    }
}

// ============================================================================
// ONLINE MULTIPLAYER FUNCTIONS
// ============================================================================

fungsi kirim_langkah_online(dari_b, dari_k, ke_b, ke_k) {
    jika (koneksi_online == kosong) { kembalikan salah }
    
    var msg = "{"
    msg = msg + "\"type\":\"move\","
    msg = msg + "\"dari_b\":" + ke_teks(dari_b) + ","
    msg = msg + "\"dari_k\":" + ke_teks(dari_k) + ","
    msg = msg + "\"ke_b\":" + ke_teks(ke_b) + ","
    msg = msg + "\"ke_k\":" + ke_teks(ke_k)
    msg = msg + "}"
    
    tulis("📤 Sending move online")
    kembalikan kirim(koneksi_online, msg)
}

fungsi cek_langkah_lawan_online() {
    jika (koneksi_online == kosong) { kembalikan 0 }
    
    jika (ada_data(koneksi_online)) {
        var data = terima(koneksi_online, 100)
        jika (data != kosong) {
            tulis("📥 Received move from opponent")
            var move = decode_json(data)
            jika (move != kosong) {
                var dari_b = move["dari_b"]
                var dari_k = move["dari_k"]
                var ke_b = move["ke_b"]
                var ke_k = move["ke_k"]
                
                // Apply move
                var bidak = papan[dari_b][dari_k]
                ubah(papan[ke_b], ke_k, bidak)
                ubah(papan[dari_b], dari_k, ".")
                
                giliran_putih = tidak giliran_putih
                gambar_papan()
                update_status_label()
            }
        }
    }
    
    // Continue checking
    jika (tidak game_selesai) {
        atur_waktu(300, cek_langkah_lawan_online)
    }
}

// ============================================================================
// MODE SELECTION MENU
// ============================================================================

fungsi tampilkan_menu_utama() {
    buat_jendela("Castle Script Chess", 400, 350)
    atur_warna_latar("#2c3e50")
    
    buat_label("CASTLE SCRIPT", 125, 30, 20, "#ecf0f1", "#2c3e50")
    buat_label("CHESS GAME", 140, 60, 18, "#ecf0f1", "#2c3e50")
    buat_label("Choose Your Mode", 130, 95, 11, "#95a5a6", "#2c3e50")
    
    buat_tombol("🤖 vs AI", mulai_mode_ai, 100, 130, 200, 50, "#3498db", "white", 14)
    buat_tombol("👥 vs Human (Local)", mulai_mode_local, 100, 190, 200, 50, "#27ae60", "white", 13)
    buat_tombol("🌐 vs Human (Online)", mulai_mode_online_menu, 100, 250, 200, 50, "#e74c3c", "white", 13)
    
    jalankan()
}

fungsi mulai_mode_ai() {
    mode_game = "ai"
    tutup_jendela(id_jendela)
    mulai_permainan()
}

fungsi mulai_mode_local() {
    mode_game = "local"
    tutup_jendela(id_jendela)
    mulai_permainan()
}

fungsi mulai_mode_online_menu() {
    tutup_jendela(id_jendela)
    
    buat_jendela("Online Chess", 400, 300)
    atur_warna_latar("#2c3e50")
    
    buat_label("ONLINE MULTIPLAYER", 100, 30, 16, "white", "#2c3e50")
    buat_label("Choose Connection Mode", 110, 65, 11, "#95a5a6", "#2c3e50")
    
    buat_tombol("HOST GAME", mulai_host_online, 100, 110, 200, 50, "#27ae60", "white", 14)
    buat_tombol("JOIN GAME", mulai_join_online, 100, 170, 200, 50, "#3498db", "white", 14)
    buat_tombol("BACK", tampilkan_menu_utama, 100, 230, 200, 40, "#95a5a6", "white", 12)
    
    jalankan()
}

fungsi mulai_host_online() {
    tutup_jendela(id_jendela)
    
    // Show color selection screen
    buat_jendela("Host Game - Choose Color", 400, 280)
    atur_warna_latar("#2c3e50")
    
    buat_label("HOST ONLINE GAME", 110, 30, 16, "white", "#2c3e50")
    buat_label("Choose your color:", 130, 70, 12, "#95a5a6", "#2c3e50")
    
    buat_tombol("♔ Play as WHITE", pilih_putih_host, 100, 110, 200, 50, "#ecf0f1", "#2c3e50", 14)
    buat_tombol("♚ Play as BLACK", pilih_hitam_host, 100, 170, 200, 50, "#34495e", "white", 14)
    
    jalankan()
}

fungsi pilih_putih_host() {
    mode_game = "online_host"
    warna_online_saya = "putih"
    tutup_jendela(id_jendela)
    buat_server_dan_tunggu()
}

fungsi pilih_hitam_host() {
    mode_game = "online_host"
    warna_online_saya = "hitam"
    tutup_jendela(id_jendela)
    buat_server_dan_tunggu()
}

fungsi buat_server_dan_tunggu() {
    // Try to launch tunnel (smart fallback: localhost.run → ngrok)
    tulis("🚀 Launching internet tunnel...")
    var tunnel_url = mulai_tunnel(5555)
    tunnel_url_global = tunnel_url
    
    // Create local server
    server_online = buat_server(5555)
    jika (server_online == kosong) {
        tutup_tunnel()
        tampilkan_pesan("Error", "Failed to create server!")
        kembalikan 0
    }
    
    id_jendela = buat_jendela("Waiting for Opponent", 450, 350)
    atur_warna_latar("#2c3e50")
    
    var warna_text = "White"
    jika (warna_online_saya == "hitam") { warna_text = "Black" }
    
    buat_label("Hosting Game...", 150, 30, 16, "white", "#2c3e50")
    buat_label("You play as: " + warna_text, 170, 65, 12, "#f39c12", "#2c3e50")
    
    // Display tunnel info
    jika (tunnel_url != kosong) {
        // Tunnel successfully created
        buat_label("✅ Public Address (Share this!):", 100, 105, 11, "#2ecc71", "#2c3e50")
        var id_url_label = buat_label(tunnel_url, 125, 135, 13, "#ecf0f1", "#2c3e50")
        
        // Copy button - using global variable
        fungsi salin_url() {
            salin_teks(tunnel_url_global)
            buat_label("✓ Copied!", 190, 180, 10, "#2ecc71", "#2c3e50")
            tulis("📋 URL copied to clipboard: " + tunnel_url_global)
        }
        buat_tombol("📋 COPY ADDRESS", salin_url, 140, 210, 170, 40, "#27ae60", "white", 12)
        
        buat_label("Waiting for opponent...", 145, 275, 12, "#3498db", "#2c3e50")
        
        tulis("✅ Tunnel URL: " + tunnel_url)
        tulis("📤 Share this with your opponent!")
    } jika_tidak {
        // Fallback to local IP
        buat_label("⚠️ Tunnel unavailable - Local IP only", 95, 105, 10, "#e74c3c", "#2c3e50")
        buat_label("Your Local IP:", 165, 135, 11, "#95a5a6", "#2c3e50")
        buat_label("Port: 5555", 180, 160, 12, "#f39c12", "#2c3e50")
        buat_label("(Run 'ipconfig' in CMD)", 130, 185, 9, "#7f8c8d", "#2c3e50")
        buat_label("Waiting for connection...", 130, 230, 12, "#3498db", "#2c3e50")
        
        tulis("⚠️ No tunnel available")
        tulis("💡 For internet play, install ngrok:")
        tulis("💡 https://ngrok.com/download")
        tulis("💡 Fallback to local IP - works on same WiFi only")
    }
    
    tulis("🌐 Server created on port 5555")
    tulis("💡 Playing as: " + warna_online_saya)
    
    atur_waktu(1000, cek_koneksi_host_online)
    jalankan()
}

fungsi cek_koneksi_host_online() {
    koneksi_online = tunggu_koneksi(server_online, 1000)
    
    jika (koneksi_online != kosong) {
        tulis("✅ Player connected!")
        
        // Send our color to opponent
        var msg = "{"
        msg = msg + "\"type\":\"color\","
        msg = msg + "\"host_color\":\"" + warna_online_saya + "\""
        msg = msg + "}"
        kirim(koneksi_online, msg)
        tulis("📤 Sent color info to opponent")
        
        tutup_jendela(id_jendela)
        mulai_permainan()
    } jika_tidak {
        atur_waktu(1000, cek_koneksi_host_online)
    }
}

var id_input_ip = 0

var id_input_ip = 0

fungsi sambung_sekarang() {
    var ip = ambil_nilai_input(id_input_ip)
    tulis("🌐 Connecting to " + ip + ":5555...")
    
    koneksi_online = sambung_ke(ip, 5555, 5000)
    
    jika (koneksi_online != kosong) {
        tulis("✅ Connected!")
        
        // Wait for host to send color info
        tulis("⏳ Waiting for color info...")
        var received = salah
        var attempts = 0
        selama (tidak received dan attempts < 100) {
            jika (ada_data(koneksi_online)) {
                var data = terima(koneksi_online, 100)
                jika (data != kosong) {
                    tulis("📥 Received: " + data)
                    var msg = decode_json(data)
                    jika (msg != kosong) {
                        var host_color = msg["host_color"]
                        tulis("🎨 Host plays as: " + host_color)
                        
                        // Set opposite color
                        jika (host_color == "putih") {
                            warna_online_saya = "hitam"
                            mode_game = "online_join"
                        } jika_tidak {
                            warna_online_saya = "putih"
                            mode_game = "online_join"
                        }
                        tulis("🎨 You play as: " + warna_online_saya)
                        received = benar
                    }
                }
            }
            attempts = attempts + 1
        }
        
        tutup_jendela(id_jendela)
        mulai_permainan()
    } jika_tidak {
        tulis("❌ Connection failed")
        tampilkan_pesan("Error", "Could not connect to " + ip)
    }
}

fungsi mulai_join_online() {
    mode_game = "online_join"
    warna_online_saya = "hitam"
    
    tutup_jendela(id_jendela)
    
    buat_jendela("Connect to Game", 400, 250)
    atur_warna_latar("#2c3e50")
    
    buat_label("Join Online Game", 125, 30, 16, "white", "#2c3e50")
    buat_label("Enter host IP address:", 105, 80, 12, "#95a5a6", "#2c3e50")
    
    id_input_ip = buat_input(100, 110, 14, 16)
    atur_nilai_input(id_input_ip, "127.0.0.1")
    
    buat_tombol("CONNECT", sambung_sekarang, 125, 160, 150, 45, "#27ae60", "white", 14)
    
    jalankan()
}

fungsi mulai_permainan() {
    init_papan()
    giliran_putih = benar
    game_selesai = salah
    terpilih = kosong
    langkah_legal = []
    
    // Reset castling flags
    raja_putih_sudah_jalan = salah
    raja_hitam_sudah_jalan = salah
    benteng_putih_kiri_sudah_jalan = salah
    benteng_putih_kanan_sudah_jalan = salah
    benteng_hitam_kiri_sudah_jalan = salah
    benteng_hitam_kanan_sudah_jalan = salah
    
    // Create game window
    id_jendela = buat_jendela("Castle Script Chess", ukuran_papan + margin * 2, ukuran_papan + 150)
    atur_warna_latar("#34495e")
    
    var title = "CHESS"
    jika (mode_game == "ai") { title = "CHESS vs AI" }
    jika (mode_game == "local") { title = "CHESS - Local 2P" }
    jika (mode_game == "online_host") { title = "CHESS ONLINE - Putih" }
    jika (mode_game == "online_join") { title = "CHESS ONLINE - Hitam" }
    
    buat_label(title, margin, 10, 14, "#ecf0f1", "#34495e")
    
    id_label_status = buat_label("Game Started!", margin, ukuran_papan + 90, 12, "#f39c12", "#34495e")
    
    id_canvas = buat_kanvas(margin, 50, ukuran_papan, ukuran_papan)
    
    gambar_papan()
    update_status_label()

    // Bind klik ke canvas
    bind_klik(id_canvas, klik_papan)

    // Start online checking if online mode
    jika (mode_game == "online_host" atau mode_game == "online_join") {
        atur_waktu(300, cek_langkah_lawan_online)
    }

    // Jalankan
    jalankan()
}

// ============================================================================
// MAIN ENTRY POINT
// ============================================================================

tulis("🏰 Castle Script Chess")
tulis("   Enhanced Edition with Online Multiplayer")
tulis("")

tampilkan_menu_utama()
