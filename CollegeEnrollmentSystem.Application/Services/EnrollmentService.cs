using CollegeEnrollmentSystem.Application.Repositories;
using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Services
{
    public class EnrollmentService
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository repository)
        {
            enrollmentRepository = repository;
        }

        // Methods to handle enrollment logic
        public void SaveEnrollment(Enrollment enrollment)
        {
            enrollmentRepository.SaveEnrollment(enrollment);
        }

        public IEnumerable<Enrollment> GetEnrollmentsByStudentId(int studentId)
        {
            return enrollmentRepository.GetEnrollmentsByStudentId(studentId);
        }


        public Transcript GetTranscript(int studentId)
        {
            var enrollments = enrollmentRepository.GetEnrollmentsByStudentId(studentId);
            return new Transcript(enrollments);
        }

        public class Transcript
        {
            public IEnumerable<Enrollment> OngoingEnrollments { get; }
            public IEnumerable<Enrollment> FinishedEnrollments { get; }

            public Transcript(IEnumerable<Enrollment> enrollments)
            {
                OngoingEnrollments = enrollments.Where(e => e.Status == EnrollmentStatus.Ongoing);
                FinishedEnrollments = enrollments.Where(e => e.Status == EnrollmentStatus.Finished);
            }
        }
    }
}
