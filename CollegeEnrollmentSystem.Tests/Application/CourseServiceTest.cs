using CollegeEnrollmentSystem.Application.Repositories;
using CollegeEnrollmentSystem.Application.Services;
using CollegeEnrollmentSystem.Domain.Entities;
using CollegeEnrollmentSystem.Tests.Mocks;
using Moq;
using Xunit;

public class CourseServiceTests
{
    private readonly Mock<ICourseRepository> courseRepositoryMock;
    private readonly Mock<IEnrollmentRepository> enrollmentRepositoryMock;
    private readonly Mock<IStudentRepository> studentRepositoryMock;
    private readonly CourseService courseService;

    public CourseServiceTests()
    {
        var mockFactory = new MockRepositoryFactory();
        courseRepositoryMock = mockFactory.CreateCourseRepository();
        enrollmentRepositoryMock = mockFactory.CreateEnrollmentRepository();
        studentRepositoryMock = mockFactory.CreateStudentRepository();
        courseService = new CourseService(
            courseRepositoryMock.Object,
            enrollmentRepositoryMock.Object,
            studentRepositoryMock.Object
        );

        courseRepositoryMock
            .Setup(repo => repo.GetCourseById(It.IsAny<int>()))
            .Returns(new Course { CourseId = 1, Name = "Math" });
    }

    [Fact]
    public void RegisterCourse_ShouldCreateEnrollment()
    {
        // Arrange
        var student = new Student { UserId = 1, Name = "Student One" };
        var course = new Course { CourseId = 1, Name = "Math" };

        // Act
        courseService.RegisterCourse(student, course);

        // Assert
        enrollmentRepositoryMock.Verify(
            repo => repo.SaveEnrollment(It.IsAny<Enrollment>()),
            Times.Once()
        );
    }

    [Fact]
    public void DropCourse_ShouldRemoveEnrollment()
    {
        // Arrange
        var student = new Student { UserId = 1, Name = "Student One" };
        student.Enrollments.Add(
            new Enrollment
            {
                EnrollmentId = 1,
                Student = student,
                Course = new Course { CourseId = 1, Name = "Math" }
            }
        );
        var course = new Course { CourseId = 1, Name = "Math" };

        // Act
        courseService.DropCourse(student, course);

        // Assert
        enrollmentRepositoryMock.Verify(
            repo => repo.SaveEnrollment(It.IsAny<Enrollment>()),
            Times.Once()
        );
    }
}
