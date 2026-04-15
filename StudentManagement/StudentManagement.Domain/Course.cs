namespace StudentManagement.Domain;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public int Credits { get; set; }

    public override string ToString()
    {
        return $"ID: {Id} - {CourseName} ({Credits} credits)";
    }
}
