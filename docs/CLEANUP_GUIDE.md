# File Cleanup Guide - CastleScript

## 📋 Status Setelah Cleanup

Project sudah dalam keadaan **production-ready** dengan file-file yang terorganisir.

---

## ✅ Files Yang HARUS ADA (Core)

### Interpreter Files

```
castlescript.py              # Main interpreter (1,250 lines)
castlescript_extended.py     # 47 extended functions (370 lines)
castlescript_advanced.py     # 23 advanced functions (230 lines) - FIXED
castlescript_classes.py      # OOP support (75 lines)
castlescript_gui.py          # GUI functions
cs_repl.py                   # Interactive REPL (200 lines)
```

### Launchers

```
cs.bat                       # Windows launcher
cs                           # macOS/Linux launcher
castlescript.bat             # Alternative Windows launcher
castlescript                 # Alternative Unix launcher
```

### Documentation (Main)

```
README.md                    # Main documentation (NEW - CLEAN)
EXTENDED_FEATURES.md         # All 70 functions reference
SYNTAX.md                    # Language syntax guide
GUI_README.md                # GUI programming guide
CONSOLE_MODE.md              # REPL usage guide
SETUP_COMMAND.md             # Platform setup instructions
```

### Working Examples

```
examples/                    # Example programs folder
  ├── test_features.cs       # Main feature test (VERIFIED WORKING)
  ├── hello.cs
  ├── loops.cs
  └── ...

calkulator/                  # Working calculator app
  ├── kalkulator_gui.cs      # GUI calculator (WORKING DEMO)
  └── kalkulator.cs
```

---

## 🗑️ Files Yang BISA DIHAPUS (Cleanup)

### Test Files (Temporary)

```
test_acak_debug.cs           # Debug file - bisa dihapus
test_advanced.cs             # Test file - bisa dihapus
test_all_features.cs         # Test file - bisa dihapus
test_array.cs                # Test file - bisa dihapus
test_classes.cs              # Test file - bisa dihapus
test_comprehensive.cs        # Test file - bisa dihapus
test_dot_notation.cs         # Test file - bisa dihapus
test_global.cs               # Test file - bisa dihapus
test_minimal.cs              # Test file - bisa dihapus
test_quick.cs                # Test file - bisa dihapus
test_quick_verify.cs         # Test file - bisa dihapus
test_random.cs               # Test file - bisa dihapus
test_simple_advanced.cs      # Test file - bisa dihapus
tes.cs                       # Test file - bisa dihapus
```

### Debug/Temporary Python Files

```
debug_test.py                # Debug file - bisa dihapus
test_import.py               # Test file - bisa dihapus
parse_class_method.py        # Temporary parser code - bisa dihapus
```

### Old/Redundant Documentation

```
PROGRESS.md                  # Old progress - konten sudah di README
FINAL_OPTIONS.md             # Old options doc - tidak diperlukan lagi
STATUS_REPORT.md             # Old status - ada di FINAL_SUMMARY.md
ERROR_FIX_SUMMARY.md         # Error fixes doc - sudah fixed, bisa archive
FINAL_SUMMARY.md             # Summary - konten sudah di README
```

### Misc

```
app.md                       # Old note - bisa dihapus
test_examples.bat            # Batch test runner - tidak diperlukan
__pycache__/                 # Python cache - auto-generated
```

---

## 📁 Struktur Folder Setelah Cleanup

```
Castle Script/
├── 📄 Core Interpreter (6 files)
│   ├── castlescript.py
│   ├── castlescript_extended.py
│   ├── castlescript_advanced.py
│   ├── castlescript_classes.py
│   ├── castlescript_gui.py
│   └── cs_repl.py
│
├── 🚀 Launchers (4 files)
│   ├── cs.bat
│   ├── cs
│   ├── castlescript.bat
│   └── castlescript
│
├── 📚 Documentation (6 files)
│   ├── README.md (MAIN - START HERE!)
│   ├── EXTENDED_FEATURES.md
│   ├── SYNTAX.md
│   ├── GUI_README.md
│   ├── CONSOLE_MODE.md
│   └── SETUP_COMMAND.md
│
├── 📁 examples/
│   ├── test_features.cs (verified working)
│   ├── hello.cs
│   ├── loops.cs
│   └── ... (keep useful examples)
│
└── 📁 calkulator/
    ├── kalkulator_gui.cs (working demo)
    └── kalkulator.cs
```

**Total Essential Files**: ~20 files
**Before Cleanup**: 44 files
**Reduction**: ~55% cleaner!

---

## 🧹 Cleanup Commands

### Windows (PowerShell):

```powershell
# Remove test files
Remove-Item test_*.cs
Remove-Item tes.cs
Remove-Item test_*.py
Remove-Item debug_test.py
Remove-Item parse_class_method.py
Remove-Item test_examples.bat

# Remove old docs (optional - backup first)
Remove-Item PROGRESS.md
Remove-Item FINAL_OPTIONS.md
Remove-Item STATUS_REPORT.md
Remove-Item ERROR_FIX_SUMMARY.md
Remove-Item FINAL_SUMMARY.md
Remove-Item app.md

# Clear cache
Remove-Item -Recurse __pycache__
```

### macOS/Linux:

```bash
# Remove test files
rm test_*.cs tes.cs
rm test_*.py debug_test.py parse_class_method.py
rm test_examples.bat

# Remove old docs (optional - backup first)
rm PROGRESS.md FINAL_OPTIONS.md STATUS_REPORT.md
rm ERROR_FIX_SUMMARY.md FINAL_SUMMARY.md app.md

# Clear cache
rm -rf __pycache__
```

---

## ✅ Verification After Cleanup

Test bahwa semua masih berfungsi:

```bash
# 1. Test REPL
cs
>>> var x = 10
>>> x
10
>>> keluar

# 2. Test file execution
cs examples/test_features.cs

# 3. Test help
cs --help

# 4. Test version
cs --version
```

Jika semua test pass, cleanup berhasil! ✅

---

## 📝 What to Keep for Reference

Jika ingin simpan file untuk reference, buat folder `archive/`:

```bash
mkdir archive
mv test_*.cs archive/
mv PROGRESS.md FINAL_OPTIONS.md STATUS_REPORT.md archive/
```

Tapi untuk **production deployment**, file ini tidak diperlukan.

---

## 🎯 Final Checklist

After cleanup, pastikan ada:

- [x] 6 core Python files
- [x] 4 launcher files
- [x] 6 documentation files
- [x] examples/ folder dengan test_features.cs
- [x] calkulator/ folder dengan working demo
- [x] README.md yang jelas dan lengkap

**Total**: ~20 essential files = **Clean & Production Ready!** ✅
