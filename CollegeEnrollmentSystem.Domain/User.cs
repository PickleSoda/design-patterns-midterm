namespace CollegeEnrollmentSystem.Domain.Entities
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
