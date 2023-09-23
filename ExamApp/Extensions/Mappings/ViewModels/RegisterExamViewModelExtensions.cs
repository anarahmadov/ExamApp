using ExamApp.Models.ViewModels;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.ViewModels
{
    public static class RegisterExamViewModelExtensions
    {
        public static ExamDTO ToDTO(this RegisterExamViewModel viewModel)
        {
            if (viewModel is not null)
            {
                return new ExamDTO()
                {
                    LessonCode = viewModel.LessonCode,
                    StudentNumber = viewModel.StudentNumber,
                    ExamDate = viewModel.ExamDate,
                    Grade = viewModel.Grade
                };
            }

            return null;
        }
    }
}