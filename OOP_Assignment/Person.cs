using System;
public abstract class Person
{
    // Attributes of Person Class
    public string Address { get; set; }
    public string Name { get; set; }

    public string Phone { get; set; }

    public string County { get; set; }
    public int Age { get; set; }

    public string Email { get; set; }

    // Abstract method (to be implemented by subclasses)
    public abstract String TypePerson();
}
