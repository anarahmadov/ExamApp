using ExamApp.DataAccess.Abstractions;
using ExamApp.DataAccess.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExamApp.DataAccess
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly ExamAppDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ExamAppDBContext examAppDBContext)
        {
            _dbContext = examAppDBContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            T? existing = _dbSet.Find(id);

            if (existing is not null)
                _dbSet.Remove(existing);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> list = await _dbSet.ToListAsync();

            return list.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<bool, T> filter)
        {
            List<T> list = await _dbSet.ToListAsync();

            return list.AsEnumerable();
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<bool, T>> predicate)
        {
            List<T> list = await _dbSet.ToListAsync();

            return list.AsQueryable();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            T? entity = await _dbSet.FindAsync(id);

            return entity ?? new T();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}