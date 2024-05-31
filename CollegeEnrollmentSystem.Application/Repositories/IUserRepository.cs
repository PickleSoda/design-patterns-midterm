using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        void SaveUser(User user);
    }
}
