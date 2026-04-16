using StudentManagement.Application.Services;
using StudentManagement.Domain;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Presentation;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("   STUDENT MANAGEMENT - LAYERED ARCHITECTURE");
        Console.WriteLine("==================================================\n");

        // Khởi tạo các Repository và Service
        var studentRepo = new StudentRepository();
        var courseRepo = new CourseRepository();
        var enrollmentRepo = new EnrollmentRepository();

        var studentService = new StudentService(studentRepo);
        var courseService = new CourseService(courseRepo);
        var enrollmentService = new EnrollmentService(enrollmentRepo);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Quản lý Sinh viên");
            Console.WriteLine("2. Quản lý Môn học");
            Console.WriteLine("3. Đăng ký môn học & Nhập điểm");
            Console.WriteLine("4. Xem danh sách đăng ký");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");

            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        await StudentMenu(studentService);
                        break;
                    case "2":
                        await CourseMenu(courseService);
                        break;
                    case "3":
                        await EnrollmentMenu(studentService, courseService, enrollmentService);
                        break;
                    case "4":
                        await ShowAllEnrollments(enrollmentService);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi: {ex.Message}");
            }
        }
    }

    // Các menu phụ (bạn có thể mở rộng sau)
    static async Task StudentMenu(StudentService service) { /* Person 1 có thể bổ sung */ }
    static async Task CourseMenu(CourseService service) { /* Person 2 có thể bổ sung */ }
    static async Task EnrollmentMenu(StudentService sService, CourseService cService, EnrollmentService eService)
    {
        if (!TryReadInt("Nhập Student ID: ", out var studentId))
            return;

        var student = await sService.GetStudentByIdAsync(studentId);
        if (student is null)
        {
            Console.WriteLine("❌ Student ID không tồn tại.");
            return;
        }

        if (!TryReadInt("Nhập Course ID: ", out var courseId))
            return;

        var course = await cService.GetCourseByIdAsync(courseId);
        if (course is null)
        {
            Console.WriteLine("❌ Course ID không tồn tại.");
            return;
        }

        if (!TryReadDouble("Nhập điểm (0-10): ", out var grade))
            return;

        var enrollment = new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId,
            Grade = grade
        };

        int id = await eService.EnrollStudentAsync(enrollment);
        Console.WriteLine($"✅ Đăng ký thành công! Enrollment ID = {id}");
    }

    static bool TryReadInt(string prompt, out int value)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Dữ liệu trống.");
            value = 0;
            return false;
        }

        if (!int.TryParse(input, out value))
        {
            Console.WriteLine("❌ Dữ liệu không hợp lệ.");
            return false;
        }

        return true;
    }

    static bool TryReadDouble(string prompt, out double value)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Dữ liệu trống.");
            value = 0;
            return false;
        }

        if (!double.TryParse(input, out value))
        {
            Console.WriteLine("❌ Dữ liệu không hợp lệ.");
            return false;
        }

        return true;
    }

    static async Task ShowAllEnrollments(EnrollmentService service)
    {
        var list = await service.GetAllEnrollmentsAsync();
        Console.WriteLine("\n--- DANH SÁCH ĐĂNG KÝ ---");
        foreach (var e in list)
        {
            Console.WriteLine(e);
        }
    }
}