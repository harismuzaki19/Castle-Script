# Interactive Console (REPL)

Castle-Script has an interactive console similar to Python or Node.js, allowing you to run commands interactively.

## Starting the Console

```bash
cs
```

Or if `cs` command is not set up:

```bash
castlescript
```

## Example Session

```
╔════════════════════════════════════════╗
║   CastleScript - Mode Interaktif      ║
║   Bahasa Pemrograman Indonesia        ║
║   Versi: 0.9.1 Beta                   ║
╚════════════════════════════════════════╝

Ketik 'keluar' untuk keluar, 'help' untuk bantuan

>>> var x = 10
>>> x
10
>>> x * 2
20
```

## Basic Usage

### Variables

```
>>> var name = "Budi"
>>> name
Budi
```

### Math

```
>>> 5 + 3
8
>>> akar(16)
4.0
```

### Arrays

```
>>> var arr = [1, 2, 3]
>>> panjang(arr)
3
>>> arr[0]
1
```

### Functions

```
>>> fungsi double(x) { kembalikan x * 2 }
>>> double(5)
10
```

### Advanced Functions

```
>>> fungsi square(x) { kembalikan x * x }
>>> petakan([1, 2, 3], square)
[1, 4, 9]
```

## Special Commands

- `keluar` or `exit` or `quit` - Exit console
- `help` - Show help
- `Ctrl+C` - Interrupt (doesn't exit)
- `Ctrl+D` or `Ctrl+Z` - Exit console

## Tips

- All variables persist across commands in the same session
- You can define functions and use them later
- Expression results are automatically printed
- Errors are caught and displayed without crashing the console

## Example: Data Exploration

```
>>> var data = [95, 78, 82, 90, 88]
>>> fungsi sum(a, b) { kembalikan a + b }
>>> var total = kurangi(data, sum, 0)
>>> total
433
>>> var avg = total / panjang(data)
>>> avg
86.6
```

## Compared to Python/JavaScript

The Castle-Script console works the same way:

**Python**:

```python
>>> x = 10
>>> x * 2
20
```

**JavaScript (Node)**:

```javascript
> let x = 10
10
> x * 2
20
```

**Castle-Script**:

```castlescript
>>> var x = 10
>>> x * 2
20
```

## Notes

- Variable names and functions persist in the session
- All 70+ built-in functions are available
- GUI functions are available but may not work in console mode
