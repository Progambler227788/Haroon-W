def reversal(s):
    # Base case: if the string has 0 or 1 character, it's already reversed
    if len(s) <= 1:
        return s
    # Recursive case: reverse the substring excluding the first character and append the first character
    return reversal(s[1:]) + s[0]

def main():
    # Test cases
    string1 = "algorithm"
    print(f"Original string: {string1}")
    print(f"Reversed string: {reversal(string1)}")

    string2 = "programming"
    print(f"Original string: {string2}")
    print(f"Reversed string: {reversal(string2)}")

    string3 = "python is a coding language"
    print(f"Original string: {string3}")
    print(f"Reversed string: {reversal(string3)}")

if __name__ == "__main__":
    main()
