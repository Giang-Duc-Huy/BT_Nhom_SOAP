namespace StudentManagement.Domain;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }

    public override string ToString()
    {
        return $"ID: {Id} - {FullName} ({Email})";
    }
}
