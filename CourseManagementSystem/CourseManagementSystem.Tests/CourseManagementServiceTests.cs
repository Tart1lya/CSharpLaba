using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem.Tests
{
    public class CourseManagementServiceTests
    {
        private CourseManagementService _service;

        public CourseManagementServiceTests()
        {
            _service = new CourseManagementService();
        }

        [Fact]
        public void AddCourse_AddsCourseSuccessfully()
        {
            // Arrange
            var course = new OnlineCourse(1, "Test Course", "Description", "Platform", "URL");

            // Act
            _service.AddCourse(course);

            // Assert
            var retrievedCourse = _service.GetCourseById(1);
            Assert.NotNull(retrievedCourse);
            Assert.Equal("Test Course", retrievedCourse.Title);
        }

        [Fact]
        public void RemoveCourse_RemovesCourseSuccessfully()
        {
            // Arrange
            var course = new OnlineCourse(1, "Test Course", "Description", "Platform", "URL");
            _service.AddCourse(course);
            Assert.NotNull(_service.GetCourseById(1));

            // Act
            bool result = _service.RemoveCourse(1);

            // Assert
            Assert.True(result);
            Assert.Null(_service.GetCourseById(1));
        }

        [Fact]
        public void AddTeacher_AddsTeacherSuccessfully()
        {
            // Arrange
            var teacher = new Teacher(1, "Иван", "Петров", "Математика");

            // Act
            _service.AddTeacher(teacher);

            // Assert
            var retrievedTeacher = _service.GetTeacherById(1);
            Assert.NotNull(retrievedTeacher);
            Assert.Equal("Иван", retrievedTeacher.FirstName);
        }

        [Fact]
        public void AddStudent_AddsStudentSuccessfully()
        {
            // Arrange
            var student = new Student(1, "Алексей", "Иванов", "alex@example.com");

            // Act
            _service.AddStudent(student);

            // Assert
            var retrievedStudent = _service.GetStudentById(1);
            Assert.NotNull(retrievedStudent);
            Assert.Equal("Алексей", retrievedStudent.FirstName);
        }

        [Fact]
        public void AssignTeacherToCourse_AssignsSuccessfully()
        {
            // Arrange
            var teacher = new Teacher(1, "Иван", "Петров", "Математика");
            var course = new OnlineCourse(1, "Test Course", "Description", "Platform", "URL");
            
            _service.AddTeacher(teacher);
            _service.AddCourse(course);

            // Act
            bool result = _service.AssignTeacherToCourse(1, 1);

            // Assert
            Assert.True(result);
            Assert.Equal(teacher, course.Teacher);
            Assert.Contains(course, teacher.Courses);
        }

        [Fact]
        public void EnrollStudentInCourse_EnrollsSuccessfully()
        {
            // Arrange
            var student = new Student(1, "Алексей", "Иванов", "alex@example.com");
            var course = new OnlineCourse(1, "Test Course", "Description", "Platform", "URL");
            
            _service.AddStudent(student);
            _service.AddCourse(course);

            // Act
            bool result = _service.EnrollStudentInCourse(1, 1);

            // Assert
            Assert.True(result);
            Assert.Contains(student, course.Students);
            Assert.Equal(1, course.GetStudentCount());
        }

        [Fact]
        public void UnenrollStudentFromCourse_UnenrollsSuccessfully()
        {
            // Arrange
            var student = new Student(1, "Алексей", "Иванов", "alex@example.com");
            var course = new OnlineCourse(1, "Test Course", "Description", "Platform", "URL");
            
            _service.AddStudent(student);
            _service.AddCourse(course);
            _service.EnrollStudentInCourse(1, 1);
            Assert.Contains(student, course.Students);

            // Act
            bool result = _service.UnenrollStudentFromCourse(1, 1);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(student, course.Students);
            Assert.Equal(0, course.GetStudentCount());
        }

        [Fact]
        public void GetCoursesByTeacher_ReturnsCorrectCourses()
        {
            // Arrange
            var teacher = new Teacher(1, "Иван", "Петров", "Математика");
            var course1 = new OnlineCourse(1, "Course 1", "Description", "Platform", "URL");
            var course2 = new OnlineCourse(2, "Course 2", "Description", "Platform", "URL");
            
            _service.AddTeacher(teacher);
            _service.AddCourse(course1);
            _service.AddCourse(course2);
            
            _service.AssignTeacherToCourse(1, 1);
            _service.AssignTeacherToCourse(1, 2);

            // Act
            var teacherCourses = _service.GetCoursesByTeacher(1);

            // Assert
            Assert.Equal(2, teacherCourses.Count);
            Assert.Contains(course1, teacherCourses);
            Assert.Contains(course2, teacherCourses);
        }

        [Fact]
        public void GetStudentsByCourse_ReturnsCorrectStudents()
        {
            // Arrange
            var student1 = new Student(1, "Алексей", "Иванов", "alex@example.com");
            var student2 = new Student(2, "Елена", "Кузнецова", "elena@example.com");
            var course = new OnlineCourse(1, "Test Course", "Description", "Platform", "URL");
            
            _service.AddStudent(student1);
            _service.AddStudent(student2);
            _service.AddCourse(course);
            
            _service.EnrollStudentInCourse(1, 1);
            _service.EnrollStudentInCourse(2, 1);

            // Act
            var courseStudents = _service.GetStudentsByCourse(1);

            // Assert
            Assert.Equal(2, courseStudents.Count);
            Assert.Contains(student1, courseStudents);
            Assert.Contains(student2, courseStudents);
        }

        [Fact]
        public void RemoveStudent_RemovesStudentFromAllCourses()
        {
            // Arrange
            var student = new Student(1, "Алексей", "Иванов", "alex@example.com");
            var course1 = new OnlineCourse(1, "Course 1", "Description", "Platform", "URL");
            var course2 = new OnlineCourse(2, "Course 2", "Description", "Platform", "URL");
            
            _service.AddStudent(student);
            _service.AddCourse(course1);
            _service.AddCourse(course2);
            
            _service.EnrollStudentInCourse(1, 1);
            _service.EnrollStudentInCourse(1, 2);
            
            Assert.Contains(student, course1.Students);
            Assert.Contains(student, course2.Students);

            // Act
            bool result = _service.RemoveStudent(1);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(student, course1.Students);
            Assert.DoesNotContain(student, course2.Students);
            Assert.Null(_service.GetStudentById(1));
        }

        [Fact]
        public void RemoveTeacher_RemovesTeacherAndAllHisCourses()
        {
            // Arrange
            var teacher = new Teacher(1, "Иван", "Петров", "Математика");
            var course = new OnlineCourse(1, "Course 1", "Description", "Platform", "URL");
            
            _service.AddTeacher(teacher);
            _service.AddCourse(course);
            _service.AssignTeacherToCourse(1, 1);
            
            Assert.NotNull(_service.GetCourseById(1));
            Assert.Equal(teacher, course.Teacher);

            // Act
            bool result = _service.RemoveTeacher(1);

            // Assert
            Assert.True(result);
            Assert.Null(_service.GetCourseById(1));
            Assert.Empty(teacher.Courses);
        }

        [Fact]
        public void OnlineCourse_HasCorrectType()
        {
            // Arrange & Act
            var course = new OnlineCourse(1, "Test", "Description", "Platform", "URL");

            // Assert
            Assert.Equal("Online", course.GetCourseType());
        }

        [Fact]
        public void OfflineCourse_HasCorrectType()
        {
            // Arrange & Act
            var course = new OfflineCourse(1, "Test", "Description", "Location", "Room");

            // Assert
            Assert.Equal("Offline", course.GetCourseType());
        }
    }
}
