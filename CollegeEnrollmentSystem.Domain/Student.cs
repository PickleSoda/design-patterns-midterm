namespace CollegeEnrollmentSystem.Domain.Entities
{

    public class Student : User
    {
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public decimal TuitionBalance { get; set; } = 0;

        // Method to add a payment to the tuition balance
        public void PayTuition(decimal amount)
        {
            TuitionBalance -= amount; // Assuming a positive amount reduces the balance
        }

        // Method to get all enrolled courses
        public IEnumerable<Course> GetEnrolledCourses()
        {
            return Enrollments.Select(e => e.Course);
        }
    }
}
