using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
	public async Task<int> AddAsync(Student student)
	{
		using var context = new AppDbContext();
		context.Students.Add(student);
		await context.SaveChangesAsync();
		return student.Id;
	}

	public async Task<Student?> GetByIdAsync(int id)
	{
		using var context = new AppDbContext();
		return await context.Students.FindAsync(id);
	}

	public async Task<List<Student>> GetAllAsync()
	{
		using var context = new AppDbContext();
		return await context.Students.ToListAsync();
	}

	public async Task UpdateAsync(Student student)
	{
		using var context = new AppDbContext();
		context.Students.Update(student);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		using var context = new AppDbContext();
		var student = await context.Students.FindAsync(id);
		if (student != null)
		{
			context.Students.Remove(student);
			await context.SaveChangesAsync();
		}
	}
}
