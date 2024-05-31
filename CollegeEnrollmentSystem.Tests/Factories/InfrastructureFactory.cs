using CollegeEnrollmentSystem.Application.Repositories;
using Moq;

namespace CollegeEnrollmentSystem.Tests.Mocks
{
    public class MockRepositoryFactory
    {
        public Mock<IUserRepository> CreateUserRepository()
        {
            var mock = new Mock<IUserRepository>();
            // Configure the mock as needed for tests
            return mock;
        }

        public Mock<ICourseRepository> CreateCourseRepository()
        {
            var mock = new Mock<ICourseRepository>();
            // Configure the mock as needed for tests
            return mock;
        }

        public Mock<IEnrollmentRepository> CreateEnrollmentRepository()
        {
            var mock = new Mock<IEnrollmentRepository>();
            // Configure the mock as needed for tests
            return mock;
        }

        public Mock<IStudentRepository> CreateStudentRepository()
        {
            var mock = new Mock<IStudentRepository>();
            // Configure the mock as needed for tests
            return mock;
        }
    }
}
