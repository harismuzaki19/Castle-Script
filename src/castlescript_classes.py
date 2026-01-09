#!/usr/bin/env python3
"""
CastleScript Classes Module
Simplified OOP implementation for CastleScript
"""

class CastleScriptClass:
    """Represents a CastleScript class definition"""
    def __init__(self, name, constructor_params, constructor_body, methods):
        self.name = name
        self.constructor_params = constructor_params
        self.constructor_body = constructor_body
        self.methods = methods  # dict: {method_name: (params, body)}
    
    def create_instance(self, args, evaluator, env):
        """Create a new instance of this class"""
        from castlescript import Environment, ReturnValue
        
        # Create instance object
        instance = {'__class__': self.name}
        
        # Create environment for constructor
        constructor_env = Environment(env)
        constructor_env.set('ini', instance)
        
        # Bind constructor parameters
        for i, param in enumerate(self.constructor_params):
            if i < len(args):
                constructor_env.set(param, args[i])
        
        # Execute constructor to set properties
        try:
            evaluator.eval(self.constructor_body, constructor_env)
        except ReturnValue:
            pass  # Constructors don't return values
        
        # Bind methods to instance
        for method_name, (params, body) in self.methods.items():
            # Create bound method
            instance[method_name] = ('method', self, method_name, params, body)
        
        return instance
    
    def call_method(self, instance, method_name, args, evaluator, env):
        """Call a method on an instance"""
        from castlescript import Environment, ReturnValue
        
        if method_name not in self.methods:
            raise AttributeError(f"Method '{method_name}' tidak ditemukan")
        
        params, body = self.methods[method_name]
        
        # Create method environment
        method_env = Environment(env)
        method_env.set('ini', instance)
        
        # Bind parameters
        for i, param in enumerate(params):
            if i < len(args):
                method_env.set(param, args[i])
        
        # Execute method
        try:
            result = evaluator.eval(body, method_env)
            return result
        except ReturnValue as ret:
            return ret.value


def get_class_support():
    """Return class-related helper functions"""
    return {
        'CastleScriptClass': CastleScriptClass
    }
