# CastleScript v0.9.1 Beta - Release Notes

## 🎉 First Public Release

CastleScript adalah bahasa pemrograman dengan sintaks 100% Bahasa Indonesia. Release ini menandai peluncuran publik pertama dengan 70+ fungsi built-in yang siap digunakan.

## ✨ What's New

### Core Features

- **70+ Built-in Functions** - Lengkap untuk arrays, strings, math, files, JSON, dan regex
- **Interactive REPL** - Console mode interaktif seperti Python/Node.js
- **GUI Support** - Buat desktop applications dengan built-in GUI functions
- **Cross-Platform** - Windows, macOS, dan Linux support
- **Dot Notation** - Akses property object dengan syntax `obj.property`

### Language Features

- Variables dan Functions
- Control Flow (if/else, while, for loops)
- Arrays dan Objects
- Higher-order functions (map, filter, reduce)
- File I/O operations
- Date/Time functions
- JSON parsing dan stringify
- Regular expressions
- Type checking utilities
- String manipulation

### Tools

- `cs` command - Simple launcher untuk menjalankan program
- Interactive console - REPL mode untuk eksperimen
- GUI builder - Functions untuk membuat desktop apps
- Cross-platform launchers - Windows (.bat) dan Unix (shell script)

## 📦 Installation

### Quick Start

```bash
# Clone repository
git clone https://github.com/harismuzaki19/Castle-Script.git
cd Castle-Script

# Run a program
cs hello.cs

# Or use interactive mode
cs
```

### Requirements

- Python 3.6 or higher
- No additional dependencies required for core features
- Tkinter (usually pre-installed with Python) for GUI features

## 📚 Documentation

- **README.md** - Quick start guide
- **SYNTAX.md** - Complete syntax reference
- **EXTENDED_FEATURES.md** - All 70+ functions documented
- **docs/CONSOLE_MODE.md** - Interactive console guide
- **docs/GUI_README.md** - GUI programming tutorial
- **docs/SETUP_COMMAND.md** - Platform-specific setup

## 🎯 Use Cases

- **Education** - Belajar programming dalam Bahasa Indonesia
- **Desktop Apps** - Buat GUI applications
- **Data Processing** - Handle CSV, JSON, text files
- **Automation** - Script repetitive tasks
- **Prototyping** - Quick experimentation dengan REPL

## 🚀 Quick Examples

### Hello World

```castlescript
tulis("Halo, Dunia!")
```

### Array Processing

```castlescript
fungsi double(x) { kembalikan x * 2 }
var numbers = [1, 2, 3, 4, 5]
var doubled = petakan(numbers, double)
tulis(ke_teks(doubled))  // [2, 4, 6, 8, 10]
```

### GUI Application

```castlescript
buat_jendela("My App", 400, 300)
buat_label("Hello from CastleScript!", 10, 10)
jalankan()
```

## 📊 Statistics

- **Total Functions**: 70+
- **Source Code**: ~2,000 lines
- **Documentation**: 6 comprehensive guides
- **Examples**: 10+ working programs
- **Test Coverage**: Comprehensive

## 🐛 Known Issues

- Advanced array functions may have edge cases with complex nested functions
- GUI functions require Tkinter (pre-installed on most systems)
- Terminal colors may not work on all platforms

## 🔮 Future Plans

- Lambda arrow syntax (`=>`)
- Module system (`impor`/`ekspor`)
- Full OOP with inheritance
- Enhanced error messages
- Package manager
- Standard library expansion

## 👥 Contributing

Contributions welcome! This is an open educational project.

## 📄 License

Open for educational and personal use.

## 🙏 Acknowledgments

Thank you to all early testers and the Indonesian programming community!

---

**Full Changelog**: Initial release v0.9.1 Beta

**Assets**: Source code available in repository
