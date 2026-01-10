#!/usr/bin/env python3
"""
CastleScript Interpreter
Bahasa pemrograman dengan sintaks Indonesia
"""

import sys
import re
import os
from typing import Any, Dict, List, Optional, Union

# Import GUI extension
try:
    from castlescript_gui import get_gui_functions
    GUI_AVAILABLE = True
except ImportError:
    GUI_AVAILABLE = False

# Import extended built-ins
try:
    from castlescript_extended import get_extended_builtins
    EXTENDED_AVAILABLE = True
except ImportError:
    EXTENDED_AVAILABLE = False

# Import advanced features
try:
    from castlescript_advanced import get_advanced_functions
    ADVANCED_AVAILABLE = True
except ImportError:
    ADVANCED_AVAILABLE = False

# Import class support
try:
    from castlescript_classes import CastleScriptClass
    CLASSES_AVAILABLE = True
except ImportError:
    CLASSES_AVAILABLE = False

# ============================================================================
# LEXER (Tokenizer)
# ============================================================================

class Token:
    def __init__(self, type: str, value: Any, line: int = 0):
        self.type = type
        self.value = value
        self.line = line
    
    def __repr__(self):
        return f"Token({self.type}, {self.value}, line={self.line})"

class Lexer:
    def __init__(self, code: str):
        self.code = code
        self.pos = 0
        self.line = 1
        self.current_char = self.code[0] if self.code else None
        
        # Keywords dalam bahasa Indonesia
        self.keywords = {
            'var', 'fungsi', 'kembalikan', 'jika', 'jika_tidak', 
            'selama', 'ulangi', 'benar', 'salah', 'kosong', 'dan', 
            'atau', 'tidak', 'buat', 'coba', 'tangkap', 'akhirnya',
            'henti', 'lanjut', 'lempar',
            'kelas', 'konstruktor', 'ini', 'baru'
        }
    
    def error(self, msg: str):
        raise SyntaxError(f"Kesalahan sintaks pada baris {self.line}: {msg}")
    
    def advance(self):
        if self.current_char == '\n':
            self.line += 1
        self.pos += 1
        self.current_char = self.code[self.pos] if self.pos < len(self.code) else None
    
    def peek(self, offset: int = 1):
        peek_pos = self.pos + offset
        return self.code[peek_pos] if peek_pos < len(self.code) else None
    
    def skip_whitespace(self):
        while self.current_char and self.current_char in ' \t\r':
            self.advance()
    
    def skip_comment(self):
        if self.current_char == '/' and self.peek() == '/':
            while self.current_char and self.current_char != '\n':
                self.advance()
    
    def read_number(self):
        num_str = ''
        has_dot = False
        while self.current_char and (self.current_char.isdigit() or self.current_char == '.'):
            if self.current_char == '.':
                if has_dot:
                    self.error("Angka memiliki lebih dari satu titik desimal")
                has_dot = True
            num_str += self.current_char
            self.advance()
        
        return float(num_str) if has_dot else int(num_str)
    
    def read_string(self, quote: str):
        string_val = ''
        self.advance()  # Skip opening quote
        
        while self.current_char and self.current_char != quote:
            if self.current_char == '\\':
                self.advance()
                if self.current_char == 'n':
                    string_val += '\n'
                elif self.current_char == 't':
                    string_val += '\t'
                elif self.current_char == '\\':
                    string_val += '\\'
                elif self.current_char == quote:
                    string_val += quote
                else:
                    string_val += self.current_char
                self.advance()
            else:
                string_val += self.current_char
                self.advance()
        
        if not self.current_char:
            self.error("String tidak ditutup")
        
        self.advance()  # Skip closing quote
        return string_val
    
    def read_identifier(self):
        id_str = ''
        while self.current_char and (self.current_char.isalnum() or self.current_char == '_'):
            id_str += self.current_char
            self.advance()
        return id_str
    
    def tokenize(self) -> List[Token]:
        tokens = []
        
        while self.current_char:
            # Skip whitespace
            if self.current_char in ' \t\r':
                self.skip_whitespace()
                continue
            
            # Newline
            if self.current_char == '\n':
                tokens.append(Token('NEWLINE', '\n', self.line))
                self.advance()
                continue
            
            # Comments
            if self.current_char == '/' and self.peek() == '/':
                self.skip_comment()
                continue
            
            # Numbers
            if self.current_char.isdigit():
                tokens.append(Token('NUMBER', self.read_number(), self.line))
                continue
            
            # Strings
            if self.current_char in '"\'':
                quote = self.current_char
                tokens.append(Token('STRING', self.read_string(quote), self.line))
                continue
            
            # Identifiers and keywords
            if self.current_char.isalpha() or self.current_char == '_':
                id_str = self.read_identifier()
                token_type = 'KEYWORD' if id_str in self.keywords else 'IDENTIFIER'
                tokens.append(Token(token_type, id_str, self.line))
                continue
            
            # Operators and punctuation
            char = self.current_char
            
            # Two-character operators
            if char == '=' and self.peek() == '=':
                tokens.append(Token('EQ', '==', self.line))
                self.advance()
                self.advance()
                continue
            if char == '!' and self.peek() == '=':
                tokens.append(Token('NEQ', '!=', self.line))
                self.advance()
                self.advance()
                continue
            if char == '<' and self.peek() == '=':
                tokens.append(Token('LTE', '<=', self.line))
                self.advance()
                self.advance()
                continue
            if char == '>' and self.peek() == '=':
                tokens.append(Token('GTE', '>=', self.line))
                self.advance()
                self.advance()
                continue
            
            # Single-character tokens
            single_char_tokens = {
                '+': 'PLUS', '-': 'MINUS', '*': 'MUL', '/': 'DIV', '%': 'MOD',
                '=': 'ASSIGN', '<': 'LT', '>': 'GT',
                '(': 'LPAREN', ')': 'RPAREN', '{': 'LBRACE', '}': 'RBRACE',
                '[': 'LBRACKET', ']': 'RBRACKET', ',': 'COMMA', ';': 'SEMICOLON',
                ':': 'COLON', '.': 'DOT'
            }
            
            if char in single_char_tokens:
                tokens.append(Token(single_char_tokens[char], char, self.line))
                self.advance()
                continue
            
            self.error(f"Karakter tidak dikenal: '{char}'")
        
        tokens.append(Token('EOF', None, self.line))
        return tokens

