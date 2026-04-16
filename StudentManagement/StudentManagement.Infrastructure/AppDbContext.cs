using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;

namespace StudentManagement.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=students.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FullName = "Nguyen Van A", Email = "a@student.local", BirthDate = new DateOnly(2000, 1, 1) },
            new Student { Id = 2, FullName = "Tran Thi B", Email = "b@student.local", BirthDate = new DateOnly(2001, 2, 2) }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, CourseName = "Lap trinh C#", Credits = 3 },
            new Course { Id = 2, CourseName = "Co so du lieu", Credits = 4 }
        );

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany()
            .HasForeignKey(e => e.CourseId);
    }
}
