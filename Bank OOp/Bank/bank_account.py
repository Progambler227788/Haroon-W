class BankAccount:
    def __init__(self, account_number, customer_name, initial_balance):
        # data members for BankAccount class
        self.__account_number = account_number
        self.customer_name = customer_name
        self.__balance = initial_balance
        self.__transaction_history = [] # Number of transactions made by user
    
    # Function to get balance of user
    def get_balance(self):
        return self.__balance

    def get_account_number(self):
        return self.__account_number

    def deposit_funds(self, amount):
        try:
            # Can't deposit more than 5000
            if amount > 5000:
                raise ValueError("Deposit amount cannot exceed $5,000")
            self.__balance += amount
            self.__transaction_history.append(f"Deposit: +${amount}")
            return True
        except ValueError as e: # Raise value error
            print(e)
        return False # In case of except Value error will be raised

    def withdraw_funds(self, amount):
        if amount <= 0:
            return -3  # Invalid withdrawal amount
        
        # Calculate the new balance after withdrawal
        new_balance = self.__balance - amount
        
        # Check if the withdrawal would cause the balance to become negative
        if new_balance < 0:
            # Calculate the absolute value of the deficit
            deficit = abs(new_balance)
            
            # Check if the deficit is within the allowed range for applying service charge
            if deficit <= 95:
                # Apply service charge
                self.__balance -= 35.00
                # Update balance after service charge
                self.__balance -= amount
                self.__transaction_history.append(f"Withdrawal: -${amount} and Service charge: -$35.00")
                return -1  # Withdrawal with service charge, balance within allowed negative range
            else:
                # Deny withdrawal, apply service charge
                self.__balance -= 35.00
                self.__transaction_history.append("Withdrawal Not Made. Service charge: -$35.00")
                return -2  # Withdrawal denied, balance exceeds allowed negative range
        else:
            # Update balance after successful withdrawal
            self.__balance = new_balance
            self.__transaction_history.append(f"Withdrawal: -${amount}")
            return 0  # Successful withdrawal, balance remains positive
    

    def get_transaction_history(self): # Get transaction history list
        return self.__transaction_history
