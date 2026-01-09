#!/usr/bin/env python3
"""
CastleScript REPL - Interactive Console
Mode interaktif untuk CastleScript
"""

import sys
sys.path.insert(0, '.')

from castlescript import Lexer, Parser, Evaluator

VERSION = "0.9.1 Beta"

def show_help():
    """Show help information"""
    print("CastleScript - Bahasa Pemrograman Indonesia")
    print(f"Versi: {VERSION}")
    print()
    print("Penggunaan:")
    print("  cs <file.cs>               Jalankan file CastleScript")
    print("  cs                         Masuk ke mode interaktif (REPL)")
    print("  cs --help, -h              Tampilkan bantuan ini")
    print("  cs --version, -v           Tampilkan versi")
    print()
    print("Contoh:")
    print("  cs hello.cs                Jalankan hello.cs")
    print("  cs                         Mode interaktif")
    print()
    print("Mode Interaktif:")
    print("  >>> var x = 10")
    print("  >>> tulis(x)")
    print("  10")
    print("  >>> keluar")
    print()
    print("Dokumentasi: EXTENDED_FEATURES.md")

def show_version():
    """Show version information"""
    print(f"CastleScript versi {VERSION}")
    print("Bahasa Pemrograman Indonesia")
    print()
    print("Features:")
    print("  ✓ 70+ built-in functions")
    print("  ✓ Arrays, Objects, Strings")
    print("  ✓ File I/O, Math, JSON, Regex")
    print("  ✓ GUI support built-in")
    print("  ✓ 100% Indonesian syntax")
    print("  ✓ Interactive REPL mode")

def repl():
    """Interactive REPL mode"""
    print("╔════════════════════════════════════════╗")
    print("║   CastleScript - Mode Interaktif      ║")
    print("║   Bahasa Pemrograman Indonesia        ║")
    print(f"║   Versi: {VERSION:27s} ║")
    print("╚════════════════════════════════════════╝")
    print()
    print("Ketik 'keluar' untuk keluar, 'help' untuk bantuan")
    print()
    
    evaluator = Evaluator()
    evaluator.setup_builtins()
    env = evaluator.global_env
    
    while True:
        try:
            # Read
            line = input(">>> ")
            
            # Check for special commands
            if line.strip().lower() in ('keluar', 'exit', 'quit'):
                print("Sampai jumpa!")
                break
            
            if line.strip().lower() == 'help':
                print("Perintah REPL:")
                print("  keluar/exit/quit - Keluar dari REPL")
                print("  help            - Tampilkan bantuan ini")
                print()
                print("Contoh penggunaan:")
                print("  var x = 10")
                print("  tulis(x)")
                print("  var arr = [1, 2, 3]")
                print("  petakan(arr, fungsi(x) { kembalikan x * 2 })")
                continue
            
            if not line.strip():
                continue
            
            # Parse and Eval
            try:
                lexer = Lexer(line)
                tokens = lexer.tokenize()
                parser = Parser(tokens)
                ast = parser.parse()
                
                # Evaluate
                result = evaluator.eval(ast, env)
                
                # Print (if not None)
                if result is not None and result != '':
                    print(result)
                    
            except SyntaxError as e:
                print(f"SyntaxError: {e}")
            except Exception as e:
                error_name = type(e).__name__
                if "ReturnValue" not in error_name:
                    print(f"{error_name}: {e}")
                
        except KeyboardInterrupt:
            print("\nGunakan 'keluar' untuk keluar")
        except EOFError:
            print("\nSampai jumpa!")
            break

def run_file(filename):
    """Run CastleScript file"""
    try:
        with open(filename, 'r', encoding='utf-8') as f:
            code = f.read()
        
        lexer = Lexer(code)
        tokens = lexer.tokenize()
        
        parser = Parser(tokens)
        ast = parser.parse()
        
        evaluator = Evaluator()
        evaluator.setup_builtins()
        evaluator.eval(ast, evaluator.global_env)
        
    except FileNotFoundError:
        print(f"Error: File '{filename}' tidak ditemukan")
        sys.exit(1)
    except Exception as e:
        print(f"Error: {e}")
        import traceback
        traceback.print_exc()
        sys.exit(1)

def main():
    # No arguments - enter REPL
    if len(sys.argv) == 1:
        repl()
        return
    
    # Check for flags
    arg = sys.argv[1]
    
    if arg in ('--help', '-h', 'help'):
        show_help()
        return
    
    if arg in ('--version', '-v', 'version'):
        show_version()
        return
    
    # Run file
    if not arg.endswith('.cs'):
        print(f"Error: File harus berakhiran .cs (got: {arg})")
        sys.exit(1)
    
    run_file(arg)

if __name__ == '__main__':
    main()
