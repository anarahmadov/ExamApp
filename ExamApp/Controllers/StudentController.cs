using ExamApp.CustomValidations.FluentValidation;
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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<StudentDTO> _studentValidator;
        public StudentController(IStudentService studentService, IValidator<StudentDTO> studentValidator)
        {
            _studentService = studentService;
            _studentValidator = studentValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentViewModel registerStudentViewModel)
        {
            StudentDTO studentDto = registerStudentViewModel.ToDTO();

            ValidationResult validationResult = await _studentValidator.ValidateAsync(studentDto);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                // re-render the view when validation failed.
                return View("RegisterStudent", registerStudentViewModel);
            }

            await _studentService.AddAsync(studentDto); // Save the student to the database, or some other logic

            return View(new RegisterStudentViewModel());
        }
    }
}
