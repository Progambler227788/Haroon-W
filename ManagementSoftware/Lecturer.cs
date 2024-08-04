// Lecturer.cs

// Import necessary namespaces
using System;

// Define the Lecturer class inheriting from Person
public class Lecturer : Person
{
    // Additional property
    public decimal Pay { get; set; }
    public String Gender { get; set; }

    // Implement the abstract method from the base class
    public override void DisplayInfo()
    {
        Console.WriteLine($"Lecturer: {Name}, Pay: {Pay:C}");
    }
}
