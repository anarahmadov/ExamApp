using ExamApp.Services.DTOs.Abstractions;
using System.Linq.Expressions;

namespace ExamApp.Services.Abstractions
{
    public interface IBaseService<T> where T : class, IDTO, new()
    {
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T dto);
        Task UpdateAsync(T dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Func<bool, T> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<bool, T>> predicate);
    }
}