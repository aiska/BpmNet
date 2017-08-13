using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BPMNET.EntityCore
{
    public abstract class BaseStore<TEntity> : IStore<TEntity>, IFindById<Guid, TEntity>, IDisposable
        where TEntity : class
    {
        private const string CONTEXT = "context";

        protected DbContext Context { get; private set; }

        public DbSet<TEntity> Entities { get; private set; }

        protected bool _disposed;
        protected bool DisposeContext { private get; set; }

        #region Constructor ...
        public BaseStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(CONTEXT);
            }
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public BaseStore()
        {
            Context = new BpmDbContext();
            DisposeContext = true;
            Entities = Context.Set<TEntity>();
        }
        #endregion

        #region Store
        public abstract TEntity FindById(Guid Key);

        public abstract void Create(TEntity Item);
        public abstract void Update(TEntity Item);
        public abstract void Delete(TEntity Item);
        #endregion

        #region Async Store
        public abstract Task<TEntity> FindByIdAsync(Guid id);
        public abstract Task CreateAsync(TEntity item);
        public abstract Task UpdateAsync(TEntity item);
        public abstract Task DeleteAsync(TEntity item);
        #endregion

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
            Context = null;
            Entities = null;
        }
        #endregion
    }
}
