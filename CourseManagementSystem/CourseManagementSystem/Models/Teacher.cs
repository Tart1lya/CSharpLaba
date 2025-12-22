namespace CourseManagementSystem.Models
{
    public class Teacher
    {
        private string _name;

        public Teacher(string name)
        {
            SetName(name);
        }

        public string GetName() => _name;
        public void SetName(string name) => _name = name;
    }
}