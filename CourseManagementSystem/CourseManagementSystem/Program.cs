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

            // Список преподавателей
            var teachers = new List<Teacher>
            {
                new Teacher("Иванов И.И."),
                new Teacher("Петрова А.Б."),
                new Teacher("Смирнов К.Л.")
            };

            // Список студентов
            var students = new List<Student>
            {
                new Student("Петров С.В."),
                new Student("Сидоров А.Б."),
                new Student("Кузнецова Е.М."),
                new Student("Волков И.Т."),
                new Student("Морозова Н.П.")
            };

            // Список курсов
            var courses = new List<ICourse>
            {
                new OnlineCourse("Программирование", "https://example.com/prog"),
                new OfflineCourse("Математика", "301"),
                new OnlineCourse("Дизайн", "https://example.com/design"),
                new OfflineCourse("Физика", "402")
            };

            // Назначаем преподавателей и студентов на курсы

            // Курс 1: Программирование
            courses[0].SetTeacher(teachers[0]); // Иванов И.И.
            courses[0].AddStudent(students[0]); // Петров С.В.
            courses[0].AddStudent(students[2]); // Кузнецова Е.М.

            // Курс 2: Математика
            courses[1].SetTeacher(teachers[0]); // Иванов И.И.
            courses[1].AddStudent(students[1]); // Сидоров А.Б.

            // Курс 3: Дизайн
            courses[2].SetTeacher(teachers[1]); // Петрова А.Б.
            courses[2].AddStudent(students[3]); // Волков И.Т.

            // Курс 4: Физика
            courses[3].SetTeacher(teachers[2]); // Смирнов К.Л.
            courses[3].AddStudent(students[4]); // Морозова Н.П.
            courses[3].AddStudent(students[0]); // Петров С.В.

            // Добавление всех курсов в систему
            foreach (var course in courses)
            {
                service.AddCourse(course);
            }

            // Вывод всех курсов
            Console.WriteLine("=== Все курсы ===");
            foreach (var course in service.GetAllCourses())
            {
                Console.WriteLine(course.GetCourseInfo());
                Console.WriteLine();
            }

            // Вывод курсов конкретного преподавателя
            Console.WriteLine($"\n=== Курсы преподавателя {teachers[0].Name} ==="); // Иванов И.И.
            foreach (var course in service.GetCoursesByTeacher(teachers[0]))
            {
                Console.WriteLine(course.GetCourseInfo());
            }

            Console.WriteLine($"\n=== Курсы преподавателя {teachers[1].Name} ==="); // Петрова А.Б.
            foreach (var course in service.GetCoursesByTeacher(teachers[1]))
            {
                Console.WriteLine(course.GetCourseInfo());
            }

            Console.WriteLine($"\n=== Курсы преподавателя {teachers[2].Name} ==="); // Смирнов К.Л.
            foreach (var course in service.GetCoursesByTeacher(teachers[2]))
            {
                Console.WriteLine(course.GetCourseInfo());
            }
        }
    }
}