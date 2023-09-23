using ExamApp.Models.ViewModels;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.ViewModels
{
    public static class RegisterStudentViewModelExtensions
    {
        public static StudentDTO ToDTO(this RegisterStudentViewModel viewModel)
        {
            if (viewModel is not null)
            {
                return new StudentDTO()
                {
                    StudentNumber = viewModel.StudentNumber,
                    StudentName = viewModel.StudentName,
                    StudentSurname = viewModel.StudentSurname,
                    ClassNumber = viewModel.ClassNumber
                };
            }

            return null;
        }
    }
}
