using ExamApp.DataAccess.Abstractions;
using ExamApp.DataAccess.Entities;
using System.Drawing.Printing;

namespace ExamApp.DataAccess
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly ExamAppDBContext _examAppDBContext;
        public StudentRepository(ExamAppDBContext examAppDBContext) : base(examAppDBContext) 
        {
            _examAppDBContext = examAppDBContext;
        }
    }
}
