using System;
public class Lecturer : Person
{
    // Additional property
    public string Pay { get; set; }
    public string Gender { get; set; }
    public string Subject { get; set; }

    // Implement the abstract method from the base class
    public override String TypePerson()
    {
        return "Lecturer";
    }
}
