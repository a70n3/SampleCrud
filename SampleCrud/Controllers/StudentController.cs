using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleCrud.DTOs;
using SampleCrud.Models;

namespace SampleCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;
    public StudentController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.Include(p=>p.GradeLevel).ToListAsync();
        return Ok(students);
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateStudentRequestDTO student)
    {
        var newStudent = new Student() 
        { 
            FirstName = student.FirstName,
            LastName = student.LastName, 
            GradeLevelId = student.GradeLevelId 
        };

        _context.Students.Add(newStudent);
        await _context.SaveChangesAsync();
        return Ok(student);
    }
    [HttpPost("add-subject")]
    public async Task<IActionResult> AddSubject(UpdateStudentSubjectDTO updateSubject)
    {

        var student = await _context.Students.FirstOrDefaultAsync(x=>x.Id == updateSubject.StudentId); 
        if (student == null) return BadRequest("Invalid Student Id");

        student.AddSubject(updateSubject.SubjectId);

        await _context.SaveChangesAsync();

        return Ok(student);
    }
    [HttpPost("remove-subject")]
    public async Task<IActionResult> RemoveSubject(UpdateStudentSubjectDTO updateSubject)
    {
        var student = await _context
            .Students
            .Include(s=>s.StudentSubjects)
            .FirstOrDefaultAsync(x => x.Id == updateSubject.StudentId);

        if (student == null) return BadRequest("Invalid Student Id");

        student.RemoveSubject(updateSubject.SubjectId);

        await _context.SaveChangesAsync();

        return Ok(student);
    }
    [HttpGet("{studentId:int}")]
    public async Task<IActionResult> View(int studentId)
    {
        var student = await _context
            .Students
            .Include(x => x.GradeLevel)
            .Include(s => s.StudentSubjects.Where(x=>x.IsDeleted == false)).ThenInclude(x=>x.Subject)
            .FirstOrDefaultAsync(s=>s.Id == studentId);

        return Ok(student);
    }
}
