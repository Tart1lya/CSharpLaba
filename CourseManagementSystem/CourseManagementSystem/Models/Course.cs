using CourseManagementSystem.Interfaces;

namespace CourseManagementSystem.Models
{
    public abstract class Course : ICourse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; }

        protected Course(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (!Students.Contains(student))
            {
                Students.Add(student);
            }
        }

        public bool RemoveStudent(int studentId)
        {
            var student = Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Students.Remove(student);
                return true;
            }
            return false;
        }

        public int GetStudentCount()
        {
            return Students.Count;
        }

        public abstract string GetCourseType();

        public override string ToString()
        {
            return $"Course: {Title} - {GetCourseType()} | Teacher: {Teacher?.FirstName} {Teacher?.LastName}";
        }
    }
}