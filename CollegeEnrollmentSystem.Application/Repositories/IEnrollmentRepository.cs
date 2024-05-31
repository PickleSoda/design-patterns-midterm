using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Repositories
{
    public interface IEnrollmentRepository
    {
        void SaveEnrollment(Enrollment enrollment);
        IEnumerable<Enrollment> GetEnrollmentsByStudentId(int studentId);

        Enrollment GetEnrollmentById(int courseId);
    }

}
