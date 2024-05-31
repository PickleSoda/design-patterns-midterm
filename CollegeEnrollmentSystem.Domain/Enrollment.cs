namespace CollegeEnrollmentSystem.Domain.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public bool IsApproved { get; set; } = false;
        public int Grade { get; set; } = 0; // Grades on a 0-100 scale, initialized to 0
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending; // Default status

        // Method to update grade
        public void UpdateGrade(int newGrade)
        {
            if (newGrade >= 0 && newGrade <= 100)
            {
                Grade = newGrade;
            }
            else
            {
                throw new ArgumentException("Grade must be between 0 and 100.");
            }
        }
    }

    public enum EnrollmentStatus
    {
        Pending,
        Ongoing,
        Finished
    }
}
