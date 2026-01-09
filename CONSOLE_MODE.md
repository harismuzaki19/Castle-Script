# CastleScript Console/REPL Mode

## 🎯 Interactive Console Seperti Python/JavaScript

CastleScript sekarang punya **interactive console (REPL)** yang bekerja sama seperti Python atau Node.js!

---

## 🚀 Cara Menggunakan

### Masuk ke Console Mode

```bash
# Windows
cs

# macOS/Linux
cs
```

### Output yang Muncul:

```
╔════════════════════════════════════════╗
║   CastleScript - Mode Interaktif      ║
║   Bahasa Pemrograman Indonesia        ║
║   Versi: 2.0 Extended                 ║
╚════════════════════════════════════════╝

Ketik 'keluar' untuk keluar, 'help' untuk bantuan

>>>
```

---

## 💻 Contoh Penggunaan

### 1. Basic Operations (Seperti Python)

```
>>> 5 + 3
8

>>> 10 / 2
5.0

>>> "Hello" + " World"
Hello World

>>> benar dan salah
False
```

### 2. Variables (Seperti JavaScript)

```
>>> var x = 10
>>> x
10

>>> var nama = "Budi"
>>> nama
Budi

>>> x * 2
20
```

### 3. Arrays & Objects

```
>>> var arr = [1, 2, 3, 4, 5]
>>> arr
[1, 2, 3, 4, 5]

>>> arr[0]
1

>>> var obj = {nama: "Ali", umur: 25}
>>> obj.nama
Ali
```

### 4. Functions

```
>>> fungsi tambah(a, b) { kembalikan a + b }
>>> tambah(5, 3)
8

>>> fungsi sapa(nama) { tulis("Halo " + nama) }
>>> sapa("Budi")
Halo Budi
```

### 5. Built-in Functions

```
>>> huruf_besar("hello")
HELLO

>>> akar(16)
4.0

>>> panjang([1, 2, 3])
3

>>> urutkan([3, 1, 2])
[1, 2, 3]
```

### 6. Advanced Functions (map/filter/reduce)

```
>>> fungsi double(x) { kembalikan x * 2 }
>>> petakan([1, 2, 3], double)
[2, 4, 6]

>>> fungsi is_even(x) { kembalikan x % 2 == 0 }
>>> saring([1, 2, 3, 4], is_even)
[2, 4]
```

---

## 📝 Special Commands

| Command                  | Description                           |
| ------------------------ | ------------------------------------- |
| `keluar`, `exit`, `quit` | Keluar dari console                   |
| `help`                   | Tampilkan bantuan REPL                |
| `Ctrl+C`                 | Interrupt (tidak keluar, hanya batal) |
| `Ctrl+D` atau `Ctrl+Z`   | Keluar dari console                   |

---

## 🆚 Comparison with Python/JavaScript

### Python REPL:

```python
>>> x = 10
>>> x
10
>>> def add(a, b):
...     return a + b
>>> add(5, 3)
8
```

### JavaScript/Node REPL:

```javascript
> let x = 10
undefined
> x
10
> function add(a, b) { return a + b }
undefined
> add(5, 3)
8
```

### CastleScript REPL:

```castlescript
>>> var x = 10
>>> x
10
>>> fungsi tambah(a, b) { kembalikan a + b }
>>> tambah(5, 3)
8
```

**✅ Sama persis dengan Python/JavaScript!**

---

## 🎨 Features Yang Sama

| Feature               | Python | Node.js | CastleScript |
| --------------------- | ------ | ------- | ------------ |
| Expression evaluation | ✅     | ✅      | ✅           |
| Variable persistence  | ✅     | ✅      | ✅           |
| Function definitions  | ✅     | ✅      | ✅           |
| Auto-print values     | ✅     | ✅      | ✅           |
| Error handling        | ✅     | ✅      | ✅           |
| Multi-line input      | ✅     | ✅      | 🔄 Coming    |
| History/Up arrow      | ✅     | ✅      | 🔄 Coming    |
| Tab completion        | ✅     | ✅      | 🔄 Coming    |

---

## 🎯 Usage Scenarios

### 1. Quick Calculations

```
>>> 123 * 456
56088
>>> akar(144)
12.0
```

### 2. Testing Functions

```
>>> fungsi faktorial(n) {
...   jika (n <= 1) { kembalikan 1 }
...   kembalikan n * faktorial(n - 1)
... }
>>> faktorial(5)
120
```

### 3. Data Exploration

```
>>> var data = dari_json('{"name": "test"}')
>>> data.name
test
```

### 4. Learning & Experimentation

```
>>> var numbers = [1, 2, 3, 4, 5]
>>> petakan(numbers, fungsi(x) { kembalikan x * x })
[1, 4, 9, 16, 25]
```

---

## 🛠️ How It Works

1. **Input**: User types expression/statement
2. **Parse**: Lexer → Parser → AST
3. **Eval**: Evaluate in persistent environment
4. **Print**: Auto-display non-None results
5. **Loop**: Repeat

**Same as**: Python's `code.InteractiveConsole` and Node.js REPL

---

## 📚 Advanced Examples

### File Operations in REPL

```
>>> tulis_file("test.txt", "Hello World")
>>> var content = baca_file("test.txt")
>>> tulis(content)
Hello World
```

### JSON Processing

```
>>> var obj = {nama: "Budi", umur: 25}
>>> var json = ke_json(obj)
>>> tulis(json)
{
  "nama": "Budi",
  "umur": 25
}
```

### Array Processing

```
>>> var nums = [1, 2, 3, 4, 5]
>>> var doubled = petakan(nums, fungsi(x) { kembalikan x * 2 })
>>> var sum = kurangi(doubled, fungsi(a,b) { kembalikan a + b }, 0)
>>> sum
30
```

---

## 🎓 Educational Use

Perfect untuk pembelajaran:

```
>>> tulis("Hello World")
Hello World

>>> var x = 10
>>> var y = 20
>>> tulis("Sum: " + ke_teks(x + y))
Sum: 30
```

Same experience as:

- Python interactive shell
- Node.js REPL
- Ruby IRB
- JavaScript console

---

## ✅ Current Status

**Working Features**:

- ✅ Expression evaluation
- ✅ Statement execution
- ✅ Variable persistence
- ✅ Function definitions
- ✅ Auto-print results
- ✅ Error handling
- ✅ All 70 built-in functions accessible
- ✅ Help command
- ✅ Exit commands

**Future Enhancements** (Optional):

- Multi-line editing (like Python's `...`)
- Command history (arrow keys)
- Tab completion
- Syntax highlighting

---

## 🚀 Quick Start

```bash
# 1. Masuk ke console
cs

# 2. Try it!
>>> var x = 10
>>> tulis(x)
10

# 3. Use built-ins
>>> huruf_besar("hello")
HELLO

# 4. Exit
>>> keluar
```

**CastleScript console is ready!** 🎉

Sama seperti Python `python` atau JavaScript `node` - sekarang ada `cs`!
