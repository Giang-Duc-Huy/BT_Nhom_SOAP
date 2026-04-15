using StudentManagement.Domain;

namespace StudentManagement.Application.Services;

public interface IStudentService
{
    Task<int> CreateStudentAsync(Student student);
    Task<Student?> GetStudentByIdAsync(int id);
    Task<List<Student>> GetAllStudentsAsync();
}
