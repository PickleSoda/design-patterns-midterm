using Moq;
using Xunit;
using CollegeEnrollmentSystem.Application.Repositories;
using CollegeEnrollmentSystem.Application.Services;
using CollegeEnrollmentSystem.Domain.Entities;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> userRepositoryMock;
    private readonly UserService userService;

    public UserServiceTests()
    {
        userRepositoryMock = new Mock<IUserRepository>();
        userService = new UserService(userRepositoryMock.Object);

        // Use Student or Admin instead of User
        userRepositoryMock
            .Setup(repo => repo.GetUserById(It.IsAny<int>()))
            .Returns(new Student { UserId = 1, Name = "Test User" });
    }

    [Fact]
    public void GetUserById_ShouldReturnUser()
    {
        // Act
        var result = userService.GetUserById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test User", result.Name);
        Assert.IsType<Student>(result); // Optionally check type
    }

    [Fact]
    public void SaveUser_ShouldCallRepositorySave()
    {
        // Arrange
        var user = new Student { UserId = 2, Name = "New User" }; // Using Student here

        // Act
        userService.SaveUser(user);

        // Assert
        userRepositoryMock.Verify(
            repo => repo.SaveUser(It.Is<User>(u => u.UserId == 2 && u.Name == "New User")),
            Times.Once()
        );
    }
}
