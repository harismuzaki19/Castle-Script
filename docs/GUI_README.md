# GUI Programming Guide

Castle-Script has built-in GUI support using Tkinter, allowing you to create desktop applications.

## Basic Window

```castlescript
buat_jendela("My App", 400, 300)
jalankan()
```

This creates and displays a 400x300 window.

Running:

```bash
cs myapp.cs
```

## Widgets

### Label

```castlescript
buat_label("Hello World", 10, 10)
```

### Button

```castlescript
fungsi on_click() {
    tulis("Button clicked!")
}

buat_tombol("Click Me", on_click, 10, 50, 100, 30)
```

### Input Field

```castlescript
buat_input("name_input", 10, 100, 200, 25)
```

To get the value:

```castlescript
var name = ambil_nilai("name_input")
```

### Text Area

```castlescript
buat_textarea("notes", 10, 150, 300, 100)
```

## Complete Example

```castlescript
fungsi submit() {
    var name = ambil_nilai("name_input")
    tulis("Hello, " + name)
}

buat_jendela("Greeting App", 400, 200)
buat_label("Enter your name:", 10, 10)
buat_input("name_input", 10, 40, 200, 25)
buat_tombol("Submit", submit, 10, 80, 100, 30)
jalankan()
```

Run it:

```bash
cs greeting.cs
```

## Calculator Example

See `calkulator/kalkulator_gui.cs` for a complete working calculator application.

Run the calculator:

```bash
cs calkulator/kalkulator_gui.cs
```

## Available Functions

- `buat_jendela(title, width, height)` - Create window
- `buat_label(text, x, y)` - Create label
- `buat_tombol(text, handler, x, y, width, height)` - Create button
- `buat_input(id, x, y, width, height)` - Create input field
- `buat_textarea(id, x, y, width, height)` - Create text area
- `ambil_nilai(id)` - Get widget value
- `atur_nilai(id, value)` - Set widget value
- `jalankan()` - Start event loop

## Notes

- GUI functions use absolute positioning (x, y coordinates)
- All sizes are in pixels
- The window must call `jalankan()` at the end
- Event handlers are regular Castle-Script functions

## Tips

- Keep window functions organized
- Use meaningful IDs for inputs
- Test incrementally
- See examples folder for more demos
