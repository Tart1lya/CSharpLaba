using CourseManagementSystem.Interfaces;

namespace CourseManagementSystem.Models
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Student(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (Email: {Email})";
        }
    }
}