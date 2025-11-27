namespace CourseManagementSystem.Models
{
    public class OnlineCourse : Course
    {
        public string Platform { get; set; }
        public string Url { get; set; }

        public OnlineCourse(int id, string title, string description, string platform, string url) 
            : base(id, title, description)
        {
            Platform = platform;
            Url = url;
        }

        public override string GetCourseType()
        {
            return "Online";
        }

        public override string ToString()
        {
            return base.ToString() + $" | Platform: {Platform} | URL: {Url}";
        }
    }
}