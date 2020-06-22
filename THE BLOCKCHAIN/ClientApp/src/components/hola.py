a= [1,2,3,4]
def square(x):
    return x*x

map(square,a)
p = list(map(square,a))
print(p)