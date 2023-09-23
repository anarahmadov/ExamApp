using ExamApp.DataAccess.Entities.Abstractions;
using System.Reflection.PortableExecutable;

namespace ExamApp.DataAccess.Entities
{
    public class Exam : IEntity
    {
        public int ID { get; set; }

        public string LessonCode { get; set; } = string.Empty;
        public Lesson? Lesson { get; set; }

        public int StudentNumber { get; set; }
        public Student? Student { get; set; }

        public DateTime ExamDate { get; set; }

        public int Grade { get; set; }
    }
}