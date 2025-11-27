using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CourseManagementService();

            // Создание преподавателей
            var teacher1 = new Teacher(1, "Иван", "Петров", "Математика");
            var teacher2 = new Teacher(2, "Мария", "Сидорова", "Физика");
            
            service.AddTeacher(teacher1);
            service.AddTeacher(teacher2);

            // Создание курсов
            var onlineCourse = new OnlineCourse(1, "Введение в C#", "Основы программирования", "Coursera", "https://coursera.org/csharp");
            var offlineCourse = new OfflineCourse(2, "Математический анализ", "Продвинутый курс анализа", "Главное здание", "301");

            service.AddCourse(onlineCourse);
            service.AddCourse(offlineCourse);

            // Создание студентов
            var student1 = new Student(1, "Алексей", "Иванов", "alex@example.com");
            var student2 = new Student(2, "Елена", "Кузнецова", "elena@example.com");
            
            service.AddStudent(student1);
            service.AddStudent(student2);

            // Назначение преподавателей на курсы
            service.AssignTeacherToCourse(1, 1); // Иван Петров ведет курс по C#
            service.AssignTeacherToCourse(2, 2); // Мария Сидорова ведет курс по матанализу

            // Запись студентов на курсы
            service.EnrollStudentInCourse(1, 1); // Алексей записался на курс C#
            service.EnrollStudentInCourse(2, 1); // Елена записалась на курс C#
            service.EnrollStudentInCourse(1, 2); // Алексей записался на курс матанализа

            // Вывод информации
            Console.WriteLine("=== Все курсы ===");
            foreach (var course in service.GetAllCourses())
            {
                Console.WriteLine(course);
                Console.WriteLine($"  Студентов: {course.GetStudentCount()}");
                foreach (var student in course.Students)
                {
                    Console.WriteLine($"    - {student}");
                }
            }

            Console.WriteLine("\n=== Курсы преподавателя Ивана Петрова ===");
            var ivanCourses = service.GetCoursesByTeacher(1);
            foreach (var course in ivanCourses)
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("\n=== Студенты курса 'Введение в C#' ===");
            var csharpStudents = service.GetStudentsByCourse(1);
            foreach (var student in csharpStudents)
            {
                Console.WriteLine($"- {student}");
            }
        }
    }
}