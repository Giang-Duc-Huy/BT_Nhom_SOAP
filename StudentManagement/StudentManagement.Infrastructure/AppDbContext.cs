using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;

namespace StudentManagement.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=students.db");
    }
}