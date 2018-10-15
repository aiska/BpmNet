using BpmNet.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.EntityFrameworkCore.Stores
{
    public abstract class BaseStore<TContext, TKey, TEntity> : IStore<TKey, TEntity>
        where TContext : DbContext
        where TKey : IEquatable<TKey>
        where TEntity : class
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> Entities => Context.Set<TEntity>();

        public BaseStore(TContext context)
        {
            Context = context;
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Add(entity);
            Context.SaveChanges();
        }

        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Add(entity);
            try
            {
                await Context.SaveChangesAsync(cancellationToken);
            }

            catch (DbUpdateConcurrencyException exception)
            {
                throw new BpmNetException(BpmNetConstants.Exceptions.ConcurrencyError, new StringBuilder()
                    .AppendLine("The application was concurrently updated and cannot be persisted in its current state.")
                    .Append("Reload the application from the database and retry the operation.")
                    .ToString(), exception);
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Context.Remove(entity);
            try
            {
                await Context.SaveChangesAsync(cancellationToken);
            }

            catch (DbUpdateConcurrencyException exception)
            {
                throw new BpmNetException(BpmNetConstants.Exceptions.ConcurrencyError, new StringBuilder()
                    .AppendLine("The application was concurrently updated and cannot be persisted in its current state.")
                    .Append("Reload the application from the database and retry the operation.")
                    .ToString(), exception);
            }
        }

        public void DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public TEntity FindById(TKey id)
        {
            return Entities.Find(id);
        }

        public Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            return Entities.FindAsync(id);
        }

        public bool IsExists(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Any(predicate);
        }

        public Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return Entities.AnyAsync(predicate, cancellationToken);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Attach(entity);
            Context.Update(entity);

            try
            {
                await Context.SaveChangesAsync(cancellationToken);
            }

            catch (DbUpdateConcurrencyException exception)
            {
                throw new BpmNetException(BpmNetConstants.Exceptions.ConcurrencyError, new StringBuilder()
                    .AppendLine("The definition was concurrently updated and cannot be persisted in its current state.")
                    .Append("Reload the application from the database and retry the operation.")
                    .ToString(), exception);
            }
        }

        public void UpdateAsync(TEntity entity)
        {
            Context.Attach(entity);
            Context.Update(entity);
            Context.SaveChanges();
        }
    }
}
