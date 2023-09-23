using ExamApp.DataAccess.Abstractions;
using ExamApp.DataAccess.Entities;

namespace ExamApp.DataAccess
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        private readonly ExamAppDBContext _examAppDBContext;
        public LessonRepository(ExamAppDBContext examAppDBContext) : base(examAppDBContext)
        {
            _examAppDBContext = examAppDBContext;
        }

    }
}
