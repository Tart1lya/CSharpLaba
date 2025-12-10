using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CourseService();

            var teacher1 = new Teacher("Иванов И.И.");
            var teacher2 = new Teacher("Петрова И.И.");
            var student1 = new Student("Петров С.В.");
            var student2 = new Student("Сидоров А.Б.");

            var onlineCourse = new OnlineCourse("Программирование", "https://example.com");
            var offlineCourse = new OfflineCourse("Математика", "Ауд. 301");

            onlineCourse.SetTeacher(teacher1);
            onlineCourse.AddStudent(student1);

            offlineCourse.SetTeacher(teacher2);
            offlineCourse.AddStudent(student2);

            service.AddCourse(onlineCourse);
            service.AddCourse(offlineCourse);

            // Вывести информацию о курсах
            foreach (var course in service.GetAllCourses())
            {
                Console.WriteLine(course.GetCourseInfo());
            }

            // Получить курсы преподавателя
            var coursesByTeacher = service.GetCoursesByTeacher(teacher1);
            Console.WriteLine($"\nКурсы преподавателя {teacher1.Name}:");
            foreach (var course in coursesByTeacher)
            {
                Console.WriteLine(course.GetCourseInfo());
            }
        }
    }
}