using StudentManagement.Domain;

namespace StudentManagement.Application.Services;

public interface ICourseService
{
    Task<int> CreateCourseAsync(Course course);
    Task<Course?> GetCourseByIdAsync(int id);
    Task<List<Course>> GetAllCoursesAsync();
}