# ============================================================================
# PARSER
# ============================================================================

class ASTNode:
    pass

class NumberNode(ASTNode):
    def __init__(self, value):
        self.value = value

class StringNode(ASTNode):
    def __init__(self, value):
        self.value = value

class BooleanNode(ASTNode):
    def __init__(self, value):
        self.value = value

class NullNode(ASTNode):
    pass

class IdentifierNode(ASTNode):
    def __init__(self, name):
        self.name = name

class BinaryOpNode(ASTNode):
    def __init__(self, left, op, right):
        self.left = left
        self.op = op
        self.right = right

class UnaryOpNode(ASTNode):
    def __init__(self, op, operand):
        self.op = op
        self.operand = operand

class AssignNode(ASTNode):
    def __init__(self, name, value):
        self.name = name
        self.value = value

class BreakNode(ASTNode):
    pass

class ContinueNode(ASTNode):
    pass

class BlockNode(ASTNode):
    def __init__(self, statements):
        self.statements = statements

class TryNode(ASTNode):
    def __init__(self, try_block, catch_block, catch_var, finally_block):
        self.try_block = try_block
        self.catch_block = catch_block
        self.catch_var = catch_var
        self.finally_block = finally_block

class ThrowNode(ASTNode):
    def __init__(self, value):
        self.value = value


class IfNode(ASTNode):
    def __init__(self, condition, then_block, else_block=None):
        self.condition = condition
        self.then_block = then_block
        self.else_block = else_block

class WhileNode(ASTNode):
    def __init__(self, condition, body):
        self.condition = condition
        self.body = body

class ForNode(ASTNode):
    def __init__(self, init, condition, increment, body):
        self.init = init
        self.condition = condition
        self.increment = increment
        self.body = body

class FunctionDefNode(ASTNode):
    def __init__(self, name, params, body):
        self.name = name
        self.params = params
        self.body = body

class FunctionCallNode(ASTNode):
    def __init__(self, name, args):
        self.name = name
        self.args = args

class ReturnNode(ASTNode):
    def __init__(self, value):
        self.value = value

# New nodes for arrays and objects
class ArrayNode(ASTNode):
    def __init__(self, elements):
        self.elements = elements

class ObjectNode(ASTNode):
    def __init__(self, pairs):
        self.pairs = pairs  # List of (key, value) tuples

class IndexNode(ASTNode):
    def __init__(self, array, index):
        self.array = array
        self.index = index

class PropertyAccessNode(ASTNode):
    def __init__(self, obj, property):
        self.obj = obj
        self.property = property

# Control flow nodes
class BreakNode(ASTNode):
    pass

class ContinueNode(ASTNode):
    pass

class TryNode(ASTNode):
    def __init__(self, try_block, catch_var, catch_block, finally_block=None):
        self.try_block = try_block
        self.catch_var = catch_var
        self.catch_block = catch_block
        self.finally_block = finally_block

