using CollegeEnrollmentSystem.Application.Repositories;
using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IEnrollmentRepository enrollmentRepository;

        private readonly IStudentRepository studentRepository;

        public CourseService(
            ICourseRepository courseRepository,
            IEnrollmentRepository enrollmentRepository,
            IStudentRepository studentRepository
        )
        {
            this.courseRepository = courseRepository;
            this.enrollmentRepository = enrollmentRepository;
            this.studentRepository = studentRepository;
        }

        public void RegisterCourse(Student student, Course course)
        {
            var enrollment = new Enrollment { Student = student, Course = course };
            student.Enrollments.Add(enrollment);
            enrollmentRepository.SaveEnrollment(enrollment);
        }

        public void DropCourse(Student student, Course course)
        {
            var enrollment = student.Enrollments.FirstOrDefault(e =>
                e.Course.CourseId == course.CourseId
            );
            if (enrollment != null)
            {
                student.Enrollments.Remove(enrollment);
                enrollmentRepository.SaveEnrollment(enrollment);
            }
        }
    }
}
