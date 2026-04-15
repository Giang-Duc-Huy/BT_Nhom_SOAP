using StudentManagement.Domain;

namespace StudentManagement.Infrastructure.Repositories;

public interface IStudentRepository
{
	Task<int> AddAsync(Student student);
	Task<Student?> GetByIdAsync(int id);
	Task<List<Student>> GetAllAsync();
	Task UpdateAsync(Student student);
	Task DeleteAsync(int id);
}
