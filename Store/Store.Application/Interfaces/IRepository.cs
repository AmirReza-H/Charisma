using Store.Domain.Common;
using System.Linq.Expressions;

namespace Store.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] include);


        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
