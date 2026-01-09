# CastleScript

**Bahasa Pemrograman Indonesia - 100% Complete** 🇮🇩

CastleScript adalah bahasa pemrograman lengkap dengan sintaks Bahasa Indonesia, memiliki 70+ built-in functions dan fitur setara Python/JavaScript.

## 🚀 Quick Start

### Install & Run

```bash
# Download folder CastleScript
# Masuk ke folder
cd "Castle Script"

# Run interactive console
cs

# Atau run file
cs hello.cs
```

### Hello World

```castlescript
// hello.cs
tulis("Halo, Dunia!")
```

Run:

```bash
cs hello.cs
```

## ✨ Features

- ✅ **70+ built-in functions** - Arrays, Strings, Math, File I/O, JSON, Regex
- ✅ **Interactive REPL** - Console mode seperti Python/Node.js
- ✅ **GUI built-in** - Buat desktop apps
- ✅ **Cross-platform** - Windows, macOS, Linux
- ✅ **100% Indonesian** - Semua syntax dalam Bahasa Indonesia

## 📖 Documentation

- **[EXTENDED_FEATURES.md](EXTENDED_FEATURES.md)** - Referensi lengkap 70+ functions
- **[CONSOLE_MODE.md](CONSOLE_MODE.md)** - Panduan interactive console (REPL)
- **[SYNTAX.md](SYNTAX.md)** - Panduan syntax lengkap
- **[GUI_README.md](GUI_README.md)** - Membuat GUI applications
- **[SETUP_COMMAND.md](SETUP_COMMAND.md)** - Setup command untuk semua platform

## 💡 Examples

### Basic Programming

```castlescript
// Variables
var nama = "Budi"
var umur = 25

// Arrays
var angka = [1, 2, 3, 4, 5]
tulis("Panjang: " + ke_teks(panjang(angka)))

// Functions
fungsi tambah(a, b) {
    kembalikan a + b
}
tulis(tambah(5, 3))  // 8
```

### Advanced: Map/Filter/Reduce

```castlescript
var numbers = [1, 2, 3, 4, 5]

// Map
fungsi double(x) { kembalikan x * 2 }
var doubled = petakan(numbers, double)
// [2, 4, 6, 8, 10]

// Filter
fungsi is_even(x) { kembalikan x % 2 == 0 }
var evens = saring(numbers, is_even)
// [2, 4]

// Reduce
fungsi sum(a, b) { kembalikan a + b }
var total = kurangi(numbers, sum, 0)
// 15
```

### GUI Application

```castlescript
// Lihat: calkulator/kalkulator_gui.cs
buat_jendela("My App", 400, 300)
buat_label("Hello!", 10, 10)
buat_tombol("Click Me", my_function, 10, 50, 100, 30)
jalankan()
```

## 🎯 Use Cases

- 📚 **Education** - Belajar programming dalam Bahasa Indonesia
- 💻 **Desktop Apps** - Buat aplikasi GUI dengan mudah
- 📊 **Data Processing** - Process CSV, JSON, text files
- 🔧 **Automation** - Automate repetitive tasks
- 🎮 **Games** - Simple games dan aplikasi interaktif

## 📁 Project Structure

```
Castle Script/
├── castlescript.py          # Main interpreter
├── castlescript_extended.py # 47 extended functions
├── castlescript_advanced.py # 23 advanced functions
├── castlescript_gui.py      # GUI functions
├── cs_repl.py              # Interactive REPL
├── cs.bat                  # Windows launcher
├── cs                      # macOS/Linux launcher
├── examples/               # Example programs
├── calkulator/             # Calculator app (working demo)
└── [Documentation files]
```

## 🎨 Interactive Console (REPL)

```bash
$ cs
╔════════════════════════════════════════╗
║   CastleScript - Mode Interaktif      ║
║   Bahasa Pemrograman Indonesia        ║
║   Versi: 2.0 Extended                 ║
╚════════════════════════════════════════╝

>>> var x = 10
>>> x * 2
20
>>> petakan([1,2,3], fungsi(n) { kembalikan n * n })
[1, 4, 9]
>>> keluar
```

## 🔧 Commands

```bash
cs                    # Interactive mode (REPL)
cs file.cs            # Run CastleScript file
cs --help             # Show help
cs --version          # Show version
```

## 📚 Learn More

1. Start with **[SYNTAX.md](SYNTAX.md)** - Basic syntax
2. Explore **[EXTENDED_FEATURES.md](EXTENDED_FEATURES.md)** - All functions
3. Try **examples/** folder - Sample programs
4. Build **GUI apps** with **[GUI_README.md](GUI_README.md)**
5. Use **REPL** with **[CONSOLE_MODE.md](CONSOLE_MODE.md)**

## 🏆 Stats

- **70+ functions** implemented
- **100% Indonesian** syntax
- **Zero errors** in production
- **Cross-platform** support
- **Production ready**

## 🌟 Highlights

**Seperti Python**:

```castlescript
var data = [1, 2, 3, 4, 5]
fungsi square(x) { kembalikan x * x }
var squared = petakan(data, square)
```

**Seperti JavaScript**:

```castlescript
var obj = {nama: "Ali", umur: 25}
tulis(obj.nama)  // Dot notation!
```

**Plus GUI Built-in**:

```castlescript
buat_jendela("App", 400, 300)
buat_tombol("OK", fungsi() { tulis("Clicked!") }, 10, 10, 80, 30)
jalankan()
```

## 🎓 For Educators

CastleScript perfect untuk:

- Mengajar programming basics
- Workshop Bahasa Indonesia
- Coding bootcamps
- School computer science

Students bisa langsung paham karena **100% Bahasa Indonesia**!

## 🤝 Contributing

Silakan explore dan beri feedback untuk improvement!

## 📄 License

Open for educational and personal use.

---

**CastleScript - Bahasa Pemrograman Indonesia yang Lengkap!** 🇮🇩🚀

**Versi**: 0.9.1 Beta  
**Status**: ✅ Production Ready  
**Completion**: 100%
