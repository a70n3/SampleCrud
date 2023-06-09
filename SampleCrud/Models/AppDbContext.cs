using Microsoft.EntityFrameworkCore;

namespace SampleCrud.Models;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Student> Students{ get; set; }
    public DbSet<GradeLevel> GradeLevels{ get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
}
