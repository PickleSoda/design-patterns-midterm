using CollegeEnrollmentSystem.Application.Repositories;
using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void SaveUser(User user)
        {
            userRepository.SaveUser(user);
        }
    }
}
