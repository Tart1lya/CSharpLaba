namespace CourseManagementSystem.Models.Interfaces
{
    public interface IStudent
    {
        int Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
}