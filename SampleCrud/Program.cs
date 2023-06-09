using Microsoft.EntityFrameworkCore;
using SampleCrud.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o=>o.UseInMemoryDatabase("StudentDb"));
var app = builder.Build();

//Populate Dummy Data
AddStudentData(app);
AddGradeLevelData(app);
AddSubjectsData(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddStudentData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<AppDbContext>();

    var student1 = new Student() { Id = 1, FirstName = "Student", LastName = "One" ,GradeLevelId = 1};
    var student2 = new Student() { Id = 2, FirstName = "Student", LastName = "One" ,GradeLevelId = 2 };
    var student3 = new Student() { Id = 3, FirstName = "Student", LastName = "One" ,GradeLevelId = 3 };

    db.Students.Add(student1);
    db.Students.Add(student2);
    db.Students.Add(student3);

    db.SaveChanges();
}

static void AddGradeLevelData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<AppDbContext>();

    var grade1 = new GradeLevel() { Id = 1, Name = "Grade One"};
    var grade2 = new GradeLevel() { Id = 2, Name = "Grade Two" };
    var grade3 = new GradeLevel() { Id = 3, Name = "Grade Three" };
    var grade4 = new GradeLevel() { Id = 4, Name = "Grade Four" };
    var grade5 = new GradeLevel() { Id = 5, Name = "Grade Five" };
    var grade6 = new GradeLevel() { Id = 6, Name = "Grade Six" };
    

    db.GradeLevels.Add(grade1);
    db.GradeLevels.Add(grade2);
    db.GradeLevels.Add(grade3);
    db.GradeLevels.Add(grade4);
    db.GradeLevels.Add(grade5);
    db.GradeLevels.Add(grade6);
    db.SaveChanges();
}

static void AddSubjectsData(WebApplication app) 
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<AppDbContext>();

    var subject1 = new Subject() { Id = 1, Name = "Mathematics", };
    var subject2 = new Subject() { Id = 2, Name = "English" };
    var subject3 = new Subject() { Id = 3, Name = "Economics" };
    var subject4 = new Subject() { Id = 4, Name = "History" };
    var subject5 = new Subject() { Id = 5, Name = "Anatomy" };
    var subject6 = new Subject() { Id = 6, Name = "Biology" };

    db.Subjects.Add(subject1);
    db.Subjects.Add(subject2);
    db.Subjects.Add(subject3);
    db.Subjects.Add(subject4);
    db.Subjects.Add(subject5);
    db.Subjects.Add(subject6);

    db.SaveChanges();

}