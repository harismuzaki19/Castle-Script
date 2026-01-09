#!/usr/bin/env python3
"""
CastleScript Extended Built-ins
Library tambahan dengan fitur lengkap: Arrays, Objects, Strings, Math, File I/O
"""

import math
import random
import os
import json
from datetime import datetime

def get_extended_builtins():
    """Return all extended built-in functions"""
    
    # ===== ARRAY FUNCTIONS =====
    
    def tambah(arr, item):
        """Menambah item ke array (append)"""
        if not isinstance(arr, list):
            raise TypeError("tambah() hanya bisa digunakan pada array")
        arr.append(item)
        return arr
    
    def hapus(arr, index):
        """Menghapus item dari array berdasarkan index"""
        if not isinstance(arr, list):
            raise TypeError("hapus() hanya bisa digunakan pada array")
        if 0 <= index < len(arr):
            return arr.pop(index)
        raise IndexError(f"Index {index} di luar jangkauan")
    
    def sisip(arr, index, item):
        """Menyisipkan item ke array pada index tertentu"""
        if not isinstance(arr, list):
            raise TypeError("sisip() hanya bisa digunakan pada array")
        arr.insert(index, item)
        return arr
    
    def gabung(arr1, arr2):
        """Menggabungkan dua array"""
        if not isinstance(arr1, list) or not isinstance(arr2, list):
            raise TypeError("gabung() memerlukan dua array")
        return arr1 + arr2
    
    def irisan(arr, start, end=None):
        """Mengambil irisan array (slice)"""
        if not isinstance(arr, list):
            raise TypeError("irisan() hanya bisa digunakan pada array")
        if end is None:
            return arr[start:]
        return arr[start:end]
    
    def balik(arr):
        """Membalik urutan array"""
        if not isinstance(arr, list):
            raise TypeError("balik() hanya bisa digunakan pada array")
        return list(reversed(arr))
    
    def urutkan(arr):
        """Mengurutkan array"""
        if not isinstance(arr, list):
            raise TypeError("urutkan() hanya bisa digunakan pada array")
        return sorted(arr)
    
    # ===== STRING FUNCTIONS =====
    
    def potong(text, start, end=None):
        """Memotong string (substring)"""
        text = str(text)
        if end is None:
            return text[start:]
        return text[start:end]
    
    def pisah(text, separator=" "):
        """Memisahkan string menjadi array"""
        return str(text).split(str(separator))
    
    def gabung_teks(arr, separator=""):
        """Menggabungkan array menjadi string"""
        if not isinstance(arr, list):
            raise TypeError("gabung_teks() memerlukan array")
        return str(separator).join(str(item) for item in arr)
    
    def ganti(text, old, new):
        """Mengganti substring dalam string"""
        return str(text).replace(str(old), str(new))
    
    def huruf_besar(text):
        """Konversi ke huruf besar"""
        return str(text).upper()
    
    def huruf_kecil(text):
        """Konversi ke huruf kecil"""
        return str(text).lower()
    
    def rapikan(text):
        """Hapus whitespace di awal dan akhir"""
        return str(text).strip()
    
    def mengandung(text, substring):
        """Cek apakah string mengandung substring"""
        return str(substring) in str(text)
    
    def mulai_dengan(text, prefix):
        """Cek apakah string dimulai dengan prefix"""
        return str(text).startswith(str(prefix))
    
    def akhiri_dengan(text, suffix):
        """Cek apakah string diakhiri dengan suffix"""
        return str(text).endswith(str(suffix))
    
    def indeks(text, substring):
        """Mencari posisi substring"""
        try:
            return str(text).index(str(substring))
        except ValueError:
            return -1
    
    # ===== MATH FUNCTIONS =====
    
    def absolut(x):
        """Nilai absolut"""
        return abs(x)
    
    def pangkat(base, exp):
        """Perpangkatan"""
        return math.pow(base, exp)
    
    def akar(x):
        """Akar kuadrat"""
        if x < 0:
            raise ValueError("Tidak bisa mengakar bilangan negatif")
        return math.sqrt(x)
    
    def bulatkan(x, digits=0):
        """Pembulatan"""
        return round(x, digits)
    
    def lantai(x):
        """Pembulatan ke bawah"""
        return math.floor(x)
    
    def langit(x):
        """Pembulatan ke atas"""
        return math.ceil(x)
    
    def minimal(*args):
        """Nilai minimum"""
        return min(args)
    
    def maksimal(*args):
        """Nilai maksimum"""
        return max(args)
    
    def angka_acak():
        """Angka random 0-1"""
        return random.random()
    
    def acak_antara(min_val, max_val):
        """Angka random dalam range"""
        return random.randint(int(min_val), int(max_val))
    
    # ===== FILE I/O FUNCTIONS =====
    
    def baca_file(path):
        """Membaca isi file"""
        try:
            with open(path, 'r', encoding='utf-8') as f:
                return f.read()
        except FileNotFoundError:
            raise FileNotFoundError(f"File '{path}' tidak ditemukan")
        except Exception as e:
            raise RuntimeError(f"Gagal membaca file: {e}")
    
    def tulis_file(path, content):
        """Menulis ke file"""
        try:
            with open(path, 'w', encoding='utf-8') as f:
                f.write(str(content))
            return True
        except Exception as e:
            raise RuntimeError(f"Gagal menulis file: {e}")
    
    def tambah_file(path, content):
        """Menambah ke akhir file"""
        try:
            with open(path, 'a', encoding='utf-8') as f:
                f.write(str(content))
            return True
        except Exception as e:
            raise RuntimeError(f"Gagal menambah file: {e}")
    
    def hapus_file(path):
        """Menghapus file"""
        try:
            os.remove(path)
            return True
        except FileNotFoundError:
            raise FileNotFoundError(f"File '{path}' tidak ditemukan")
        except Exception as e:
            raise RuntimeError(f"Gagal menghapus file: {e}")
    
    def ada_file(path):
        """Cek apakah file exists"""
        return os.path.exists(path)
    
    def buat_folder(path):
        """Membuat folder"""
        try:
            os.makedirs(path, exist_ok=True)
            return True
        except Exception as e:
            raise RuntimeError(f"Gagal membuat folder: {e}")
    
    def daftar_file(directory="."):
        """List semua file dalam directory"""
        try:
            return os.listdir(directory)
        except Exception as e:
            raise RuntimeError(f"Gagal membaca directory: {e}")
    
    # ===== DATE & TIME FUNCTIONS =====
    
    def waktu_sekarang():
        """Waktu saat ini"""
        return datetime.now()
    
    def tanggal_sekarang():
        """Tanggal hari ini"""
        return datetime.now().date()
    
    def format_waktu(dt, format_string="%Y-%m-%d %H:%M:%S"):
        """Format waktu/tanggal"""
        if isinstance(dt, datetime):
            return dt.strftime(format_string)
        return str(dt)
    
    def tahun(dt=None):
        """Ambil tahun dari datetime"""
        if dt is None:
            dt = datetime.now()
        return dt.year if hasattr(dt, 'year') else datetime.now().year
    
    def bulan(dt=None):
        """Ambil bulan dari datetime"""
        if dt is None:
            dt = datetime.now()
        return dt.month if hasattr(dt, 'month') else datetime.now().month
    
    def hari(dt=None):
        """Ambil hari dari datetime"""
        if dt is None:
            dt = datetime.now()
        return dt.day if hasattr(dt, 'day') else datetime.now().day
    
    # ===== JSON FUNCTIONS =====
    
    def dari_json(json_string):
        """Parse JSON string menjadi object"""
        try:
            return json.loads(str(json_string))
        except json.JSONDecodeError as e:
            raise ValueError(f"JSON tidak valid: {e}")
    
    def ke_json(obj):
        """Convert object ke JSON string"""
        try:
            return json.dumps(obj, ensure_ascii=False, indent=2)
        except TypeError as e:
            raise ValueError(f"Tidak bisa convert ke JSON: {e}")
    
    # ===== REGULAR EXPRESSIONS =====
    
    def cocokkan(text, pattern):  
        """Match regex pattern and return matches"""
        import re
        # Remove slashes if present
        p = str(pattern).strip('/')
        try:
            matches = re.findall(p, str(text))
            return matches
        except re.error as e:
            raise ValueError(f"Pattern regex tidak valid: {e}")
    
    def ganti_regex(text, pattern, replacement):
        """Replace text using regex pattern"""
        import re
        p = str(pattern).strip('/')
        try:
            return re.sub(p, str(replacement), str(text))
        except re.error as e:
            raise ValueError(f"Pattern regex tidak valid: {e}")
    
    def tes_regex(text, pattern):
        """Test if pattern matches text"""
        import re
        p = str(pattern).strip('/')
        try:
            return bool(re.search(p, str(text)))
        except re.error as e:
            raise ValueError(f"Pattern regex tidak valid: {e}")
    
    def pisah_regex(text, pattern):
        """Split text using regex pattern"""
        import re
        p = str(pattern).strip('/')
        try:
            return re.split(p, str(text))
        except re.error as e:
            raise ValueError(f"Pattern regex tidak valid: {e}")
    
    # Return dictionary of all functions
    return {
        # Array functions
        'tambah': tambah,
        'hapus': hapus,
        'sisip': sisip,
        'gabung': gabung,
        'irisan': irisan,
        'balik': balik,
        'urutkan': urutkan,
        
        # String functions
        'potong': potong,
        'pisah': pisah,
        'gabung_teks': gabung_teks,
        'ganti': ganti,
        'huruf_besar': huruf_besar,
        'huruf_kecil': huruf_kecil,
        'rapikan': rapikan,
        'mengandung': mengandung,
        'mulai_dengan': mulai_dengan,
        'akhiri_dengan': akhiri_dengan,
        'indeks': indeks,
        
        # Math functions
        'absolut': absolut,
        'pangkat': pangkat,
        'akar': akar,
        'bulatkan': bulatkan,
        'lantai': lantai,
        'langit': langit,
        'minimal': minimal,
        'maksimal': maksimal,
        'angka_acak': angka_acak,
        'acak_antara': acak_antara,
        
        # File I/O
        'baca_file': baca_file,
        'tulis_file': tulis_file,
        'tambah_file': tambah_file,
        'hapus_file': hapus_file,
        'ada_file': ada_file,
        'buat_folder': buat_folder,
        'daftar_file': daftar_file,
        
        # Date & Time
        'waktu_sekarang': waktu_sekarang,
        'tanggal_sekarang': tanggal_sekarang,
        'format_waktu': format_waktu,
        'tahun': tahun,
        'bulan': bulan,
        'hari': hari,
        
        # JSON
        'dari_json': dari_json,
        'ke_json': ke_json,
        
        # Regular Expressions
        'cocokkan': cocokkan,
        'ganti_regex': ganti_regex,
        'tes_regex': tes_regex,
        'pisah_regex': pisah_regex,
    }
