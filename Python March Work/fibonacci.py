def fib(n):
    if n <= 1:
        return n
    else:
      return fib(n-1) + fib(n-2)

def main():
    # Iterate over 20 terms
    print('Exercise 1: Fibonacci Series')
    for i in range(21):
      # print(i)
       if i<20:
        print(fib(i), end=", ")
       else:
        print(fib(i))
        
if __name__ == "__main__":
    main()
