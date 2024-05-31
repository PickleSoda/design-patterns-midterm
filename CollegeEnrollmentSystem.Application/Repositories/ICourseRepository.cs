using CollegeEnrollmentSystem.Domain.Entities;

namespace CollegeEnrollmentSystem.Application.Repositories
{
    public interface ICourseRepository
    {
        Course GetCourseById(int id);
        void SaveCourse(Course course);
        IEnumerable<Course> GetAllCourses();
    }
}
