namespace CourseManagementSystem.Models
{
    public class OfflineCourse : Course
    {
        public string Location { get; set; }
        public string RoomNumber { get; set; }

        public OfflineCourse(int id, string title, string description, string location, string roomNumber) 
            : base(id, title, description)
        {
            Location = location;
            RoomNumber = roomNumber;
        }

        public override string GetCourseType()
        {
            return "Offline";
        }

        public override string ToString()
        {
            return base.ToString() + $" | Location: {Location} | Room: {RoomNumber}";
        }
    }
}