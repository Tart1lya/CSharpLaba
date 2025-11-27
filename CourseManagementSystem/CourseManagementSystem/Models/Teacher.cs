using System.Collections.Generic;

namespace CourseManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public List<Course> Courses { get; }

        public Teacher(int id, string firstName, string lastName, string department)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            Courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            if (!Courses.Contains(course))
            {
                Courses.Add(course);
            }
        }

        public void RemoveCourse(Course course)
        {
            Courses.Remove(course);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (Department: {Department})";
        }
    }
}