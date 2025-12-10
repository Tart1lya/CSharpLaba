namespace CourseManagementSystem.Models
{
    // Наследуется от Course, добавляет специфичное поле – URL
    public class OnlineCourse : Course
    {
        public string Url { get; set; }

        public OnlineCourse(string name, string url)
        {
            SetName(name);
            Url = url;
        }

        // Реализация абстрактного метода
        public override string GetCourseInfo()
        {
            var studentNames = new List<string>();
            foreach (var student in GetStudents())
            {
                studentNames.Add(student.Name);
            }
            var students = string.Join(", ", studentNames);
            return $"Онлайн курс: {GetName()}, Ссылка: {Url}\n Студенты: [{students}]";
        }
    }
}