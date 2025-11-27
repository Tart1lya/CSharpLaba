using System.Collections.Generic;

namespace CourseManagementSystem.Models.Interfaces
{
    public interface ICourse
    {
        int Id { get; }
        string Title { get; set; }
        string Description { get; set; }
        Teacher Teacher { get; set; }
        List<Student> Students { get; }
        
        void AddStudent(Student student);
        bool RemoveStudent(int studentId);
        int GetStudentCount();
    }
}