using ExamApp.DataAccess.Entities.Abstractions;

namespace ExamApp.DataAccess.Entities
{
    public class Student : IEntity
    {
        public int ID { get; set; }

        public int StudentNumber { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string StudentSurname { get; set; } = string.Empty;

        public int ClassNumber { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}