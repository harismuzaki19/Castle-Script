# Setup Guide

This guide shows how to set up the `cs` command for Castle-Script on different platforms.

## Windows

### Option 1: Add to PATH

1. Open System Properties
2. Go to Environment Variables
3. Edit the PATH variable
4. Add your Castle-Script directory (e.g., `C:\Castle-Script`)
5. Click OK

Now you can use:

```cmd
cs program.cs
cs --help
cs --version
```

### Option 2: Run directly

```cmd
cd C:\Castle-Script
cs program.cs
```

Or without PATH setup:

```cmd
python castlescript.py program.cs
```

## macOS/Linux

### Step 1: Make executable

```bash
cd /path/to/Castle-Script
chmod +x cs
```

### Step 2: Add to PATH

Edit `~/.bashrc` or `~/.zshrc`:

```bash
export PATH="$PATH:/path/to/Castle-Script"
```

Then reload:

```bash
source ~/.bashrc
```

### Step 3: Use

```bash
cs program.cs
cs --help
cs --version
```

Or without PATH setup:

```bash
./cs program.cs
```

## Verification

Test that it works:

```bash
cs --version
```

Expected output:

```
CastleScript versi 0.9.1 Beta
Bahasa Pemrograman Indonesia
...
```

## Troubleshooting

### Command not found

- Make sure the directory is in PATH
- Restart terminal after changing PATH
- Check that `cs.bat` (Windows) or `cs` (macOS/Linux) exists

### Python not found

Install Python 3.x from python.org

### Permission denied (macOS/Linux)

Run:

```bash
chmod +x cs
```

## Alternative Method

You can always run without the `cs` command:

```bash
castlescript your_program.cs
castlescript cs_repl.py  # for interactive mode
```
