using ExamApp.DataAccess.Entities.Abstractions;
using System.Linq.Expressions;

namespace ExamApp.DataAccess.Abstractions
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);

        Task<T> GetByIDAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Func<bool, T> filter);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<bool, T>> predicate);

        Task<bool> SaveChangesAsync();
    }
}