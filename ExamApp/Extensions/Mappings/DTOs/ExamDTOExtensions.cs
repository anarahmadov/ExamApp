using ExamApp.DataAccess.Entities;
using ExamApp.Models.ViewModels;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.DTOs
{
    public static class ExamDTOExtensions
    {
        public static Exam ToEntity(this ExamDTO examDTO)
        {
            if (examDTO is not null)
            {
                return new Exam()
                {
                    ID = examDTO.ID,
                    LessonCode = examDTO.LessonCode,
                    StudentNumber = examDTO.StudentNumber,
                    ExamDate = examDTO.ExamDate,
                    Grade = examDTO.Grade
                };
            }

            return null;
        }
    }
}
