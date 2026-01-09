# Castle-Script - Organized Repository Structure

Perfect structure untuk GitHub repository!

## 📁 Final Structure

```
Castle-Script/
├── README.md                    # Main documentation
├── SYNTAX.md                    # Syntax reference
├── EXTENDED_FEATURES.md         # Function reference
├── cs                           # macOS/Linux launcher
├── cs.bat                       # Windows launcher
├── castlescript                 # macOS/Linux alternative
├── castlescript.bat             # Windows alternative
├── .gitignore                   # Git ignore patterns
│
├── src/                         # Source code
│   ├── castlescript.py
│   ├── castlescript_extended.py
│   ├── castlescript_advanced.py
│   ├── castlescript_classes.py
│   ├── castlescript_gui.py
│   └── cs_repl.py
│
├── docs/                        # Additional documentation
│   ├── CONSOLE_MODE.md
│   ├── GUI_README.md
│   ├── SETUP_COMMAND.md
│   ├── CLEANUP_GUIDE.md
│   └── REFERENSI_LENGKAP.cs
│
├── examples/                    # Example programs
│   ├── hello.cs
│   ├── calculator.cs
│   ├── fibonacci.cs
│   ├── functions.cs
│   ├── hello_gui.cs
│   ├── loops.cs
│   └── test_features.cs
│
└── calkulator/                  # Calculator demo app
    ├── README.md
    ├── kalkulator.cs
    └── kalkulator_gui.cs
```

## Files to Move

### To src/:

- castlescript.py
- castlescript_extended.py
- castlescript_advanced.py
- castlescript_classes.py
- castlescript_gui.py
- cs_repl.py

### To docs/:

- CONSOLE_MODE.md
- GUI_README.md
- SETUP_COMMAND.md
- CLEANUP_GUIDE.md
- REFERENSI_LENGKAP.cs

### Keep in root:

- README.md
- SYNTAX.md
- EXTENDED_FEATURES.md
- cs
- cs.bat
- castlescript
- castlescript.bat
- .gitignore

### Folders (keep as-is):

- examples/
- calkulator/

## Move Commands

### Windows:

```cmd
# Move Python files to src/
move castlescript.py src\
move castlescript_extended.py src\
move castlescript_advanced.py src\
move castlescript_classes.py src\
move castlescript_gui.py src\
move cs_repl.py src\

# Move docs to docs/
move CONSOLE_MODE.md docs\
move GUI_README.md docs\
move SETUP_COMMAND.md docs\
move CLEANUP_GUIDE.md docs\
move REFERENSI_LENGKAP.cs docs\
```

### macOS/Linux:

```bash
# Move Python files to src/
mv castlescript.py src/
mv castlescript_extended.py src/
mv castlescript_advanced.py src/
mv castlescript_classes.py src/
mv castlescript_gui.py src/
mv cs_repl.py src/

# Move docs to docs/
mv CONSOLE_MODE.md docs/
mv GUI_README.md docs/
mv SETUP_COMMAND.md docs/
mv CLEANUP_GUIDE.md docs/
mv REFERENSI_LENGKAP.cs docs/
```

## Launchers Already Updated

All launcher scripts (cs.bat, cs, castlescript.bat, castlescript) have been updated to reference `src/` directory.

## After Moving

Test that everything works:

```bash
cs --version
cs examples/hello.cs
```

Should work perfectly!

## Benefits

- Clean root directory
- Professional structure
- Easy to navigate
- Standard GitHub layout
- Source code organized
- Documentation separated
