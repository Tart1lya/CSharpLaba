using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem.Tests
{
    public class CourseServiceTests
    {
        [Fact]
        public void AddCourse_AddsSuccessfully()
        {
            var service = new CourseService();
            var course = new OnlineCourse("Тестовый курс", "https://test.com");

            service.AddCourse(course);

            Assert.Single(service.GetAllCourses());
        }

        [Fact]
        public void RemoveCourse_RemovesSuccessfully()
        {
            var service = new CourseService();
            var course = new OnlineCourse("Тестовый курс", "https://test.com");
            service.AddCourse(course);

            bool result = service.RemoveCourse("Тестовый курс");

            Assert.True(result);
            Assert.Empty(service.GetAllCourses());
        }

        [Fact]
        public void GetCoursesByTeacher_ReturnsCorrectCourses()
        {
            var service = new CourseService();
            var teacher = new Teacher("Иванов И.И.");
            var course = new OfflineCourse("Математика", "Ауд. 101");
            course.SetTeacher(teacher);

            service.AddCourse(course);

            var courses = service.GetCoursesByTeacher(teacher);

            Assert.Single(courses);
            Assert.Equal("Математика", courses[0].GetName());
        }
    }
}