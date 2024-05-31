using CollegeEnrollmentSystem.Domain.Entities;

public interface IStudentRepository
{
    Student GetStudentById(int id);
    void SaveStudent(Student student);
}
