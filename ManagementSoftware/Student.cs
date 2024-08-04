// Student.cs

// Import necessary namespaces
using System;

// Define the Student class inheriting from Person
public class Student : Person
{
    // Additional property
    public string StudentNumber { get; set; }

    // Implement the abstract method from the base class
    public override void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name}, Student Number: {StudentNumber}");
    }
}
