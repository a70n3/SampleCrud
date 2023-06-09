namespace SampleCrud.Models;
public class StudentSubject
{
    public int Id { get; set; }
    public required int StudentId { get; set; }
    public required int SubjectId { get; set; }
    public bool IsDeleted { get; private set; }
    public virtual Subject Subject { get; set; }
    public void Remove()
    {
        IsDeleted = true;
    }
}
