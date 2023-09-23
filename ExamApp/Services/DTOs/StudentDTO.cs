using ExamApp.Services.DTOs.Abstractions;

namespace ExamApp.Services.DTOs
{
    public class StudentDTO : IDTO
    {
        public int ID { get; set; }

        public int StudentNumber { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentSurname { get; set; } = string.Empty;
        public int ClassNumber { get; set; }
    }
}
