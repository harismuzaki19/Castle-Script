#!/usr/bin/env python3
"""
CastleScript GUI Extension
Library GUI dengan bahasa Indonesia menggunakan Tkinter
"""

try:
    import tkinter as tk
    from tkinter import ttk, messagebox, simpledialog, filedialog
    GUI_AVAILABLE = True
except ImportError:
    GUI_AVAILABLE = False
    print("Warning: Tkinter tidak tersedia. Fungsi GUI tidak dapat digunakan.")

# Global variables untuk GUI
_gui_windows = {}
_gui_widgets = {}
_widget_counter = 0
_current_window = None
_evaluator = None  # Store evaluator reference
_environment = None  # Store environment reference

def get_gui_functions(evaluator=None, env=None):
    """Kembalikan semua fungsi GUI untuk CastleScript"""
    
    if not GUI_AVAILABLE:
        return {}
    
    global _widget_counter, _current_window, _evaluator, _environment
    
    # Store evaluator and environment for callback execution
    _evaluator = evaluator
    _environment = env
    
    # ===== FUNGSI JENDELA (WINDOW) =====
    
    def buat_jendela(judul="CastleScript GUI", lebar=400, tinggi=300):
        """Membuat jendela baru"""
        global _current_window
        window = tk.Tk()
        window.title(str(judul))
        window.geometry(f"{int(lebar)}x{int(tinggi)}")
        
        window_id = f"window_{len(_gui_windows)}"
        _gui_windows[window_id] = window
        _current_window = window
        
        return window_id
    
    def tutup_jendela(window_id=None):
        """Menutup jendela"""
        if window_id and window_id in _gui_windows:
            _gui_windows[window_id].destroy()
            del _gui_windows[window_id]
        elif _current_window:
            _current_window.destroy()
    
    def jalankan():
        """Menjalankan event loop GUI"""
        if _current_window:
            _current_window.mainloop()
    
    def atur_waktu(ms, fungsi_callback):
        """Menjalankan fungsi setelah penundaan (ms)"""
        if _current_window:
            def callback_wrapper():
                try:
                    if callable(fungsi_callback):
                        fungsi_callback()
                    elif isinstance(fungsi_callback, tuple) and fungsi_callback[0] == 'function':
                        if _evaluator and _environment:
                            _, params, body = fungsi_callback
                            from castlescript import Environment, ReturnValue
                            func_env = Environment(_environment)
                            try:
                                _evaluator.eval(body, func_env)
                            except Exception as e:
                                if type(e).__name__ == 'ReturnValue':
                                    pass
                                else:
                                    raise e
                except Exception as e:
                    print(f"Error in timer callback: {e}")
            
            _current_window.after(int(ms), callback_wrapper)

    
    def atur_warna_latar(warna):
        """Mengatur warna latar belakang jendela"""
        if _current_window:
            _current_window.configure(bg=str(warna))
    
    # ===== FUNGSI LABEL (TEXT) =====
    
    def buat_label(teks, x=0, y=0, ukuran_font=12, warna_teks="black", warna_latar=None):
        """Membuat label teks"""
        global _widget_counter
        if not _current_window:
            return None
        
        label_config = {
            'text': str(teks),
            'font': ("Arial", int(ukuran_font), "bold"),
            'fg': str(warna_teks)
        }
        
        if warna_latar:
            label_config['bg'] = str(warna_latar)
        
        label = tk.Label(_current_window, **label_config)
        label.place(x=int(x), y=int(y))
        
        widget_id = f"label_{_widget_counter}"
        _widget_counter += 1
        _gui_widgets[widget_id] = label
        
        return widget_id
    
    def ubah_teks_label(widget_id, teks_baru):
        """Mengubah teks label"""
        if widget_id in _gui_widgets:
            _gui_widgets[widget_id].config(text=str(teks_baru))
    
    # ===== FUNGSI TOMBOL (BUTTON) =====
    
    def buat_tombol(teks, fungsi_callback, x=0, y=0, lebar=10, tinggi=2, warna_latar="#4CAF50", warna_teks="white", ukuran_font=12):
        """Membuat tombol"""
        global _widget_counter
        if not _current_window:
            return None
        
        # Callback wrapper that handles both Python callables and CastleScript functions
        def callback_wrapper():
            try:
                # Check if it's a Python callable
                if callable(fungsi_callback):
                    fungsi_callback()
                # Check if it's a CastleScript function (tuple format)
                elif isinstance(fungsi_callback, tuple) and fungsi_callback[0] == 'function':
                    if _evaluator and _environment:
                        # Extract function info
                        _, params, body = fungsi_callback
                        
                        # CastleScript functions with no parameters for button callbacks
                        if len(params) == 0:
                            # Import the necessary classes
                            from castlescript import Environment, ReturnValue
                            
                            # Create function environment
                            func_env = Environment(_environment)
                            
                            # Execute function body
                            try:
                                _evaluator.eval(body, func_env)
                            except ReturnValue:
                                pass  # Ignore return values for GUI callbacks
                        else:
                            print(f"Warning: Callback function has {len(params)} parameters, but GUI callbacks take no arguments")
                else:
                    print(f"Warning: Invalid callback type: {type(fungsi_callback)}")
            except Exception as e:
                print(f"Error in callback: {e}")
                import traceback
                traceback.print_exc()
        
        button = tk.Button(
            _current_window, 
            text=str(teks),
            command=callback_wrapper,
            width=int(lebar),
            height=int(tinggi),
            font=("Arial", int(ukuran_font), "bold"),
            bg=str(warna_latar),
            fg=str(warna_teks),
            cursor="hand2",
            relief=tk.RAISED,
            bd=2,
            activebackground=str(warna_latar),
            activeforeground=str(warna_teks)
        )
        # Use pixel-based width and height in place()
        button.place(x=int(x), y=int(y), width=int(lebar), height=int(tinggi))
        
        
        widget_id = f"button_{_widget_counter}"
        _widget_counter += 1
        _gui_widgets[widget_id] = button
        
        return widget_id
    
    # ===== FUNGSI INPUT (ENTRY) =====
    
    def buat_input(x=0, y=0, lebar=20, ukuran_font=14, align="right"):
        """Membuat input field"""
        global _widget_counter
        if not _current_window:
            return None
        
        justify_map = {"left": tk.LEFT, "center": tk.CENTER, "right": tk.RIGHT}
        entry = tk.Entry(
            _current_window, 
            width=int(lebar), 
            font=("Arial", int(ukuran_font), "bold"),
            justify=justify_map.get(str(align).lower(), tk.RIGHT),
            bd=3,
            relief=tk.SUNKEN
        )
        entry.place(x=int(x), y=int(y))
        
        widget_id = f"entry_{_widget_counter}"
        _widget_counter += 1
        _gui_widgets[widget_id] = entry
        
        return widget_id
    
    def ambil_nilai_input(widget_id):
        """Mengambil nilai dari input field"""
        if widget_id in _gui_widgets:
            return _gui_widgets[widget_id].get()
        return ""
    
    def atur_nilai_input(widget_id, nilai):
        """Mengatur nilai input field"""
        if widget_id in _gui_widgets:
            widget = _gui_widgets[widget_id]
            widget.delete(0, tk.END)
            widget.insert(0, str(nilai))
    
    # ===== FUNGSI PESAN (MESSAGE BOX) =====
    
    def tampilkan_pesan(judul, pesan):
        """Menampilkan message box info"""
        messagebox.showinfo(str(judul), str(pesan))
    
    def tampilkan_error(judul, pesan):
        """Menampilkan message box error"""
        messagebox.showerror(str(judul), str(pesan))
    
    def tampilkan_konfirmasi(judul, pesan):
        """Menampilkan message box konfirmasi (Ya/Tidak)"""
        return messagebox.askyesno(str(judul), str(pesan))
    
    # ===== FUNGSI TEXT AREA =====
    
    def buat_area_teks(x=0, y=0, lebar=30, tinggi=10):
        """Membuat text area"""
        global _widget_counter
        if not _current_window:
            return None
        
        text_widget = tk.Text(_current_window, width=int(lebar), height=int(tinggi), font=("Arial", 10))
        text_widget.place(x=int(x), y=int(y))
        
        widget_id = f"text_{_widget_counter}"
        _widget_counter += 1
        _gui_widgets[widget_id] = text_widget
        
        return widget_id
    
    def tambah_teks(widget_id, teks):
        """Menambah teks ke text area"""
        if widget_id in _gui_widgets:
            _gui_widgets[widget_id].insert(tk.END, str(teks) + "\n")
    
    def hapus_area_teks(widget_id):
        """Menghapus semua teks dari text area"""
        if widget_id in _gui_widgets:
            _gui_widgets[widget_id].delete("1.0", tk.END)
    
    # ===== FUNGSI CANVAS (untuk menggambar) =====
    
    def buat_kanvas(x=0, y=0, lebar=300, tinggi=300):
        """Membuat canvas untuk menggambar"""
        global _widget_counter
        if not _current_window:
            return None
        
        canvas = tk.Canvas(_current_window, width=int(lebar), height=int(tinggi), bg="white")
        canvas.place(x=int(x), y=int(y))
        
        widget_id = f"canvas_{_widget_counter}"
        _widget_counter += 1
        _gui_widgets[widget_id] = canvas
        
        return widget_id
    
    def bersihkan_kanvas(canvas_id):
        """Menghapus semua gambar di canvas"""
        if canvas_id in _gui_widgets:
            _gui_widgets[canvas_id].delete("all")

    
    def gambar_persegi(canvas_id, x1, y1, x2, y2, warna="black"):
        """Menggambar persegi di canvas"""
        if canvas_id in _gui_widgets:
            _gui_widgets[canvas_id].create_rectangle(
                int(x1), int(y1), int(x2), int(y2),
                fill=str(warna)
            )
    
    def gambar_lingkaran(canvas_id, x1, y1, x2, y2, warna="black"):
        """Menggambar lingkaran di canvas"""
        if canvas_id in _gui_widgets:
            _gui_widgets[canvas_id].create_oval(
                int(x1), int(y1), int(x2), int(y2),
                fill=str(warna)
            )
    
    def gambar_garis(canvas_id, x1, y1, x2, y2, warna="black", tebal=1):
        """Menggambar garis di canvas"""
        if canvas_id in _gui_widgets:
            _gui_widgets[canvas_id].create_line(
                int(x1), int(y1), int(x2), int(y2),
                fill=str(warna), width=int(tebal)
            )

    def gambar_teks(canvas_id, x, y, teks, warna="black", ukuran=12):
        """Menggambar teks di canvas"""
        if canvas_id in _gui_widgets:
            _gui_widgets[canvas_id].create_text(
                int(x), int(y),
                text=str(teks),
                fill=str(warna),
                font=("Segoe UI Symbol", int(ukuran))
            )
    
    
    def bind_klik(widget_id, fungsi_callback):
        """Bind event klik kiri mouse ke widget"""
        if widget_id in _gui_widgets:
            widget = _gui_widgets[widget_id]
            
            def callback_wrapper(event):
                try:
                    # Siapkan argumen x, y
                    x = event.x
                    y = event.y
                    
                    # Jika callback adalah tuple (fungsi CS)
                    if isinstance(fungsi_callback, tuple) and fungsi_callback[0] == 'function':
                        if _evaluator and _environment:
                            _, params, body = fungsi_callback
                            
                            # Import classes
                            from castlescript import Environment, ReturnValue
                            
                            # Create env
                            func_env = Environment(_environment)
                            
                            # Pass arguments if function accepts them
                            if len(params) == 2:
                                func_env.set(params[0], x)
                                func_env.set(params[1], y)
                            elif len(params) == 0:
                                pass # No args
                            else:
                                print(f"Warning: Callback klik harus punya 0 atau 2 parameter (x, y)")
                                
                            # Eval
                            try:
                                _evaluator.eval(body, func_env)
                            except Exception as e:
                                if type(e).__name__ == 'ReturnValue':
                                    pass
                                else:
                                    raise e
                    # Jika callback adalah callable Python
                    elif callable(fungsi_callback):
                        fungsi_callback(x, y)
                except Exception as e:
                    print(f"Error in click callback: {e}")
                    import traceback
                    traceback.print_exc()
            
            widget.bind("<Button-1>", callback_wrapper)
            return True
        return False

    # ===== FUNGSI GRID LAYOUT =====
    
    def atur_posisi_grid(widget_id, baris, kolom, colspan=1, rowspan=1):
        """Mengatur widget dengan grid layout"""
        if widget_id in _gui_widgets:
            _gui_widgets[widget_id].place_forget()
            _gui_widgets[widget_id].grid(
                row=int(baris), column=int(kolom),
                columnspan=int(colspan), rowspan=int(rowspan),
                padx=5, pady=5
            )
    
    # Dictionary dengan semua fungsi GUI
    return {
        # Window functions
        'buat_jendela': buat_jendela,
        'tutup_jendela': tutup_jendela,
        'jalankan': jalankan,
        'atur_warna_latar': atur_warna_latar,
        'atur_waktu': atur_waktu,
        
        # Label functions
        'buat_label': buat_label,
        'ubah_teks_label': ubah_teks_label,
        
        # Button functions
        'buat_tombol': buat_tombol,
        
        # Input functions
        'buat_input': buat_input,
        'ambil_nilai_input': ambil_nilai_input,
        'atur_nilai_input': atur_nilai_input,
        
        # Message box functions
        'tampilkan_pesan': tampilkan_pesan,
        'tampilkan_error': tampilkan_error,
        'tampilkan_konfirmasi': tampilkan_konfirmasi,
        
        # Text area functions
        'buat_area_teks': buat_area_teks,
        'tambah_teks': tambah_teks,
        'hapus_area_teks': hapus_area_teks,
        
        # Canvas functions
        'buat_kanvas': buat_kanvas,
        'bersihkan_kanvas': bersihkan_kanvas,
        'gambar_persegi': gambar_persegi,
        'gambar_lingkaran': gambar_lingkaran,
        'gambar_garis': gambar_garis,
        'gambar_teks': gambar_teks,
        
        # Event Functions
        'bind_klik': bind_klik,
        
        # Layout functions
        'atur_posisi_grid': atur_posisi_grid,
    }
