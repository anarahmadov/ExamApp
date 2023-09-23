using ExamApp.CustomValidations.FluentValidation;
using ExamApp.DataAccess;
using ExamApp.DataAccess.Abstractions;
using ExamApp.Middlewares;
using ExamApp.Services;
using ExamApp.Services.Abstractions;
using ExamApp.Services.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddValidatorsFromAssemblyContaining<LessonDTO>(ServiceLifetime.Scoped);
builder.Services.AddValidatorsFromAssemblyContaining<StudentDTO>(ServiceLifetime.Scoped);
builder.Services.AddValidatorsFromAssemblyContaining<ExamDTO>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IValidator<LessonDTO>, LessonValidator>();
builder.Services.AddScoped<IValidator<StudentDTO>, StudentValidator>();
builder.Services.AddScoped<IValidator<ExamDTO>, ExamValidator>();
builder.Services.AddTransient<ILessonService, LessonService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IExamService, ExamService>();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IExamRepository, ExamRepository>();

var connectionString = builder.Configuration.GetConnectionString("ExamAppDB");
builder.Services.AddDbContext<ExamAppDBContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lesson}/{action=RegisterLesson}/{id?}");

app.Run();
