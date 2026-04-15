using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateStudentAsync(Student student)
    {
        if (string.IsNullOrWhiteSpace(student.FullName))
            throw new ArgumentException("Full name is required.");

        if (string.IsNullOrWhiteSpace(student.Email))
            throw new ArgumentException("Email is required.");

        return await _repository.AddAsync(student);
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _repository.GetAllAsync();
    }
}
