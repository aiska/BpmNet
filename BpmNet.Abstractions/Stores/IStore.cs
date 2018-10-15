using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Stores
{
    public interface IStore<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        void Create(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        TEntity FindById(TKey id);
        bool IsExists(Expression<Func<TEntity, bool>> predicate);
    }
}