class ThrowNode(ASTNode):
    def __init__(self, value):
        self.value = value

# OOP Nodes
class ClassDefNode(ASTNode):
    def __init__(self, name, constructor_params, constructor_body, methods, parent=None):
        self.name = name
        self.constructor_params = constructor_params
        self.constructor_body = constructor_body
        self.methods = methods  # dict of {method_name: (params, body)}
        self.parent = parent

class NewInstanceNode(ASTNode):
    def __init__(self, class_name, args):
        self.class_name = class_name
        self.args = args

class ThisNode(ASTNode):
    pass

class Parser:
    def __init__(self, tokens: List[Token]):
        self.tokens = tokens
        self.pos = 0
        self.current_token = self.tokens[0] if tokens else None
    
    def error(self, msg: str):
        line = self.current_token.line if self.current_token else 0
        raise SyntaxError(f"Kesalahan parsing pada baris {line}: {msg}")
    
    def advance(self):
        self.pos += 1
        self.current_token = self.tokens[self.pos] if self.pos < len(self.tokens) else None
    
    def skip_newlines(self):
        while self.current_token and self.current_token.type == 'NEWLINE':
            self.advance()
    
    def expect(self, token_type: str):
        if not self.current_token or self.current_token.type != token_type:
            self.error(f"Diharapkan {token_type}, tetapi mendapat {self.current_token.type if self.current_token else 'EOF'}")
        value = self.current_token.value
        self.advance()
        return value
    
    def parse(self) -> BlockNode:
        statements = []
        self.skip_newlines()
        
        while self.current_token and self.current_token.type != 'EOF':
            stmt = self.parse_statement()
            if stmt:
                statements.append(stmt)
            self.skip_newlines()
        
        return BlockNode(statements)
    
    def parse_statement(self):
        self.skip_newlines()
        
        if not self.current_token or self.current_token.type == 'EOF':
            return None
        
        # Variable declaration
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'var':
            return self.parse_var_declaration()
        
        # Function definition
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'fungsi':
            return self.parse_function_def()
        
        # Class definition
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'kelas':
            return self.parse_class_def()
        
        # If statement
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'jika':
            return self.parse_if_statement()
        
        # While loop
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'selama':
            return self.parse_while_statement()
        
        # For loop
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'ulangi':
            return self.parse_for_statement()
        
        # Return statement
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'kembalikan':
            return self.parse_return_statement()
        
        # Break statement
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'henti':
            return self.parse_break_statement()
        
        # Continue statement
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'lanjut':
            return self.parse_continue_statement()

        # Try statement
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'coba':
            return self.parse_try_statement()
    
        # Expression statement (assignment or function call)
        expr = self.parse_expression()
        
        # Optional semicolon or newline
        if self.current_token and self.current_token.type in ('SEMICOLON', 'NEWLINE'):
            self.advance()
        
        return expr
    
    def parse_var_declaration(self):
        self.expect('KEYWORD')  # 'var'
        name = self.expect('IDENTIFIER')
        self.expect('ASSIGN')
        value = self.parse_expression()
        
        if self.current_token and self.current_token.type in ('SEMICOLON', 'NEWLINE'):
            self.advance()
        
        return AssignNode(name, value)
    
    def parse_function_def(self):
        self.expect('KEYWORD')  # 'fungsi'
        name = self.expect('IDENTIFIER')
        self.expect('LPAREN')
        
        params = []
        if self.current_token.type != 'RPAREN':
            params.append(self.expect('IDENTIFIER'))
            while self.current_token and self.current_token.type == 'COMMA':
                self.advance()
                params.append(self.expect('IDENTIFIER'))
        
        self.expect('RPAREN')
        self.skip_newlines()
        self.expect('LBRACE')
        
        body = self.parse_block()
        
        self.expect('RBRACE')
        
        return FunctionDefNode(name, params, body)
    
    def parse_if_statement(self):
        self.expect('KEYWORD')  # 'jika'
        self.expect('LPAREN')
        condition = self.parse_expression()
        self.expect('RPAREN')
        self.skip_newlines()
        self.expect('LBRACE')
        
        then_block = self.parse_block()
        
        self.expect('RBRACE')
        self.skip_newlines()
        
        else_block = None
        if self.current_token and self.current_token.type == 'KEYWORD' and self.current_token.value == 'jika_tidak':
            self.advance()
            self.skip_newlines()
            self.expect('LBRACE')
            else_block = self.parse_block()
            self.expect('RBRACE')
        
        return IfNode(condition, then_block, else_block)
    
    def parse_while_statement(self):
        self.expect('KEYWORD')  # 'selama'
        self.expect('LPAREN')
        condition = self.parse_expression()
        self.expect('RPAREN')
        self.skip_newlines()
        self.expect('LBRACE')
        
        body = self.parse_block()
        
        self.expect('RBRACE')
        
        return WhileNode(condition, body)
    
    def parse_for_statement(self):
        self.expect('KEYWORD')  # 'ulangi'
        self.expect('LPAREN')
        
        # Init
        init = None
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'var':
            init = self.parse_var_declaration()
        else:
            init = self.parse_expression()
        
        self.expect('SEMICOLON')
        
        # Condition
        condition = self.parse_expression()
        
        self.expect('SEMICOLON')
        
        # Increment
        increment = self.parse_expression()
        
        self.expect('RPAREN')
        self.skip_newlines()
        self.expect('LBRACE')
        
        body = self.parse_block()
        
        self.expect('RBRACE')
        
        return ForNode(init, condition, increment, body)
    
    def parse_return_statement(self):
        self.expect('KEYWORD')  # 'kembalikan'
        value = self.parse_expression()
        
        if self.current_token and self.current_token.type in ('SEMICOLON', 'NEWLINE'):
            self.advance()
        
        return ReturnNode(value)
    
    def parse_break_statement(self):
        self.expect('KEYWORD') # 'henti'
        if self.current_token and self.current_token.type in ('SEMICOLON', 'NEWLINE'):
            self.advance()
        return BreakNode()

    def parse_continue_statement(self):
        self.expect('KEYWORD') # 'lanjut'
        if self.current_token and self.current_token.type in ('SEMICOLON', 'NEWLINE'):
            self.advance()
        return ContinueNode()
    
    def parse_try_statement(self):
        self.expect('KEYWORD') # 'coba'
        self.expect('LBRACE')
        try_block = self.parse_block()
        self.expect('RBRACE')
        
        catch_block = None
        catch_var = None
        
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'tangkap':
            self.advance()
            self.expect('LPAREN')
            catch_var = self.expect('IDENTIFIER')
            self.expect('RPAREN')
            self.expect('LBRACE')
            catch_block = self.parse_block()
            self.expect('RBRACE')
            
        finally_block = None
        if self.current_token.type == 'KEYWORD' and self.current_token.value == 'akhirnya':
            self.advance()
            self.expect('LBRACE')
            finally_block = self.parse_block()
            self.expect('RBRACE')
            
        return TryNode(try_block, catch_block, catch_var, finally_block)

    def parse_class_def(self):
        """Parse class definition"""
        self.expect('KEYWORD')  # 'kelas'
        class_name = self.expect('IDENTIFIER')
        
        self.skip_newlines()
        self.expect('LBRACE')
        self.skip_newlines()
        
        constructor_params = []
        constructor_body = None
        methods = {}
        
        # Parse class body
        while self.current_token and self.current_token.type != 'RBRACE':
            self.skip_newlines()
            
            if self.current_token.type == 'RBRACE':
                break
            
            # Must be either 'konstruktor' or 'fungsi'
            if self.current_token.type == 'KEYWORD':
                if self.current_token.value == 'konstruktor':
                    # Parse constructor
                    self.advance()
                    self.expect('LPAREN')
                    
                    # Get parameters
                    if self.current_token.type != 'RPAREN':
                        constructor_params.append(self.expect('IDENTIFIER'))
                        while self.current_token and self.current_token.type == 'COMMA':
                            self.advance()
                            constructor_params.append(self.expect('IDENTIFIER'))
                    
                    self.expect('RPAREN')
                    self.skip_newlines()
                    self.expect('LBRACE')
                    
                    constructor_body = self.parse_block()
                    
                    self.expect('RBRACE')
                    self.skip_newlines()
                
                elif self.current_token.value == 'fungsi':
                    # Parse method
                    self.advance()
                    method_name = self.expect('IDENTIFIER')
                    self.expect('LPAREN')
                    
                    # Get parameters
                    params = []
                    if self.current_token.type != 'RPAREN':
                        params.append(self.expect('IDENTIFIER'))
                        while self.current_token and self.current_token.type == 'COMMA':
                            self.advance()
                            params.append(self.expect('IDENTIFIER'))
                    
                    self.expect('RPAREN')
                    self.skip_newlines()
                    self.expect('LBRACE')
                    
                    body = self.parse_block()
                    
                    methods[method_name] = (params, body)
                    
                    self.expect('RBRACE')
                    self.skip_newlines()
                else:
                    self.error(f"Unexpected keyword in class: {self.current_token.value}")
            else:
                self.error("Expected 'konstruktor' or 'fungsi' in class body")
        
        self.expect('RBRACE')
        
        # Default constructor if not provided
        if constructor_body is None:
            constructor_body = BlockNode([])
        
        return ClassDefNode(class_name, constructor_params, constructor_body, methods)
    
    def parse_block(self):
        statements = []
        self.skip_newlines()
        
        while self.current_token and self.current_token.type not in ('RBRACE', 'EOF'):
            stmt = self.parse_statement()
            if stmt:
                statements.append(stmt)
            self.skip_newlines()
        
        return BlockNode(statements)
    
    def parse_expression(self):
        return self.parse_assignment()
    
    def parse_assignment(self):
        expr = self.parse_logical_or()
        
        if self.current_token and self.current_token.type == 'ASSIGN':
            if not isinstance(expr, IdentifierNode):
                self.error("Target assignment harus berupa identifier")
            self.advance()
            value = self.parse_expression()
            return AssignNode(expr.name, value)
        
        return expr
    
    def parse_logical_or(self):
        left = self.parse_logical_and()
        
        while self.current_token and self.current_token.type == 'KEYWORD' and self.current_token.value == 'atau':
            op = self.current_token.value
            self.advance()
            right = self.parse_logical_and()
            left = BinaryOpNode(left, op, right)
        
        return left
    
    def parse_logical_and(self):
        left = self.parse_equality()
        
        while self.current_token and self.current_token.type == 'KEYWORD' and self.current_token.value == 'dan':
            op = self.current_token.value
            self.advance()
            right = self.parse_equality()
            left = BinaryOpNode(left, op, right)
        
        return left
    
    def parse_equality(self):
        left = self.parse_comparison()
        
        while self.current_token and self.current_token.type in ('EQ', 'NEQ'):
            op = self.current_token.value
            self.advance()
            right = self.parse_comparison()
            left = BinaryOpNode(left, op, right)
        
        return left
    
    def parse_comparison(self):
        left = self.parse_additive()
        
        while self.current_token and self.current_token.type in ('LT', 'GT', 'LTE', 'GTE'):
            op = self.current_token.value
            self.advance()
            right = self.parse_additive()
            left = BinaryOpNode(left, op, right)
        
        return left
    
    def parse_additive(self):
        left = self.parse_multiplicative()
        
        while self.current_token and self.current_token.type in ('PLUS', 'MINUS'):
            op = self.current_token.value
            self.advance()
            right = self.parse_multiplicative()
            left = BinaryOpNode(left, op, right)
        
        return left
    
    def parse_multiplicative(self):
        left = self.parse_unary()
        
        while self.current_token and self.current_token.type in ('MUL', 'DIV', 'MOD'):
            op = self.current_token.value
            self.advance()
            right = self.parse_unary()
            left = BinaryOpNode(left, op, right)
        
        return left
    
    def parse_unary(self):
        if self.current_token and self.current_token.type in ('MINUS', 'PLUS'):
            op = self.current_token.value
            self.advance()
            operand = self.parse_unary()
            return UnaryOpNode(op, operand)
        
        if self.current_token and self.current_token.type == 'KEYWORD' and self.current_token.value == 'tidak':
            op = self.current_token.value
            self.advance()
            operand = self.parse_unary()
            return UnaryOpNode(op, operand)
        
        return self.parse_postfix()
    
    def parse_postfix(self):
        """Parse postfix expressions (array indexing, property access, function calls)"""
        expr = self.parse_primary()
        
        while self.current_token:
            # Array indexing: arr[0]
            if self.current_token.type == 'LBRACKET':
                self.advance()
                index = self.parse_expression()
                self.expect('RBRACKET')
                expr = IndexNode(expr, index)
            
            # Property access: obj.property
            elif self.current_token.type == 'DOT':
                self.advance()
                if self.current_token.type != 'IDENTIFIER':
                    self.error("Expected property name after '.'")
                property_name = self.current_token.value
                self.advance()
                # Convert to index node with string key
                expr = IndexNode(expr, StringNode(property_name))
            
            # Function call: func()
            elif self.current_token.type == 'LPAREN':
                # Only for identifiers or property access results
                self.advance()
                args = []
                if self.current_token.type != 'RPAREN':
                    args.append(self.parse_expression())
                    while self.current_token and self.current_token.type == 'COMMA':
                        self.advance()
                        args.append(self.parse_expression())
                self.expect('RPAREN')
                # For now, only support direct function calls
                if isinstance(expr, IdentifierNode):
                    expr = FunctionCallNode(expr.name, args)
                else:
                    self.error("Complex function calls not yet supported")
            else:
                break
        
        return expr
    
    def parse_primary(self):
        # Numbers
        if self.current_token and self.current_token.type == 'NUMBER':
            value = self.current_token.value
            self.advance()
            return NumberNode(value)
        
        # Strings
        if self.current_token and self.current_token.type == 'STRING':
            value = self.current_token.value
            self.advance()
            return StringNode(value)
        
        # Booleans
        if self.current_token and self.current_token.type == 'KEYWORD':
            if self.current_token.value == 'benar':
                self.advance()
                return BooleanNode(True)
            if self.current_token.value == 'salah':
                self.advance()
                return BooleanNode(False)
            if self.current_token.value == 'kosong':
                self.advance()
                return NullNode()
        
        # Identifiers
        if self.current_token and self.current_token.type == 'IDENTIFIER':
            name = self.current_token.value
            self.advance()
            return IdentifierNode(name)
        
        # Array literals [1, 2, 3]
        if self.current_token and self.current_token.type == 'LBRACKET':
            self.advance()
            elements = []
            
            if self.current_token.type != 'RBRACKET':
                elements.append(self.parse_expression())
                while self.current_token and self.current_token.type == 'COMMA':
                    self.advance()
                    if self.current_token.type == 'RBRACKET':  # trailing comma
                        break
                    elements.append(self.parse_expression())
            
            self.expect('RBRACKET')
            return ArrayNode(elements)
        
        # Object literals {key: value}
        if self.current_token and self.current_token.type == 'LBRACE':
            self.advance()
            self.skip_newlines()  # Skip newlines after opening brace
            pairs = []
            
            if self.current_token.type != 'RBRACE':
                # Parse key
                if self.current_token.type == 'IDENTIFIER':
                    key = self.current_token.value
                    self.advance()
                elif self.current_token.type == 'STRING':
                    key = self.current_token.value
                    self.advance()
                else:
                    self.error("Expected identifier or string as object key")
                
                self.skip_newlines()  # Skip newlines before colon
                self.expect('COLON')
                self.skip_newlines()  # Skip newlines after colon
                value = self.parse_expression()
                pairs.append((key, value))
                
                self.skip_newlines()  # Skip newlines after value
                while self.current_token and self.current_token.type == 'COMMA':
                    self.advance()
                    self.skip_newlines()  # Skip newlines after comma
                    if self.current_token.type == 'RBRACE':  # trailing comma
                        break
                    
                    # Parse next key
                    if self.current_token.type == 'IDENTIFIER':
                        key = self.current_token.value
                        self.advance()
                    elif self.current_token.type == 'STRING':
                        key = self.current_token.value
                        self.advance()
                    else:
                        self.error("Expected identifier or string as object key")
                    
                    self.skip_newlines()  # Skip newlines before colon
                    self.expect('COLON')
                    self.skip_newlines()  # Skip newlines after colon
                    value = self.parse_expression()
                    pairs.append((key, value))
                    self.skip_newlines()  # Skip newlines after value
            
            self.expect('RBRACE')
            return ObjectNode(pairs)
        
        # Parenthesized expression
        if self.current_token and self.current_token.type == 'LPAREN':
            self.advance()
            expr = self.parse_expression()
            self.expect('RPAREN')
            return expr
        
        self.error(f"Token tidak diharapkan: {self.current_token}")

