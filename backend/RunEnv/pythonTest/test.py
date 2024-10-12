import inspect
# Original function
def foo(age, name):
    print(f"Age: {age}, Name: {name}")

def baz(arr):
    signature = inspect.signature(foo)
    
    arg_names = list(signature.parameters)
    kwargs = dict(zip(arg_names, arr))
    
    foo(**kwargs)

baz([30, "Bob"])