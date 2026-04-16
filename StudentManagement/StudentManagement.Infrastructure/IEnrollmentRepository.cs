using StudentManagement.Domain;

namespace StudentManagement.Infrastructure.Repositories;

public interface IEnrollmentRepository
{
    Task<int> AddAsync(Enrollment enrollment);
    Task<List<Enrollment>> GetAllAsync();
    Task<List<Enrollment>> GetByStudentIdAsync(int studentId);
}