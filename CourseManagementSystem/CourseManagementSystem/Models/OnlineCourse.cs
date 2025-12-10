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
            return $"Online Course: {GetName()}, URL: {Url}";
        }
    }
}