
def bar(n): 
    result = 1
    for i in range(1, n):
       for j in range(1, i):
        result += 2
    return result 