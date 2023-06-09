namespace SampleCrud.DTOs;

public class CreateStudentRequestDTO
{
    public required string FirstName{ get; set; }
    public required string LastName { get; set; }
    public int GradeLevelId { get; set; }
}
