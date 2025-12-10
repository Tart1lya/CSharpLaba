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
            var studentNames = new List<string>();
            foreach (var student in GetStudents())
            {
                studentNames.Add(student.Name);
            }
            var students = string.Join(", ", studentNames);
            return $"Оффлайн курс: {GetName()}, Аудитория: {Location}\n Студенты: [{students}]";
        }
    }
}