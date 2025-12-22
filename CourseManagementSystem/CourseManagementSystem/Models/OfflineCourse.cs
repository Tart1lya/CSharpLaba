namespace CourseManagementSystem.Models
{
    public class OfflineCourse : Course
    {
        private string _location;

        public OfflineCourse(string name, string location)
        {
            SetName(name);
            SetLocation(location);
        }

        public string GetLocation() => _location;
        public void SetLocation(string location) => _location = location;

        public override string GetCourseInfo()
        {
            var studentNames = new List<string>();
            foreach (var student in GetStudents())
            {
                studentNames.Add(student.GetName());
            }
            var students = string.Join(", ", studentNames);

            return $"Оффлайн курс: {GetName()}, Аудитория: {GetLocation()}\n  Студенты: [{students}]";
        }
    }
}