using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Application.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repository;

    public EnrollmentService(IEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> EnrollStudentAsync(Enrollment enrollment)
    {
        if (enrollment.Grade.HasValue && (enrollment.Grade < 0 || enrollment.Grade > 10))
            throw new ArgumentException("Grade must be between 0 and 10.");

        return await _repository.AddAsync(enrollment);
    }

    public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
    {
        return await _repository.GetAllAsync();
    }
}