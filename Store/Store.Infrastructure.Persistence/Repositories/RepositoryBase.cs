using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain.Common;
using Store.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace Store.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        public RepositoryBase(StoreDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => await _dbContext.Set<TEntity>().AnyAsync(predicate);
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().Where(predicate);
            foreach (var item in include)
            {
                query = query.Include(item);
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual void Add(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);
        public void AddRange(IEnumerable<TEntity> entities) => _dbContext.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => _dbContext.Set<TEntity>().RemoveRange(entities);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => _dbContext.Set<TEntity>().UpdateRange(entities);
    }
}
