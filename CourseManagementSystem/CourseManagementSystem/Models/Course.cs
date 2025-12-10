using CourseManagementSystem.Interfaces;

namespace CourseManagementSystem.Models
{
    // Абстрактный базовый класс, от которого будут наследоваться другие типы курсов.
    public abstract class Course : ICourse
    {
        private string _name;
        private Teacher _teacher;
        private List<Student> _students = new List<Student>();

        public string GetName() => _name;
        public void SetName(string name) => _name = name;

        public Teacher GetTeacher() => _teacher;
        public void SetTeacher(Teacher teacher) => _teacher = teacher;

        public List<Student> GetStudents() => _students;

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        // Абстрактный метод, который должны реализовать потомки
        public abstract string GetCourseInfo();
    }
}