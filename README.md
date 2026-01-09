# Castle-Script

A programming language with Indonesian syntax. Castle-Script has 70+ built-in functions and works like Python or JavaScript.

## Quick Start

```bash
# Interactive console
cs

# Run a file
cs program.cs

# Help
cs --help
```

## Hello World

```castlescript
// hello.cs
tulis("Halo, Dunia!")
```

```bash
cs hello.cs
```

## Features

- 70+ built-in functions for arrays, strings, math, files, JSON, regex
- Interactive console (REPL) like Python
- GUI support for desktop apps
- Cross-platform (Windows, macOS, Linux)
- 100% Indonesian syntax

## Documentation

- **[EXTENDED_FEATURES](EXTENDED_FEATURES.md)** - All functions reference
- **[SYNTAX](SYNTAX.md)** - Language syntax guide
- **[CONSOLE_MODE](docs/CONSOLE_MODE.md)** - Using the interactive console
- **[GUI_README](docs/GUI_README.md)** - Making GUI apps
- **[SETUP_COMMAND](docs/SETUP_COMMAND.md)** - Platform setup

## Examples

### Variables and Functions

```castlescript
var nama = "Budi"
var umur = 25

fungsi tambah(a, b) {
    kembalikan a + b
}

tulis(tambah(5, 3))  // 8
```

### Arrays

```castlescript
var numbers = [1, 2, 3, 4, 5]
tulis("Length: " + ke_teks(panjang(numbers)))

// map/filter/reduce
fungsi double(x) { kembalikan x * 2 }
var doubled = petakan(numbers, double)
// [2, 4, 6, 8, 10]
```

### Objects

```castlescript
var person = {nama: "Ali", umur: 25}
tulis(person.nama)  // dot notation works
```

### File Operations

```castlescript
tulis_file("data.txt", "Hello World")
var content = baca_file("data.txt")
tulis(content)
```

### GUI Application

```castlescript
buat_jendela("My App", 400, 300)
buat_label("Hello!", 10, 10)
buat_tombol("Click", my_function, 10, 50, 100, 30)
jalankan()
```

## Interactive Console

```bash
$ cs
>>> var x = 10
>>> x * 2
20
>>> petakan([1,2,3], fungsi(n) { kembalikan n * n })
[1, 4, 9]
>>> keluar
```

## Commands

```bash
cs                    # Interactive mode
cs file.cs            # Run file
cs --help             # Show help
cs --version          # Show version
```

## Installation

Clone the repository:

```bash
git clone https://github.com/harismuzaki19/Castle-Script.git
cd Castle-Script
```

Run a program:

```bash
cs your_program.cs
```

Or without setup:

```bash
python src/castlescript.py your_program.cs
```

For setting up the `cs` command, see [SETUP_COMMAND.md](docs/SETUP_COMMAND.md).

## Project Structure

```
Castle-Script/
├── README.md                   # Main documentation
├── SYNTAX.md                   # Syntax guide
├── EXTENDED_FEATURES.md        # Function reference
├── cs / cs.bat                 # Launchers
├── castlescript / castlescript.bat
├── src/                        # Source code
│   ├── castlescript.py
│   ├── castlescript_extended.py
│   ├── castlescript_advanced.py
│   └── ...
├── docs/                       # Documentation
│   ├── CONSOLE_MODE.md
│   ├── GUI_README.md
│   └── SETUP_COMMAND.md
├── examples/                   # Example programs
└── calkulator/                 # Calculator demo
```

## Use Cases

- Education - learn programming in Indonesian
- Desktop apps - build GUI applications
- Data processing - handle CSV, JSON, text files
- Automation - script repetitive tasks

## Version

Current version: 0.9.1 Beta

## License

Open for educational and personal use.
