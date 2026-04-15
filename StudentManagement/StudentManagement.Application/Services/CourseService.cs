using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateCourseAsync(Course course)
    {
        if (string.IsNullOrWhiteSpace(course.CourseName))
            throw new ArgumentException("Course name is required.");

        if (course.Credits <= 0)
            throw new ArgumentException("Credits must be greater than 0.");

        return await _repository.AddAsync(course);
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        return await _repository.GetAllAsync();
    }
}
