using ExamApp.Models.ViewModels;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.ViewModels
{
    public static class RegisterLessonViewModelExtensions
    {
        public static LessonDTO ToDTO(this RegisterLessonViewModel viewModel)
        {
            if (viewModel is not null)
            {
                return new LessonDTO()
                {
                    LessonCode = viewModel.LessonCode,
                    LessonName = viewModel.LessonName,
                    ClassNumber = viewModel.ClassNumber,
                    TeacherName = viewModel.TeacherName,
                    TeacherSurname = viewModel.TeacherSurname
                };
            }

            return null;
        }
    }
}
