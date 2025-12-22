namespace CourseManagementSystem.Models
{
    public class OnlineCourse : Course
    {
        private string _url;

        public OnlineCourse(string name, string url)
        {
            SetName(name);
            SetUrl(url);
        }

        public string GetUrl() => _url;
        public void SetUrl(string url) => _url = url;

        public override string GetCourseInfo()
        {
            var studentNames = new List<string>();
            foreach (var student in GetStudents())
            {
                studentNames.Add(student.GetName());
            }
            var students = string.Join(", ", studentNames);

            return $"Онлайн курс: {GetName()}, Ссылка: {GetUrl()}\n  Студенты: [{students}]";
        }
    }
}