# ============================================================================
# EVALUATOR
# ============================================================================

class ReturnValue(Exception):
    def __init__(self, value):
        self.value = value

class BreakException(Exception):
    """Exception for break statement"""
    pass

class ContinueException(Exception):
    """Exception for continue statement"""
    pass

class Environment:
    def __init__(self, parent=None):
        self.vars = {}
        self.parent = parent
    
    def get(self, name: str):
        if name in self.vars:
            return self.vars[name]
        if self.parent:
            return self.parent.get(name)
        raise NameError(f"Variabel '{name}' tidak ditemukan")
    
    def set(self, name: str, value: Any):
        # Check if variable exists in current or parent scope
        if name in self.vars:
            # Update existing variable in current scope
            self.vars[name] = value
        elif self.parent and self._exists_in_parent(name):
            # Update existing variable in parent scope
            self.parent.set(name, value)
        else:
            # Create new variable in current scope
            self.vars[name] = value
    
    def _exists_in_parent(self, name: str):
        """Check if variable exists in parent chain"""
        if self.parent:
            if name in self.parent.vars:
                return True
            return self.parent._exists_in_parent(name) if hasattr(self.parent, '_exists_in_parent') else False
        return False
    
    def update(self, name: str, value: Any):
        if name in self.vars:
            self.vars[name] = value
        elif self.parent:
            self.parent.update(name, value)
        else:
            raise NameError(f"Variabel '{name}' tidak ditemukan")

