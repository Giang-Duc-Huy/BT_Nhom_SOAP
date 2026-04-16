using StudentManagement.Domain;
namespace StudentManagement.Domain;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double? Grade { get; set; }

    // Navigation properties
    public Student? Student { get; set; }
    public Course? Course { get; set; }

    public override string ToString()
    {
        return $"Enrollment ID: {Id} | Student: {Student?.FullName} | Course: {Course?.CourseName} | Grade: {Grade}";
    }
}