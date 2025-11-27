using CourseManagementSystem.Models;
using CourseManagementSystem.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagementSystem.Services
{
    public class CourseManagementService
    {
        private List<Course> _courses;
        private List<Teacher> _teachers;
        private List<Student> _students;

        public CourseManagementService()
        {
            _courses = new List<Course>();
            _teachers = new List<Teacher>();
            _students = new List<Student>();
        }

        // Управление курсами
        public void AddCourse(Course course)
        {
            if (!_courses.Contains(course))
            {
                _courses.Add(course);
            }
        }

        public bool RemoveCourse(int courseId)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                _courses.Remove(course);
                
                // Удалить курс из списка курсов преподавателя
                if (course.Teacher != null)
                {
                    course.Teacher.RemoveCourse(course);
                }
                
                return true;
            }
            return false;
        }

        public Course GetCourseById(int courseId)
        {
            return _courses.FirstOrDefault(c => c.Id == courseId);
        }

        public List<Course> GetAllCourses()
        {
            return new List<Course>(_courses);
        }

        public List<Course> GetCoursesByTeacher(int teacherId)
        {
            return _courses.Where(c => c.Teacher != null && c.Teacher.Id == teacherId).ToList();
        }

        // Управление преподавателями
        public void AddTeacher(Teacher teacher)
        {
            if (!_teachers.Contains(teacher))
            {
                _teachers.Add(teacher);
            }
        }

        public bool RemoveTeacher(int teacherId)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher != null)
            {
                // Удалить все курсы, которые ведет преподаватель
                var coursesToRemove = teacher.Courses.ToList();
                foreach (var course in coursesToRemove)
                {
                    RemoveCourse(course.Id);
                }
                
                _teachers.Remove(teacher);
                return true;
            }
            return false;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return _teachers.FirstOrDefault(t => t.Id == teacherId);
        }

        public List<Teacher> GetAllTeachers()
        {
            return new List<Teacher>(_teachers);
        }

        // Управление студентами
        public void AddStudent(Student student)
        {
            if (!_students.Contains(student))
            {
                _students.Add(student);
            }
        }

        public bool RemoveStudent(int studentId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                // Удалить студента из всех курсов
                foreach (var course in _courses)
                {
                    course.RemoveStudent(studentId);
                }
                
                _students.Remove(student);
                return true;
            }
            return false;
        }

        public Student GetStudentById(int studentId)
        {
            return _students.FirstOrDefault(s => s.Id == studentId);
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(_students);
        }

        // Назначение преподавателя на курс
        public bool AssignTeacherToCourse(int teacherId, int courseId)
        {
            var teacher = GetTeacherById(teacherId);
            var course = GetCourseById(courseId);
            
            if (teacher != null && course != null)
            {
                // Удалить курс из предыдущего преподавателя
                if (course.Teacher != null)
                {
                    course.Teacher.RemoveCourse(course);
                }
                
                course.Teacher = teacher;
                teacher.AddCourse(course);
                return true;
            }
            
            return false;
        }

        // Получение студентов по курсу
        public List<Student> GetStudentsByCourse(int courseId)
        {
            var course = GetCourseById(courseId);
            if (course != null)
            {
                return new List<Student>(course.Students);
            }
            return new List<Student>();
        }

        // Запись студента на курс
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            var student = GetStudentById(studentId);
            var course = GetCourseById(courseId);
            
            if (student != null && course != null)
            {
                course.AddStudent(student);
                return true;
            }
            
            return false;
        }

        // Отчисление студента с курса
        public bool UnenrollStudentFromCourse(int studentId, int courseId)
        {
            var course = GetCourseById(courseId);
            if (course != null)
            {
                return course.RemoveStudent(studentId);
            }
            
            return false;
        }
    }
}