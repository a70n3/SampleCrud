namespace SampleCrud.Models;

public class Grade
{
    public int Id { get; set; }
    public required int SubjectId { get; set; }
    public required decimal Score { get; set; }
    public Subject Subject { get; set; }
}
