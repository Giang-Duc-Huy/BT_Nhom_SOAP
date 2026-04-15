using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    public async Task<int> AddAsync(Course course)
    {
        using var context = new AppDbContext();
        context.Courses.Add(course);
        await context.SaveChangesAsync();
        return course.Id;
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        using var context = new AppDbContext();
        return await context.Courses.FindAsync(id);
    }

    public async Task<List<Course>> GetAllAsync()
    {
        using var context = new AppDbContext();
        return await context.Courses.ToListAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        using var context = new AppDbContext();
        context.Courses.Update(course);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = new AppDbContext();
        var course = await context.Courses.FindAsync(id);
        if (course != null)
        {
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
        }
    }
}
