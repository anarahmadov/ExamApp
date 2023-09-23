using ExamApp.DataAccess.Entities;
using ExamApp.Models.ViewModels;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.DTOs
{
    public static class StudentDTOExtensions
    {
        public static Student ToEntity(this StudentDTO student)
        {
            if (student is not null)
            {
                return new Student()
                {
                    ID = student.ID,
                    StudentNumber = student.StudentNumber,
                    StudentName = student.StudentName,
                    StudentSurname = student.StudentSurname,
                    ClassNumber = student.ClassNumber
                };
            }

            return null;
        }
    }
}
