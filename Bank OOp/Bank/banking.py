# Import bank_account to use BankAccount class
from bank_account import BankAccount

# Function to display menu
def display_menu():
    print("Menu:")
    print("1. Get Balance")
    print("2. Make Deposit")
    print("3. Make Withdrawal")
    print("4. Display list of Account Balances")
    print("5. Exit")

def main():
    # Display Header
    print('-' * 15 +  'Banking System' + '-' * 15 )
    account_number = int(input("Enter account number: "))
    # Try Excepty exception handling
    try:
      if account_number <= 0 :
          raise ValueError
    except ValueError:
        account_number = - account_number
        print(f"Account Number cannot be negative. Default positive number is made : {account_number}")
        
        
    customer_name = input("Enter customer name: ")
    try:
        if customer_name is None or customer_name == '' :
          raise ValueError
    except ValueError:
        customer_name = "Customer"
        print(f"Customer Name cannot be empty. Default {customer_name} is passed")
        
    initial_balance = float(input("Enter initial balance: "))
    try:
        if initial_balance is None or initial_balance < 0 :
          raise ValueError
    except ValueError:
        initial_balance = 0
        print("Initial Balance cannot be empty. Default 0 as balance is passed")
    
    # Account class object
    account = BankAccount(account_number, customer_name, initial_balance)
    # Loop for menu
    while True:
        display_menu()
        choice = input("Enter your choice: ")
        
        # Choices to be made
        if choice == "1": # Information Display
            print(f"Account Number: {account.get_account_number()}, Balance: ${account.get_balance():.2f}")
        elif choice == "2": # Deposit balance
            amount = float(input("Enter deposit amount: "))
            if account.deposit_funds(amount):
                print(f"Deposit of ${amount:.2f} successful")
        elif choice == "3": # With draw ammount
            amount = float(input("Enter withdrawal amount: "))
            result = account.withdraw_funds(amount)
            if result == 0:
                print(f"Withdrawal of ${amount:.2f} successful")
            elif result == -1:
                print(f"Withdrawal of ${amount:.2f} successful, with service charge")
            elif result == -2:
                print("Withdrawal denied: Insufficient funds")
        elif choice == "4": # get list of transactions made
            print(f"Transaction History for {account.customer_name}:")
            for transaction in account.get_transaction_history():
                print(transaction)
        elif choice == "5": # Exit from system
            print("Exiting program...")
            break
        else: # In case of wrong menu input
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main() # Call main function