class Evaluator:
    def __init__(self):
        self.global_env = Environment()
        self.setup_builtins()
    
    def setup_builtins(self):
        # Built-in functions
        def builtin_tulis(*args):
            print(' '.join(str(arg) for arg in args))
            return None
        
        def builtin_baca(prompt=''):
            if prompt:
                print(prompt, end='')
            return input()
        
        def builtin_panjang(val):
            return len(val)
        
        def builtin_tipe(val):
            if isinstance(val, bool):
                return 'boolean'
            if isinstance(val, int) or isinstance(val, float):
                return 'angka'
            if isinstance(val, str):
                return 'teks'
            if val is None:
                return 'kosong'
            return 'tidak diketahui'
        
        def builtin_ke_angka(val):
            try:
                return int(val) if '.' not in str(val) else float(val)
            except:
                return 0
        
        def builtin_ke_teks(val):
            return str(val)
        
        self.global_env.set('tulis', builtin_tulis)
        self.global_env.set('baca', builtin_baca)
        self.global_env.set('panjang', builtin_panjang)
        self.global_env.set('tipe', builtin_tipe)
        self.global_env.set('ke_angka', builtin_ke_angka)
        self.global_env.set('ke_teks', builtin_ke_teks)
        
        # Register extended built-ins if available
        if EXTENDED_AVAILABLE:
            extended_funcs = get_extended_builtins()
            for name, func in extended_funcs.items():
                self.global_env.set(name, func)
        
        # Register advanced functions if available  
        if ADVANCED_AVAILABLE:
            advanced_funcs = get_advanced_functions(self, self.global_env)
            for name, func in advanced_funcs.items():
                self.global_env.set(name, func)
        
        # Register GUI functions if available
        if GUI_AVAILABLE:
            gui_funcs = get_gui_functions(self, self.global_env)
            for name, func in gui_funcs.items():
                self.global_env.set(name, func)
    
    def eval(self, node: ASTNode, env: Environment = None):
        if env is None:
            env = self.global_env
        
        if isinstance(node, NumberNode):
            return node.value
        
        if isinstance(node, StringNode):
            return node.value
        
        if isinstance(node, BooleanNode):
            return node.value
        
        if isinstance(node, NullNode):
            return None
        
        if isinstance(node, IdentifierNode):
            return env.get(node.name)
        
        if isinstance(node, BinaryOpNode):
            left = self.eval(node.left, env)
            right = self.eval(node.right, env)
            
            if node.op == '+':
                if isinstance(left, str) or isinstance(right, str):
                    return str(left) + str(right)
                return left + right
            if node.op == '-':
                return left - right
            if node.op == '*':
                return left * right
            if node.op == '/':
                if right == 0:
                    raise ZeroDivisionError("Pembagian dengan nol")
                return left / right
            if node.op == '%':
                return left % right
            if node.op == '==':
                return left == right
            if node.op == '!=':
                return left != right
            if node.op == '<':
                return left < right
            if node.op == '>':
                return left > right
            if node.op == '<=':
                return left <= right
            if node.op == '>=':
                return left >= right
            if node.op == 'dan':
                return left and right
            if node.op == 'atau':
                return left or right
        
        if isinstance(node, UnaryOpNode):
            operand = self.eval(node.operand, env)
            
            if node.op == '-':
                return -operand
            if node.op == '+':
                return +operand
            if node.op == 'tidak':
                return not operand
        
        if isinstance(node, AssignNode):
            value = self.eval(node.value, env)
            env.set(node.name, value)
            return value
        
        if isinstance(node, BlockNode):
            result = None
            for stmt in node.statements:
                result = self.eval(stmt, env)
            return result
        
        if isinstance(node, IfNode):
            condition = self.eval(node.condition, env)
            if condition:
                return self.eval(node.then_block, env)
            elif node.else_block:
                return self.eval(node.else_block, env)
            return None
        
        if isinstance(node, WhileNode):
            result = None
            try:
                while self.eval(node.condition, env):
                    try:
                        result = self.eval(node.body, env)
                    except ContinueException:
                        continue
            except BreakException:
                pass
            return result
        
        if isinstance(node, ForNode):
            result = None
            try:
                self.eval(node.init, env)
                while self.eval(node.condition, env):
                    try:
                        result = self.eval(node.body, env)
                    except ContinueException:
                        self.eval(node.increment, env)
                        continue
                    self.eval(node.increment, env)
            except BreakException:
                pass
            return result
        
        if isinstance(node, FunctionDefNode):
            env.set(node.name, ('function', node.params, node.body))
            return None
        
        if isinstance(node, FunctionCallNode):
            func = env.get(node.name)
            args = [self.eval(arg, env) for arg in node.args]
            
            # Built-in function
            if callable(func):
                return func(*args)
            
            # User-defined function
            if isinstance(func, tuple) and func[0] == 'function':
                _, params, body = func
                
                if len(args) != len(params):
                    raise TypeError(f"Fungsi '{node.name}' mengharapkan {len(params)} argumen, tetapi mendapat {len(args)}")
                
                # Create new environment for function
                func_env = Environment(env)
                for param, arg in zip(params, args):
                    func_env.set(param, arg)
                
                try:
                    self.eval(body, func_env)
                except ReturnValue as ret:
                    return ret.value
                
                return None
            
            raise TypeError(f"'{node.name}' bukan fungsi")
        
        if isinstance(node, ReturnNode):
            value = self.eval(node.value, env)
            raise ReturnValue(value)
        
        # Array evaluation
        if isinstance(node, ArrayNode):
            return [self.eval(elem, env) for elem in node.elements]
        
        # Object evaluation
        if isinstance(node, ObjectNode):
            obj = {}
            for key, value_node in node.pairs:
                obj[key] = self.eval(value_node, env)
            return obj
        
        # Array/Object indexing
        if isinstance(node, IndexNode):
            collection = self.eval(node.array, env)
            index = self.eval(node.index, env)
            
            if isinstance(collection, list):
                try:
                    return collection[int(index)]
                except IndexError:
                    raise IndexError(f"Index {index} di luar jangkauan array")
                except TypeError:
                    raise TypeError("Index array harus berupa angka")
            elif isinstance(collection, dict):
                return collection.get(str(index), None)
            elif isinstance(collection, str):
                try:
                    return collection[int(index)]
                except IndexError:
                    raise IndexError(f"Index {index} di luar jangkauan string")
            else:
                raise TypeError(f"Tipe '{type(collection).__name__}' tidak mendukung indexing")
        
        # Break & Continue
        if isinstance(node, BreakNode):
            raise BreakException()
        
        if isinstance(node, ContinueNode):
            raise ContinueException()
        
        # Try-Catch-Finally
        if isinstance(node, TryNode):
            result = None
            try:
                result = self.eval(node.try_block, env)
            except Exception as e:
                if node.catch_block:
                    catch_env = Environment(env)
                    catch_env.set(node.catch_var, str(e))
                    result = self.eval(node.catch_block, catch_env)
            finally:
                if node.finally_block:
                    self.eval(node.finally_block, env)
            return result
        
        # Try-Catch-Finally
        if isinstance(node, TryNode):
            try:
                self.eval(node.try_block, env)
            except (ReturnValue, BreakException, ContinueException):
                raise
            except Exception as e:
                if node.catch_block:
                    catch_env = Environment(env)
                    if node.catch_var:
                        catch_env.set(node.catch_var, str(e))
                    self.eval(node.catch_block, catch_env)
            finally:
                if node.finally_block:
                    self.eval(node.finally_block, env)
            return None
        
        # Throw
        if isinstance(node, ThrowNode):
            message = self.eval(node.value, env) if node.value else "Error"
            raise RuntimeError(str(message))
        
        return None

