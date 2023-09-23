using ExamApp.DataAccess;
using ExamApp.DataAccess.Abstractions;
using ExamApp.Extensions.Mappings.DTOs;
using ExamApp.Extensions.Mappings.Entities;
using ExamApp.Services.Abstractions;
using ExamApp.Services.DTOs;
using System.Linq.Expressions;

namespace ExamApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddAsync(StudentDTO dto)
        {
            _studentRepository.Create(dto.ToEntity());

            await _studentRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students.ToDTOEnumarable();
        }

        public Task<IEnumerable<StudentDTO>> GetAllAsync(Func<bool, StudentDTO> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDTO>> GetAllAsync(Expression<Func<bool, StudentDTO>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StudentDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
