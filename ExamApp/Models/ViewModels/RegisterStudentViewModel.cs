namespace ExamApp.Models.ViewModels
{
    public class RegisterStudentViewModel
    {
        public int StudentNumber { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentSurname { get; set; } = string.Empty;
        public int ClassNumber { get; set; }
    }
}
