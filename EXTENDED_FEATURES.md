# Extended Features Reference

This document provides a complete reference for all built-in functions available in CastleScript.

## Arrays

### tambah(array, element)

Adds an element to the end of an array.

```castlescript
var arr = [1, 2, 3]
tambah(arr, 4)
// arr is now [1, 2, 3, 4]
```

### hapus(array, index)

Removes an element at the specified index.

```castlescript
var arr = [1, 2, 3]
hapus(arr, 1)
// arr is now [1, 3]
```

### sisip(array, index, element)

Inserts an element at the specified position.

```castlescript
var arr = [1, 3]
sisip(arr, 1, 2)
// arr is now [1, 2, 3]
```

### gabung(array1, array2)

Concatenates two arrays.

```castlescript
var result = gabung([1, 2], [3, 4])
// returns [1, 2, 3, 4]
```

### irisan(array, start, end)

Returns a slice of the array from start to end (exclusive).

```castlescript
var arr = [1, 2, 3, 4, 5]
var slice = irisan(arr, 1, 3)
// returns [2, 3]
```

### balik(array)

Reverses the array.

```castlescript
var arr = [1, 2, 3]
var reversed = balik(arr)
// returns [3, 2, 1]
```

### urutkan(array)

Sorts the array in ascending order.

```castlescript
var arr = [3, 1, 2]
var sorted = urutkan(arr)
// returns [1, 2, 3]
```

## Strings

### potong(string, start, end)

Extracts a substring.

```castlescript
var text = "Hello World"
var sub = potong(text, 0, 5)
// returns "Hello"
```

### pisah(string, delimiter)

Splits a string into an array.

```castlescript
var text = "a,b,c"
var parts = pisah(text, ",")
// returns ["a", "b", "c"]
```

### gabung_teks(array, separator)

Joins array elements into a string.

```castlescript
var arr = ["a", "b", "c"]
var text = gabung_teks(arr, "-")
// returns "a-b-c"
```

### ganti(string, old, new)

Replaces all occurrences of old with new.

```castlescript
var text = "hello world"
var replaced = ganti(text, "world", "CastleScript")
// returns "hello CastleScript"
```

### huruf_besar(string)

Converts to uppercase.

```castlescript
huruf_besar("hello")  // returns "HELLO"
```

### huruf_kecil(string)

Converts to lowercase.

```castlescript
huruf_kecil("HELLO")  // returns "hello"
```

### rapikan(string)

Removes leading and trailing whitespace.

```castlescript
rapikan("  hello  ")  // returns "hello"
```

### mengandung(string, substring)

Checks if string contains substring.

```castlescript
mengandung("hello world", "world")  // returns true
```

### mulai_dengan(string, prefix)

Checks if string starts with prefix.

```castlescript
mulai_dengan("hello", "he")  // returns true
```

### akhiri_dengan(string, suffix)

Checks if string ends with suffix.

```castlescript
akhiri_dengan("hello", "lo")  // returns true
```

### indeks(string, substring)

Finds the index of substring.

```castlescript
indeks("hello", "ll")  // returns 2
```

## Math Functions

### absolut(number)

Returns absolute value.

```castlescript
absolut(-5)  // returns 5
```

### pangkat(base, exponent)

Raises base to the power of exponent.

```castlescript
pangkat(2, 3)  // returns 8
```

### akar(number)

Returns square root.

```castlescript
akar(16)  // returns 4
```

### bulatkan(number)

Rounds to nearest integer.

```castlescript
bulatkan(3.7)  // returns 4
```

### lantai(number)

Rounds down to integer.

```castlescript
lantai(3.9)  // returns 3
```

### langit(number)

Rounds up to integer.

```castlescript
langit(3.1)  // returns 4
```

### minimal(...)

Returns the smallest value.

```cast lescript
minimal(5, 2, 8)  // returns 2
```

### maksimal(...)

Returns the largest value.

```castlescript
maksimal(5, 2, 8)  // returns 8
```

### angka_acak()

Returns random number between 0 and 1.

```castlescript
var rand = angka_acak()
```

### acak_antara(min, max)

Returns random integer between min and max (inclusive).

```castlescript
var dice = acak_antara(1, 6)
```

## File Operations

### baca_file(path)

Reads file contents as string.

```castlescript
var content = baca_file("data.txt")
```

### tulis_file(path, content)

Writes content to file.

```castlescript
tulis_file("output.txt", "Hello World")
```

### tambah_file(path, content)

Appends content to file.

```castlescript
tambah_file("log.txt", "New line\n")
```

### hapus_file(path)

Deletes a file.

```castlescript
hapus_file("temp.txt")
```

### ada_file(path)

Checks if file exists.

```castlescript
jika (ada_file("config.txt")) {
    tulis("Config found")
}
```

### buat_folder(path)

Creates a directory.

```castlescript
buat_folder("output")
```

### daftar_file(path)

Lists files in directory.

```castlescript
var files = daftar_file(".")
```

## Date and Time

### waktu_sekarang()

Returns current timestamp.

```castlescript
var now = waktu_sekarang()
```

### tanggal_sekarang()

Returns current date as string.

```castlescript
var date = tanggal_sekarang()
```

### format_waktu(timestamp, format)

Formats timestamp according to format string.

```castlescript
var formatted = format_waktu(waktu_sekarang(), "%Y-%m-%d")
```

### tahun(timestamp)

