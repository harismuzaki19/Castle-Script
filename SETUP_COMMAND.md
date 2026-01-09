# CastleScript - Simple Command Setup

## Quick Command: `cs file.cs`

Gunakan command sederhana untuk menjalankan CastleScript files di semua platform!

---

## 🪟 Windows Setup

### Option 1: Via PATH (Recommended)

1. **Copy file `cs.bat`** ke folder CastleScript
2. **Tambahkan ke PATH**:

   - Tekan `Win + X` → System → Advanced System Settings
   - Environment Variables → System Variables → Path → Edit
   - Tambahkan: `C:\Users\haris\OneDrive\Desktop\Castle Script`
   - Klik OK

3. **Test**:
   ```cmd
   cs test.cs
   ```

### Option 2: Langsung dari Folder

```cmd
cd "C:\Users\haris\OneDrive\Desktop\Castle Script"
cs examples\test_features.cs
```

---

## 🍎 macOS Setup

### Step 1: Make Executable

```bash
cd "/Users/yourusername/Castle Script"
chmod +x cs
```

### Step 2: Add to PATH

**Edit profile** (`~/.zshrc` or `~/.bash_profile`):

```bash
# Add CastleScript to PATH
export PATH="$PATH:/Users/yourusername/Castle Script"
```

**Reload**:

```bash
source ~/.zshrc
```

### Step 3: Test

```bash
cs test.cs
```

---

## 🐧 Linux Setup

### Step 1: Make Executable

```bash
cd ~/CastleScript
chmod +x cs
```

### Step 2: Add to PATH

**Edit `~/.bashrc` atau `~/.profile`**:

```bash
# Add CastleScript to PATH
export PATH="$PATH:$HOME/CastleScript"
```

**Reload**:

```bash
source ~/.bashrc
```

### Step 3: Test

```bash
cs test.cs
```

---

## 📋 Usage Examples

### Basic Usage

```bash
# Windows
cs hello.cs
cs examples\test_features.cs

# macOS/Linux
cs hello.cs
cs examples/test_features.cs
```

### With Arguments (Future Feature)

```bash
cs myapp.cs arg1 arg2
```

### Interactive Mode (Future Feature)

```bash
cs
> var x = 10
> tulis(x)
```

---

## ✅ Verification

**Test if setup worked**:

```bash
# Should show usage
cs

# Should run the file
cs examples/test_features.cs
```

**Expected output**:

```
CastleScript - Bahasa Pemrograman Indonesia
Penggunaan: cs file.cs
```

---

## 🔧 Troubleshooting

### Windows

**Problem**: `'cs' is not recognized...`

- **Solution**: Make sure folder is in PATH and restart terminal

**Problem**: `Python not found`

- **Solution**: Install Python 3.x and add to PATH

### macOS/Linux

**Problem**: `cs: command not found`

- **Solution**: Check if folder is in PATH: `echo $PATH`
- Make sure file is executable: `chmod +x cs`

**Problem**: `python3: command not found`

- **Solution**: Install Python 3: `sudo apt install python3` (Linux) or use Homebrew (macOS)

---

## 🚀 Quick Start After Setup

```bash
# Test core features
cs examples/test_features.cs

# Test all functions
cs test_comprehensive.cs

# Run calculator
cs calkulator/kalkulator_gui.cs

# Your own program
cs myprogram.cs
```

---

## 📦 Files Created

- **Windows**: `cs.bat` - Batch launcher
- **macOS/Linux**: `cs` - Shell script launcher

Both files automatically find `castlescript.py` in the same directory!

---

## ⚙️ Advanced Configuration

### Custom Python Path

**Windows** (`cs.bat`):

```batch
REM Use specific Python version
"C:\Python312\python.exe" "%SCRIPT_DIR%castlescript.py" %*
```

**macOS/Linux** (`cs`):

```bash
# Use specific Python version
/usr/bin/python3.12 "$SCRIPT_DIR/castlescript.py" "$@"
```

### Add to System-Wide Path

**Windows**: Copy `cs.bat` to `C:\Windows\System32`

**macOS/Linux**:

```bash
sudo ln -s /path/to/cs /usr/local/bin/cs
```

---

## 🎯 Summary

**Simple command** untuk semua platform:

| Platform | Command      | Setup Time |
| -------- | ------------ | ---------- |
| Windows  | `cs file.cs` | 2 minutes  |
| macOS    | `cs file.cs` | 3 minutes  |
| Linux    | `cs file.cs` | 3 minutes  |

**CastleScript is now accessible dari mana saja!** 🎉
