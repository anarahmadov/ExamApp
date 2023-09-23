using ExamApp.DataAccess.Abstractions;
using ExamApp.Services.DTOs;
using FluentValidation;

namespace ExamApp.CustomValidations.FluentValidation
{
    public class LessonValidator : AbstractValidator<LessonDTO>
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonValidator(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;

            RuleFor(x => x.LessonCode)
                .Length(1, 3).WithMessage("Dərs kodu 3 hərfdən ibarət ola bilər.")
                .MustAsync(IsUniqueLessonCode).WithMessage("{PropertyValue} kodda dərs artıq sistemdə mövcuddur.");

            RuleFor(x => x.LessonName).Length(1, 30).WithMessage("Dərsin adı maksimum 30 simvoldan ibarət ola bilər.");

            RuleFor(x => x.ClassNumber).Must(IsUpTo2Digit).WithMessage("Sinif nömrəsi maksimum 2 simvoldan ibarət ola bilər.");

            RuleFor(x => x.TeacherName).Length(1, 20).WithMessage("Müəllimin adı maksimum 20 simvoldan ibarət ola bilər");

            RuleFor(x => x.TeacherSurname).Length(1, 20).WithMessage("Müəllimin soyadı maksimum 20 simvoldan ibarət ola bilər");
        }

        private async Task<bool> IsUniqueLessonCode(string lessonCode, CancellationToken token)
        {
            var lesson = await _lessonRepository.GetAllAsync();

            if (!lesson.Any(l => l.LessonCode == lessonCode))
                return await Task.FromResult(true);

            return await Task.FromResult(false);
        }

        private bool IsUpTo2Digit(int classNumber)
        {
            if (classNumber > 0 && classNumber <= 99)
                return true;

            return false;
        }
    }
}