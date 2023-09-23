using ExamApp.DataAccess.Abstractions;
using ExamApp.DataAccess.Entities;

namespace ExamApp.DataAccess
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository 
    {
        private readonly ExamAppDBContext _examAppDBContext;
        public ExamRepository(ExamAppDBContext examAppDBContext) : base(examAppDBContext) 
        {
            _examAppDBContext = examAppDBContext;
        }
    }
}