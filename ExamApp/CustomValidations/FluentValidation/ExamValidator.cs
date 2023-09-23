using ExamApp.DataAccess;
using ExamApp.DataAccess.Abstractions;
using ExamApp.DataAccess.Entities.Abstractions;
using ExamApp.Services.DTOs;
using FluentValidation;

namespace ExamApp.CustomValidations.FluentValidation
{
    public class ExamValidator : AbstractValidator<ExamDTO>
    {
        private readonly IExamRepository _examRepository;
        public ExamValidator(IExamRepository examRepository)
        {
            _examRepository = examRepository;

            RuleFor(x => x.LessonCode)
                .Length(1, 3).WithMessage("Dərs kodu 3 hərfdən ibarət ola bilər.");

            RuleFor(x => x.StudentNumber).Must(IsUpTo5Digit).WithMessage("Şagirdin nömrəsi maksimum 5 rəqəmli ola bilər.");

            RuleFor(x => x).Must(x => !DoesExistDuplicate(x.LessonCode, x.StudentNumber))
                                      .WithMessage("Bu imtahan artıq sistemdə mövcuddur.");

            RuleFor(x => x.Grade).Must(Is2digit).WithMessage("Qiymət yalnız 0-9 aralığında ola bilər.");
        }

        private bool IsUpTo5Digit(int studentNumber)
        {
            if (studentNumber > 0 && studentNumber <= 99999)
                return true;

            return false;
        }

        private bool Is2digit(int grade)
        {
            if (grade >= 0 && grade <= 9)
                return true;

            return false;
        }

        private bool DoesExistDuplicate(string lessonCode, int studentNumber)
        {
            var allExamEntities = _examRepository.GetAllAsync();

            var count = allExamEntities.Result
                .Count(x => x.LessonCode == lessonCode && x.StudentNumber == studentNumber);

            return count > 0 ? true : false;
        }
    }
}