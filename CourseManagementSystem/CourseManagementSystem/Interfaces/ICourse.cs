using CourseManagementSystem.Models;

namespace CourseManagementSystem.Interfaces
{
    public interface ICourse
    {
        string GetName();
        void SetName(string name);

        Teacher GetTeacher();
        void SetTeacher(Teacher teacher);

        List<Student> GetStudents();
        void AddStudent(Student student);

        string GetCourseInfo();
    }
}