# ============================================================================
# MAIN
# ============================================================================

def run_file(filename: str):
    try:
        with open(filename, 'r', encoding='utf-8') as f:
            code = f.read()
        
        # Lexer
        lexer = Lexer(code)
        tokens = lexer.tokenize()
        
        # Parser
        parser = Parser(tokens)
        ast = parser.parse()
        
        # Evaluator
        evaluator = Evaluator()
        evaluator.eval(ast)
        
    except FileNotFoundError:
        print(f"Error: File '{filename}' tidak ditemukan")
        sys.exit(1)
    except SyntaxError as e:
        print(f"SyntaxError: {e}")
        sys.exit(1)
    except NameError as e:
        print(f"NameError: {e}")
        sys.exit(1)
    except TypeError as e:
        print(f"TypeError: {e}")
        sys.exit(1)
    except ZeroDivisionError as e:
        print(f"ZeroDivisionError: {e}")
        sys.exit(1)
    except Exception as e:
        print(f"Error: {type(e).__name__}: {e}")
        sys.exit(1)

def main():
    if len(sys.argv) < 2:
        print("CastleScript - Bahasa Pemrograman Indonesia")
        print(f"Penggunaan: {sys.argv[0]} <file.cs>")
        sys.exit(1)
    
    filename = sys.argv[1]
    
    if not filename.endswith('.cs'):
        print("Warning: File tidak memiliki ekstensi .cs")
    
    run_file(filename)

if __name__ == '__main__':
    main()
