using ExamApp.DataAccess.Abstractions;
using ExamApp.Extensions.Mappings.DTOs;
using ExamApp.Extensions.Mappings.Entities;
using ExamApp.Services.Abstractions;
using ExamApp.Services.DTOs;
using System.Linq.Expressions;

namespace ExamApp.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task AddAsync(LessonDTO dto)
        {
            _lessonRepository.Create(dto.ToEntity());

            await _lessonRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LessonDTO>> GetAllAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync();

            return lessons.ToDTOEnumarable();
        }

        public Task<IEnumerable<LessonDTO>> GetAllAsync(Func<bool, LessonDTO> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LessonDTO>> GetAllAsync(Expression<Func<bool, LessonDTO>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<LessonDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(LessonDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}