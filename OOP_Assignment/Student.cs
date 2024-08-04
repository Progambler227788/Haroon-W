// Student.cs

// Import necessary namespaces
using System;

// Define the Student class inheriting from Person
public class Student : Person
{
    // Additional property
    public string StudentNumber { get; set; }
    public string Program { get; set; }

    // Implement the abstract method from the base class
    public override String TypePerson()
    {
       return "Student";
    }
}
