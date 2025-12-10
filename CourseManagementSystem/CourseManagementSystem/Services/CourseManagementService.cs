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
            var result = new List<ICourse>();
            foreach (var course in _courses) 
            {
                if (course.GetTeacher() != null && course.GetTeacher().Name == teacher.Name)
                {
                    result.Add(course);
                }
            }           
            return result;
        }

        // Получить все курсы
        public List<ICourse> GetAllCourses()
        {
            return _courses;
        }
    }
}