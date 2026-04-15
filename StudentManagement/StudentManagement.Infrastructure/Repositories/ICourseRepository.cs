using StudentManagement.Domain;

namespace StudentManagement.Infrastructure.Repositories;

public interface ICourseRepository
{
    Task<int> AddAsync(Course course);
    Task<Course?> GetByIdAsync(int id);
    Task<List<Course>> GetAllAsync();
    Task UpdateAsync(Course course);
    Task DeleteAsync(int id);
}
