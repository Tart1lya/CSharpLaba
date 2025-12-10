using CourseManagementSystem.Interfaces;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Services
{
    public class CourseService
    {
        private List<ICourse> _courses = new List<ICourse>();

        // Добавление курса
        public void AddCourse(ICourse course)
        {
            _courses.Add(course);
        }

        // Удаление курса
        public bool RemoveCourse(string courseName)
        {
            var course = _courses.FirstOrDefault(c => c.GetName() == courseName);
            if (course != null)
            {
                _courses.Remove(course);
                return true;
            }
            return false;
        }

        // Получить все курсы конкретного преподавателя
        public List<ICourse> GetCoursesByTeacher(Teacher teacher)
        {
            return _courses.Where(c => c.GetTeacher() != null && c.GetTeacher().Name == teacher.Name).ToList();
        }

        // Получить все курсы
        public List<ICourse> GetAllCourses()
        {
            return _courses;
        }
    }
}