using ExamApp.DataAccess;
using ExamApp.DataAccess.Abstractions;
using ExamApp.DataAccess.Entities;
using ExamApp.Services.DTOs;
using FluentValidation;

namespace ExamApp.CustomValidations.FluentValidation
{
    public class StudentValidator : AbstractValidator<StudentDTO>
    {
        private readonly IStudentRepository _studentRepository;
        public StudentValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

            RuleFor(x => x.StudentNumber).Must(IsUpTo5Digit).WithMessage("Şagirdin nömrəsi maksimum 5 rəqəmli ola bilər.");
            RuleFor(x => x.StudentNumber).MustAsync(IsUniqueStudentNumber).WithMessage("Bu nömrəli şagird artıq sistemdə mövcuddur.");

            RuleFor(x => x.StudentName).Length(1, 30).WithMessage("Şagirdin adı maksimum 30 simvoldan ibarət ola bilər.");

            RuleFor(x => x.StudentSurname).Length(1, 30).WithMessage("Şagirdin soyadı maksimum 30 simvoldan ibarət ola bilər.");

            RuleFor(x => x.ClassNumber).Must(IsUpTo2Digit).WithMessage("Sinif nömrəsi maksimum 2 simvoldan ibarət ola bilər.");
        }

        private async Task<bool> IsUniqueStudentNumber(int studentNumber, CancellationToken token)
        {
            var student = await _studentRepository.GetAllAsync();

            if (!student.Any(l => l.StudentNumber == studentNumber))
                return await Task.FromResult(true);

            return await Task.FromResult(false);
        }

        private bool IsUpTo2Digit(int classNumber)
        {
            if (classNumber > 0 && classNumber <= 99)
                return true;

            return false;
        }

        private bool IsUpTo5Digit(int studentNumber)
        {
            if (studentNumber > 0 && studentNumber <= 99999)
                return true;

            return false;
        }
    }
}