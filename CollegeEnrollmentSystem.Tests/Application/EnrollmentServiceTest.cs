using Xunit;
using Moq;
using CollegeEnrollmentSystem.Application.Services;
using CollegeEnrollmentSystem.Domain.Entities;
using CollegeEnrollmentSystem.Application.Repositories;
using System.Collections.Generic;
using System.Linq;

public class EnrollmentServiceTests
{
    private readonly Mock<IEnrollmentRepository> mockEnrollmentRepository;
    private readonly EnrollmentService enrollmentService;

    public EnrollmentServiceTests()
    {
        mockEnrollmentRepository = new Mock<IEnrollmentRepository>();
        enrollmentService = new EnrollmentService(mockEnrollmentRepository.Object);
    }

    [Fact]
    public void SaveEnrollment_ShouldInvokeRepositorySave()
    {
        // Arrange
        var enrollment = new Enrollment { EnrollmentId = 1, Student = new Student { UserId = 1 }, Course = new Course { CourseId = 101 } };

        // Act
        enrollmentService.SaveEnrollment(enrollment);

        // Assert
        mockEnrollmentRepository.Verify(repo => repo.SaveEnrollment(enrollment), Times.Once());
    }

    [Fact]
    public void GetEnrollmentsByStudentId_ShouldReturnCorrectEnrollments()
    {
        // Arrange
        var enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentId = 1, Student = new Student { UserId = 1 }, Status = EnrollmentStatus.Ongoing },
            new Enrollment { EnrollmentId = 2, Student = new Student { UserId = 1 }, Status = EnrollmentStatus.Finished }
        };
        mockEnrollmentRepository.Setup(repo => repo.GetEnrollmentsByStudentId(1)).Returns(enrollments);

        // Act
        var result = enrollmentService.GetEnrollmentsByStudentId(1);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, e => e.Status == EnrollmentStatus.Ongoing);
        Assert.Contains(result, e => e.Status == EnrollmentStatus.Finished);
    }

    [Fact]
    public void GetTranscript_ShouldCategorizeEnrollmentsCorrectly()
    {
        // Arrange
        var enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentId = 1, Student = new Student { UserId = 1 }, Status = EnrollmentStatus.Ongoing },
            new Enrollment { EnrollmentId = 2, Student = new Student { UserId = 1 }, Status = EnrollmentStatus.Finished }
        };
        mockEnrollmentRepository.Setup(repo => repo.GetEnrollmentsByStudentId(1)).Returns(enrollments);

        // Act
        var transcript = enrollmentService.GetTranscript(1);

        // Assert
        Assert.Single(transcript.OngoingEnrollments);
        Assert.Single(transcript.FinishedEnrollments);
    }
}
