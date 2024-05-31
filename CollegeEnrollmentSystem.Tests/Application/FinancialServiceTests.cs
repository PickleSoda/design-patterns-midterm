using CollegeEnrollmentSystem.Application.Services;
using CollegeEnrollmentSystem.Domain.Entities;
using Moq;
using Xunit;

public class FinancialServiceTests
{
    [Fact]
    public void PayTuition_ShouldDecreaseTuitionBalance()
    {
        // Setup
        var mockStudentRepo = new Mock<IStudentRepository>();
        var student = new Student { UserId = 1, TuitionBalance = 1000 };
        mockStudentRepo.Setup(r => r.GetStudentById(1)).Returns(student);
        var service = new FinancialService(mockStudentRepo.Object);

        // Act
        service.PayTuition(1, 200);

        // Assert
        Assert.Equal(800, student.TuitionBalance);
        mockStudentRepo.Verify(r => r.SaveStudent(It.IsAny<Student>()), Times.Once());
    }
}
