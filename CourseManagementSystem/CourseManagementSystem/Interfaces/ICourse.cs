namespace CourseManagementSystem.Interfaces
{
    public interface ICourse
    {
        int Id { get; }
        string Title { get; set; }
        string Description { get; set; }
        Models.Teacher Teacher { get; set; }
        List<Models.Student> Students { get; }
        
        void AddStudent(Models.Student student);
        bool RemoveStudent(int studentId);
        int GetStudentCount();
    }
}