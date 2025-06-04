def make_power(exp):
    def power(x):
        return x ** exp
    return power


square = make_power(2)
cube = make_power(3)
print(square(5))
print(cube(2))
