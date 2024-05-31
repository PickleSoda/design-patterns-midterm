public interface IUserRepository {
    User GetUserById(int id);
    void SaveUser(User user);
}

public interface ICourseRepository {
    Course GetCourseById(int id);
    void SaveCourse(Course course);
    IEnumerable<Course> GetAllCourses();
}

public interface IEnrollmentRepository {
    void SaveEnrollment(Enrollment enrollment);
    IEnumerable<Enrollment> GetEnrollmentsByStudentId(int studentId);
}
