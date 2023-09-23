using ExamApp.DataAccess.Abstractions;
using ExamApp.Extensions.Mappings.ViewModels;
using ExamApp.Models.ViewModels;
using ExamApp.Services.Abstractions;
using ExamApp.Services.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExamApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IValidator<LessonDTO> _lessonValidator;
        public LessonController(ILessonService lessonService, IValidator<LessonDTO> lessonValidator)
        {
            _lessonService = lessonService;
            _lessonValidator = lessonValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterLesson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterLesson(RegisterLessonViewModel registerLessonViewModel)
        {
            LessonDTO lessonDTO = registerLessonViewModel.ToDTO();

            ValidationResult validationResult = await _lessonValidator.ValidateAsync(lessonDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                // re-render the view when validation failed.
                return View("RegisterLesson", registerLessonViewModel);
            }

            await _lessonService.AddAsync(lessonDTO); // Save the lesson to the database, or some other logic

            return View(new RegisterLessonViewModel());
        }
    }
}