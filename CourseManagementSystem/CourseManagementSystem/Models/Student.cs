namespace CourseManagementSystem.Models
{
    public class Student
    {
        private string _name;

        public Student(string name)
        {
            SetName(name);
        }

        public string GetName() => _name;
        public void SetName(string name) => _name = name;
    }
}