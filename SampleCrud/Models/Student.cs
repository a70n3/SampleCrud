namespace SampleCrud.Models;
public class Student
{
    private List<StudentSubject> _studentSubjects = new();
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int GradeLevelId { get; set; }
    public virtual GradeLevel? GradeLevel { get; set; }
    public List<StudentSubject> StudentSubjects =>_studentSubjects;
    public void AddSubject(int subjectId) 
    {
        var studentSubject = new StudentSubject()
        {
            StudentId = this.Id,
            SubjectId = subjectId
        };
        _studentSubjects.Add(studentSubject);
    }
    public void RemoveSubject(int subjectId)
    {
        var subject = _studentSubjects.FirstOrDefault(x => x.Id == subjectId);
        subject?.Remove();
    }
}
