using StudentManagement.Domain;

namespace StudentManagement.Application.Services;

public interface IEnrollmentService
{
    Task<int> EnrollStudentAsync(Enrollment enrollment);
    Task<List<Enrollment>> GetAllEnrollmentsAsync();
}
