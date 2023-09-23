using ExamApp.Services.DTOs.Abstractions;

namespace ExamApp.Services.DTOs
{
    public class ExamDTO : IDTO
    {
        public int ID { get; set; }

        public string LessonCode { get; set; } = string.Empty;
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }
    }
}
