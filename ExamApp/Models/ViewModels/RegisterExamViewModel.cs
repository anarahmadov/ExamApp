using ExamApp.Services.DTOs;

namespace ExamApp.Models.ViewModels
{
    public class RegisterExamViewModel
    {
        public string LessonCode { get; set; } = string.Empty;
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }

        public IEnumerable<string> LessonCodes { get; set; } = new List<string>();
        public IEnumerable<int> StudentNumbers { get; set; } = new List<int>();
    }
}
