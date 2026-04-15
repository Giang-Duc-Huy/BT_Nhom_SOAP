using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Infrastructure.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    public async Task<int> AddAsync(Enrollment enrollment)
    {
        using var context = new AppDbContext();
        context.Enrollments.Add(enrollment);
        await context.SaveChangesAsync();
        return enrollment.Id;
    }

    public async Task<List<Enrollment>> GetAllAsync()
    {
        using var context = new AppDbContext();
        return await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task<List<Enrollment>> GetByStudentIdAsync(int studentId)
    {
        using var context = new AppDbContext();
        return await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .Where(e => e.StudentId == studentId)
            .ToListAsync();
    }
}