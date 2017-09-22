using BPMNET.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public abstract class BaseStore<TKey, TEntity> : IStore<TEntity>, IFindById<TKey, TEntity>, IDisposable
        where TKey : IEquatable<TKey>
        where TEntity : class
    {
        private string prefixKey;

        protected DbContext Context { get; private set; }

        protected EntityStore<TEntity> Store { get; private set; }

        protected bool _disposed;
        protected bool DisposeContext { get; set; }

        #region Constructor ...
        public BaseStore(DbContext context)
        {
            context.ThrowIfNull();
            Context = context;
            prefixKey = typeof(TEntity).Name;
            Store = new EntityStore<TEntity>(context);
        }
        #endregion

        public IQueryable<TEntity> Entities
        {
            get { return Store.EntitySet; }
        }

        #region Async Store
        public virtual async Task<TEntity> FindByIdAsync(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            id.ThrowIfNull();
            TEntity result;
            //get from cache
            string key = prefixKey + id.ToString();
            result = await Store.GetByIdAsync(id);
            return result;
        }

        public virtual async Task CreateAsync(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            if (item is ITimeTrail)
                ((ITimeTrail)item).UtcCreatedDate = DateTime.UtcNow;
            Store.Create(item);
            await SaveChangesAsync();
            //TODO add to cache
            //Cache.Add(key, result);
        }

        public virtual async Task UpdateAsync(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            if (item is ITimeTrail)
                ((ITimeTrail)item).UtcModifiedDate = DateTime.UtcNow;
            Store.Update(item);
            await SaveChangesAsync();
            //TODO update to cache
            //Cache.Set(key, result);
        }
        public virtual async Task DeleteAsync(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Store.Delete(item);
            await SaveChangesAsync();
            //TODO remove from cache
            //Cache.Remove(key, result);
        }
        #endregion

        protected virtual async Task SaveChangesAsync()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
                catch (DbEntityValidationException vex)
                {
                    StringBuilder sb = new StringBuilder();
                    // Retrieve the error messages as a list of strings.
                    sb.AppendLine(vex.Message);
                    var errorMessages = vex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    sb.AppendLine("The validation errors are:");
                    foreach (var item in vex.EntityValidationErrors)
                    {
                        sb.AppendLine("entities : " + item.Entry.Entity.GetType().FullName);
                        foreach (var error in item.ValidationErrors)
                        {
                            sb.AppendLine(error.PropertyName + " : " + error.ErrorMessage);
                        }
                    }


                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(sb.ToString());

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, vex.EntityValidationErrors);
                }

            } while (saveFailed);
        }


        #region Dispose ...
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposed = true;
        }
        #endregion
    }
}
