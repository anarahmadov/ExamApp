using ExamApp.CustomValidations.FluentValidation;
using ExamApp.DataAccess.Abstractions;
using ExamApp.Extensions.Mappings.ViewModels;
using ExamApp.Models.ViewModels;
using ExamApp.Services;
using ExamApp.Services.Abstractions;
using ExamApp.Services.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly ILessonService _lessonService;
        private readonly IStudentService _studentService;
        private readonly IValidator<ExamDTO> _examValidator;
        public ExamController(IExamService examService, IValidator<ExamDTO> examValidator, 
            ILessonService lessonService, IStudentService studentService)
        {
            _examService = examService;
            _examValidator = examValidator;
            _lessonService = lessonService;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterExam()
        {
            RegisterExamViewModel registerExamViewModel = new();

            IEnumerable<LessonDTO> lessonDTOs = await _lessonService.GetAllAsync();
            IEnumerable<StudentDTO> studentDTOs = await _studentService.GetAllAsync();

            registerExamViewModel.LessonCodes = lessonDTOs.Select(lt => lt.LessonCode);
            registerExamViewModel.StudentNumbers = studentDTOs.Select(sn => sn.StudentNumber);

            return View(registerExamViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterExam(RegisterExamViewModel registerExamViewModel)
        {
            ExamDTO examDTO = registerExamViewModel.ToDTO();

            ValidationResult validationResult = await _examValidator.ValidateAsync(examDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                // re-render the view when validation failed.
                return View("RegisterExam", registerExamViewModel);
            }

            await _examService.AddAsync(examDTO); // Save the exam to the database, or some other logic

            return View(new RegisterExamViewModel() { LessonCodes = registerExamViewModel.LessonCodes, StudentNumbers = registerExamViewModel.StudentNumbers }); 
        }
    }
}