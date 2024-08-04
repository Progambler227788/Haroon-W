// Person.cs

// Import necessary namespaces
using System;

// Define the abstract class Person
public abstract class Person
{
    // Properties
    public string Name { get; set; }
    public string Address { get; set; }
    public string County { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // Abstract method (to be implemented by subclasses)
    public abstract void DisplayInfo();
}
