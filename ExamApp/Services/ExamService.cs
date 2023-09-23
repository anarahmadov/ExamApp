using ExamApp.DataAccess.Abstractions;
using ExamApp.Extensions.Mappings.DTOs;
using ExamApp.Services.Abstractions;
using ExamApp.Services.DTOs;
using System.Linq.Expressions;

namespace ExamApp.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task AddAsync(ExamDTO dto)
        {
            _examRepository.Create(dto.ToEntity());

            await _examRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetAllAsync(Func<bool, ExamDTO> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetAllAsync(Expression<Func<bool, ExamDTO>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ExamDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ExamDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