Extracts year from timestamp.

```castlescript
var y = tahun(waktu_sekarang())
```

### bulan(timestamp)

Extracts month from timestamp.

```castlescript
var m = bulan(waktu_sekarang())
```

### hari(timestamp)

Extracts day from timestamp.

```castlescript
var d = hari(waktu_sekarang())
```

## JSON

### dari_json(string)

Parses JSON string to object/array.

```castlescript
var obj = dari_json('{"name": "test"}')
tulis(obj.name)  // prints "test"
```

### ke_json(value)

Converts value to JSON string.

```castlescript
var obj = {name: "test", value: 123}
var json = ke_json(obj)
```

## Regular Expressions

### cocokkan(text, pattern)

Finds all matches of regex pattern in text.

```castlescript
var matches = cocokkan("abc123def", "[0-9]+")
// returns ["123"]
```

### ganti_regex(text, pattern, replacement)

Replaces regex matches with replacement.

```castlescript
var result = ganti_regex("abc123", "[0-9]+", "X")
// returns "abcX"
```

### tes_regex(text, pattern)

Tests if pattern matches text.

```castlescript
var matches = tes_regex("abc123", "[0-9]")
// returns true
```

### pisah_regex(text, pattern)

Splits text using regex pattern.

```castlescript
var parts = pisah_regex("a1b2c3", "[0-9]")
// returns ["a", "b", "c", ""]
```

## Advanced Array Methods

These functions take a callback function as parameter.

### petakan(array, function)

Maps each element through a function (like map in JavaScript).

```castlescript
fungsi double(x) { kembalikan x * 2 }
var doubled = petakan([1, 2, 3], double)
// returns [2, 4, 6]
```

### saring(array, function)

Filters array using predicate function.

```castlescript
fungsi is_even(x) { kembalikan x % 2 == 0 }
var evens = saring([1, 2, 3, 4], is_even)
// returns [2, 4]
```

### kurangi(array, function, initial)

Reduces array to single value.

```castlescript
fungsi sum(a, b) { kembalikan a + b }
var total = kurangi([1, 2, 3], sum, 0)
// returns 6
```

### untuk_setiap(array, function)

Executes function for each element.

```castlescript
fungsi print_double(x) { tulis(x * 2) }
untuk_setiap([1, 2, 3], print_double)
```

### cari(array, function)

Finds first element matching predicate.

```castlescript
fungsi gt_2(x) { kembalikan x > 2 }
var found = cari([1, 2, 3, 4], gt_2)
// returns 3
```

### ada_yang(array, function)

Tests if any element matches predicate.

```castlescript
fungsi is_positive(x) { kembalikan x > 0 }
var has_positive = ada_yang([-1, 0, 1], is_positive)
// returns true
```

### semua_nya(array, function)

Tests if all elements match predicate.

```castlescript
fungsi is_positive(x) { kembalikan x > 0 }
var all_positive = semua_nya([1, 2, 3], is_positive)
// returns true
```

### indeks_dari(array, element)

Finds index of element in array.

```castlescript
var idx = indeks_dari([10, 20, 30], 20)
// returns 1
```

## Type Checking

### adalah_array(value)

Checks if value is an array.

```castlescript
adalah_array([1, 2])  // returns true
```

### adalah_object(value)

Checks if value is an object.

```castlescript
adalah_object({a: 1})  // returns true
```

### adalah_fungsi(value)

Checks if value is a function.

```castlescript
fungsi test() { }
adalah_fungsi(test)  // returns true
```

### adalah_angka(value)

Checks if value is a number.

```castlescript
adalah_angka(123)  // returns true
```

### adalah_teks(value)

Checks if value is a string.

```castlescript
adalah_teks("hello")  // returns true
```

### adalah_boolean(value)

Checks if value is boolean.

```castlescript
adalah_boolean(benar)  // returns true
```

## String Utilities

### ulangi_teks(string, count)

Repeats string n times.

```castlescript
ulangi_teks("ab", 3)  // returns "ababab"
```

### balik_teks(string)

Reverses a string.

```castlescript
balik_teks("hello")  // returns "olleh"
```

### abjad(string)

Splits string into array of characters.

```castlescript
abjad("abc")  // returns ["a", "b", "c"]
```

### padl(string, length, char=" ")

Pads string on the left to specified length.

```castlescript
padl("5", 3, "0")  // returns "005"
```

### padr(string, length, char=" ")

Pads string on the right to specified length.

```castlescript
padr("hi", 5)  // returns "hi   "
```

## Core Functions

### tulis(...)

Prints values to console.

```castlescript
tulis("Hello World")
tulis("Value:", 42)
```

### baca()

Reads input from user.

```castlescript
var name = baca()
tulis("Hello, " + name)
```

### panjang(collection)

Returns length of array or string.

```castlescript
panjang([1, 2, 3])  // returns 3
panjang("hello")    // returns 5
```

### tipe(value)

Returns type of value as string.

```castlescript
tipe(123)       // returns "number"
tipe("hello")   // returns "string"
tipe([1, 2])    // returns "array"
```

### ke_angka(value)

Converts value to number.

```castlescript
ke_angka("123")  // returns 123
```

### ke_teks(value)

Converts value to string.

```castlescript
ke_teks(123)  // returns "123"
```

## Notes

All functions are available globally without needing to import anything. Error handling is built-in for most operations.

For GUI functions, see GUI_README.md.
