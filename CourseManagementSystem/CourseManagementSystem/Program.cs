using CourseManagementSystem.Interfaces;
using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CourseService();

            var teachers = new List<Teacher>
            {
                new Teacher("Иванов И.И."),
                new Teacher("Петрова А.Б."),
                new Teacher("Смирнов К.Л.")
            };

            var students = new List<Student>
            {
                new Student("Петров С.В."),
                new Student("Сидоров А.Б."),
                new Student("Кузнецова Е.М."),
                new Student("Волков И.Т."),
                new Student("Морозова Н.П.")
            };

            var courses = new List<ICourse>
            {
                new OnlineCourse("Программирование", "https://example.com/prog"),
                new OfflineCourse("Математика", "301"),
                new OnlineCourse("Дизайн", "https://example.com/design"),
                new OfflineCourse("Физика", "402")
            };

            courses[0].SetTeacher(teachers[0]);
            courses[0].AddStudent(students[0]);
            courses[0].AddStudent(students[2]);

            courses[1].SetTeacher(teachers[0]);
            courses[1].AddStudent(students[1]);

            courses[2].SetTeacher(teachers[1]);
            courses[2].AddStudent(students[3]);

            courses[3].SetTeacher(teachers[2]);
            courses[3].AddStudent(students[4]);
            courses[3].AddStudent(students[0]);

            foreach (var course in courses)
            {
                service.AddCourse(course);
            }

            Console.WriteLine("=== Все курсы ===");
            foreach (var course in service.GetAllCourses())
            {
                Console.WriteLine(course.GetCourseInfo());
                Console.WriteLine();
            }

            Console.WriteLine($"\n=== Курсы преподавателя {teachers[0].GetName()} ===");
            foreach (var course in service.GetCoursesByTeacher(teachers[0]))
            {
                Console.WriteLine(course.GetCourseInfo());
            }

            Console.WriteLine($"\n=== Курсы преподавателя {teachers[1].GetName()} ===");
            foreach (var course in service.GetCoursesByTeacher(teachers[1]))
            {
                Console.WriteLine(course.GetCourseInfo());
            }

            Console.WriteLine($"\n=== Курсы преподавателя {teachers[2].GetName()} ===");
            foreach (var course in service.GetCoursesByTeacher(teachers[2]))
            {
                Console.WriteLine(course.GetCourseInfo());
            }
        }
    }
}