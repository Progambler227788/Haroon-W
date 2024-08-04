class Person:
    def __init__(self, first_name, last_name):
        self.first_name = first_name
        self.last_name = last_name
    
    def __str__(self):
        return f'{self.last_name}, {self.first_name}'
    
    def get_first_name(self):
        return self.first_name
    
    def get_last_name(self):
        return self.last_name

# inherit person class
class PaidAdvisor(Person):
    # data members for pay rate by regular or special or over time 
    regular_pay_rate = 25
    special_pay_rate = 50
    overtime_pay_rate = 1.5 * regular_pay_rate
   
    # Constructor to intanstiate object of PairAdvisor class
    def __init__(self, first_name, last_name):
        super().__init__(first_name, last_name)
        self.hours_worked = 0
        self.hours_special = 0
    # Calculate Pay of Employee
    def calculate_pay(self):
        total_hours = self.hours_worked + self.hours_special
        if total_hours <= 30:
            return total_hours * self.regular_pay_rate
        else:
            regular_hours = min(self.hours_worked, 30) # 30 are regular working hours 
            overtime_hours = max(total_hours - 30, 0)
            regular_pay = regular_hours * self.regular_pay_rate
            overtime_pay = overtime_hours * self.overtime_pay_rate
            return regular_pay + overtime_pay + self.hours_special * self.special_pay_rate
    # Get pay rate
    def get_pay_rate(self):
        if self.hours_worked <= 30:
            return self.regular_pay_rate
        else:
            return self.overtime_pay_rate
    
    # Get total hours worked
    def get_hours_worked(self):
        return self.hours_worked
    
    # Set attributes for employee 
    def set_name_rate_hours(self, first_name, last_name, hours_worked, hours_special):
        self.first_name = first_name
        self.last_name = last_name
        self.hours_worked = hours_worked
        self.hours_special = hours_special

# Driver Main Function for testing classes
def main():
    # Ask user input
    first_name = input("Enter first name: ")
    last_name = input("Enter last name: ")
    hours_worked = float(input("Enter hours worked: "))
    hours_special = float(input("Enter special session hours: "))
    # Make Advisor Object
    advisor = PaidAdvisor(first_name, last_name)
    advisor.set_name_rate_hours(first_name, last_name, hours_worked, hours_special)
    
    # Print Details respectively
    print("\nEmployee details:")
    print(advisor)
    print(f"Hours worked: {advisor.get_hours_worked()}")
    print(f"Pay rate: ${advisor.get_pay_rate()} per hour")
    print(f"Total pay: ${advisor.calculate_pay()}")

# Call main function
if __name__ == "__main__":
    main()
