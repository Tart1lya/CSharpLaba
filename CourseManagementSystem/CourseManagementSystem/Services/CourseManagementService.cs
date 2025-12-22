using CourseManagementSystem.Interfaces;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Services
{
    public class CourseService
    {
        private List<ICourse> _courses = new List<ICourse>();

        public void AddCourse(ICourse course)
        {
            _courses.Add(course);
        }

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
        public List<ICourse> GetCoursesByTeacher(Teacher teacher)
        {
            var result = new List<ICourse>();
            foreach (var course in _courses) 
            {
                if (course.GetTeacher() != null && course.GetTeacher().GetName() == teacher.GetName())
                {
                    result.Add(course);
                }
            }           
            return result;
        }

        public List<ICourse> GetAllCourses()
        {
            return _courses;
        }
    }
}