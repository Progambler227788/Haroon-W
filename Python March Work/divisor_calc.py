def gcd(num1, num2):
    # If condition in case number 2 is less then or equal to number1 and num1 is divisble by num2
    if num2 <= num1 and num1 % num2 == 0:
        return num2
    # In case not divisible but less than
    elif num1 < num2:
        return gcd(num2, num1)
    # Else case when num2 > num1
    return gcd(num2, num1 % num2)

def main():
    # Test function with numbers
    num1 = 90
    num2 = 18
    print(f"GCD of {num1} and {num2} is: {gcd(num1, num2)}")

    num1 = 30
    num2 = 15
    print(f"GCD of {num1} and {num2} is: {gcd(num1, num2)}")

    num1 = 60
    num2 = 90
    print(f"GCD of {num1} and {num2} is: {gcd(num1, num2)}")

if __name__ == "__main__":
    main()
