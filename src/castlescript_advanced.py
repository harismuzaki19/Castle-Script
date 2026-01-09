#!/usr/bin/env python3
"""
CastleScript Advanced Features - FIXED VERSION
Higher-order functions with proper exception handling
"""

def get_advanced_functions(evaluator=None, env=None):
    """Return advanced built-in functions that need evaluator access"""
    
    # Store evaluator and environment for callback execution
    _evaluator = evaluator
    _environment = env
    
    # Import here to avoid circular dependency
    from castlescript import Environment, ReturnValue
    
    def call_castlescript_function(func, args):
        """Helper to call CastleScript function from Python - FIXED"""
        # Wrap everything in try-except to catch any escaping ReturnValue
        try:
            if callable(func):
                # Python function - call directly
                return func(*args)
            elif isinstance(func, tuple) and len(func) >= 3 and func[0] == 'function':
                # CastleScript function
                if not _evaluator or not _environment:
                    raise RuntimeError("Evaluator not available for CastleScript functions")
                
                _, params, body = func[0], func[1], func[2]
                
                # Create function environment
                func_env = Environment(_environment)
                
                # Bind parameters
                for i, param in enumerate(params):
                    if i < len(args):
                        func_env.set(param, args[i])
                
                # Execute function body - this may raise ReturnValue
                try:
                    result = _evaluator.eval(body, func_env)
                    # If we get here, function didn't use 'kembalikan'
                    return result
                except ReturnValue as ret:
                    # Normal case - function used 'kembalikan'
                    return ret.value
            else:
                raise TypeError(f"Invalid function type: {type(func)}")
        except ReturnValue as ret:
            # Safety net - catch any ReturnValue that escaped
            return ret.value
        except Exception as e:
            # Don't let other exceptions escape
            if "ReturnValue" in str(type(e).__name__):
                # It's a ReturnValue disguised as something else
                if hasattr(e, 'value'):
                    return e.value
                return None
            # Re-raise other real errors
            raise
    
    # ===== HIGHER-ORDER ARRAY FUNCTIONS =====
    
    def petakan(arr, func):
        """Map - transform each element"""
        if not isinstance(arr, list):
            raise TypeError("petakan() memerlukan array sebagai argument pertama")
        
        result = []
        for item in arr:
            try:
                mapped = call_castlescript_function(func, [item])
                result.append(mapped)
            except Exception as e:
                # Handle any unexpected errors gracefully
                raise RuntimeError(f"Error in petakan: {e}")
        return result
    
    def saring(arr, func):
        """Filter - select elements that match predicate"""
        if not isinstance(arr, list):
            raise TypeError("saring() memerlukan array sebagai argument pertama")
        
        result = []
        for item in arr:
            try:
                if call_castlescript_function(func, [item]):
                    result.append(item)
            except Exception as e:
                raise RuntimeError(f"Error in saring: {e}")
        return result
    
    def kurangi(arr, func, initial=0):
        """Reduce - accumulate array to single value"""
        if not isinstance(arr, list):
            raise TypeError("kurangi() memerlukan array sebagai argument pertama")
        
        accumulator = initial
        for item in arr:
            try:
                accumulator = call_castlescript_function(func, [accumulator, item])
            except Exception as e:
                raise RuntimeError(f"Error in kurangi: {e}")
        return accumulator
    
    def untuk_setiap(arr, func):
        """ForEach - execute function for each element"""
        if not isinstance(arr, list):
            raise TypeError("untuk_setiap() memerlukan array sebagai argument pertama")
        
        for item in arr:
            try:
                call_castlescript_function(func, [item])
            except Exception as e:
                raise RuntimeError(f"Error in untuk_setiap: {e}")
        return None
    
    def cari(arr, func):
        """Find - return first element matching predicate"""
        if not isinstance(arr, list):
            raise TypeError("cari() memerlukan array sebagai argument pertama")
        
        for item in arr:
            try:
                if call_castlescript_function(func, [item]):
                    return item
            except Exception as e:
                raise RuntimeError(f"Error in cari: {e}")
        return None
    
    def ada_yang(arr, func):
        """Some - check if any element matches predicate"""
        if not isinstance(arr, list):
            raise TypeError("ada_yang() memerlukan array sebagai argument pertama")
        
        for item in arr:
            try:
                if call_castlescript_function(func, [item]):
                    return True
            except Exception as e:
                raise RuntimeError(f"Error in ada_yang: {e}")
        return False
    
    def semua_nya(arr, func):
        """Every - check if all elements match predicate"""
        if not isinstance(arr, list):
            raise TypeError("semua_nya() memerlukan array sebagai argument pertama")
        
        for item in arr:
            try:
                if not call_castlescript_function(func, [item]):
                    return False
            except Exception as e:
                raise RuntimeError(f"Error in semua_nya: {e}")
        return True
    
    def indeks_dari(arr, item):
        """IndexOf - find index of item"""
        if not isinstance(arr, list):
            raise TypeError("indeks_dari() memerlukan array")
        try:
            return arr.index(item)
        except ValueError:
            return -1
    
    # ===== TYPE CHECKING FUNCTIONS =====
    
    def adalah_array(val):
        """Check if value is array"""
        return isinstance(val, list)
    
    def adalah_object(val):
        """Check if value is object/dict"""
        return isinstance(val, dict)
    
    def adalah_fungsi(val):
        """Check if value is function"""
        return callable(val) or (isinstance(val, tuple) and len(val) >= 3 and val[0] == 'function')
    
    def adalah_angka(val):
        """Check if value is number"""
        return isinstance(val, (int, float)) and not isinstance(val, bool)
    
    def adalah_teks(val):
        """Check if value is string"""
        return isinstance(val, str)
    
    def adalah_boolean(val):
        """Check if value is boolean"""
        return isinstance(val, bool)
    
    # ===== MORE STRING FUNCTIONS =====
    
    def ulangi_teks(text, count):
        """Repeat string n times"""
        return str(text) * int(count)
    
    def balik_teks(text):
        """Reverse string"""
        return str(text)[::-1]
    
    def abjad(text):
        """Split string into array of characters"""
        return list(str(text))
    
    def padl(text, length, char=" "):
        """Pad left to length"""
        return str(text).rjust(int(length), str(char))
    
    def padr(text, length, char=" "):
        """Pad right to length"""
        return str(text).ljust(int(length), str(char))
    
    # Return all functions
    return {
        # Higher-order array functions
        'petakan': petakan,
        'saring': saring,
        'kurangi': kurangi,
        'untuk_setiap': untuk_setiap,
        'cari': cari,
        'ada_yang': ada_yang,
        'semua_nya': semua_nya,
        'indeks_dari': indeks_dari,
        
        # Type checking
        'adalah_array': adalah_array,
        'adalah_object': adalah_object,
        'adalah_fungsi': adalah_fungsi,
        'adalah_angka': adalah_angka,
        'adalah_teks': adalah_teks,
        'adalah_boolean': adalah_boolean,
        
        # More string functions
        'ulangi_teks': ulangi_teks,
        'balik_teks': balik_teks,
        'abjad': abjad,
        'padl': padl,
        'padr': padr,
    }
