namespace CourseManagementSystem.Models
{
    // Наследуется от Course, добавляет место проведения
    public class OfflineCourse : Course
    {
        public string Location { get; set; }

        public OfflineCourse(string name, string location)
        {
            SetName(name);
            Location = location;
        }

        // Реализация абстрактного метода
        public override string GetCourseInfo()
        {
            return $"Offline Course: {GetName()}, Location: {Location}";
        }
    }
}