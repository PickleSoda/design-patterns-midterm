using CollegeEnrollmentSystem.Application.Repositories;
using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Services
{
    public class FinancialService
    {
        private IStudentRepository studentRepository; // Assuming such a repository exists

        public FinancialService(IStudentRepository repository)
        {
            studentRepository = repository;
        }

        public void PayTuition(int studentId, decimal amount)
        {
            var student = studentRepository.GetStudentById(studentId);
            if (student != null)
            {
                student.PayTuition(amount);
                studentRepository.SaveStudent(student); // Update student record after payment
            }
        }
    }
}
