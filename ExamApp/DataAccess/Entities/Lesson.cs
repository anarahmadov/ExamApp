using ExamApp.DataAccess.Entities.Abstractions;

namespace ExamApp.DataAccess.Entities
{
    public class Lesson : IEntity
    {
        public int ID { get; set; }

        public string LessonCode { get; set; } = string.Empty;

        public string LessonName { get; set; } = string.Empty;

        public int ClassNumber { get; set; }

        public string TeacherName { get; set; } = string.Empty;

        public string TeacherSurname { get; set; } = string.Empty;

        public ICollection<Exam> Exams { get; set; }
    }
}