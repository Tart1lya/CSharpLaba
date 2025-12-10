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
            var students = string.Join(", ", GetStudents().Select(s => s.Name));
            return $"Онлайн курс: {GetName()}, Ссылка: {Url}\n Студенты: [{students}]";
        }
    }
}