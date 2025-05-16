# 1
a = 1
b = 2
c = 3
d = 4
e = 5
numbers = [a, b, c, d, e]
for num in numbers:
    print(num, end=' ')
print()

# 2
odd_numbers = list(range(1, 100, 10))
print(odd_numbers)

# odd_numbers = [i for i in range(1, 100, 10)]
# print(odd_numbers)

# 3
t = (7, 14, 21, 28, 35)
print(len(t))
print(t[0])
print(t[-1])
print(t[1:4])

# 4
t = (1, 2, 3)
t = list(t)
t[1] = 20
t = tuple(t)
print(t)

# 5
a = (10, 20, 30)
b = (40, 50)
c = a + b
print(*c)
