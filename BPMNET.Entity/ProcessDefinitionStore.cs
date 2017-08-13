using BPMNET.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessDefinitionStore : ProcessDefinitionStore<string, ProcessDefinition>
    {
        public ProcessDefinitionStore() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessDefinitionStore(DbContext context) : base(context)
        {

        }
    }
    public class ProcessDefinitionStore<TKey, TProcessDefinition> : IProcessDefinitionStore<TKey, TProcessDefinition>
    where TKey : IEquatable<TKey>
    where TProcessDefinition : class, IProcessDefinition<TKey>
    {
        private EntityStore<TProcessDefinition> _processDefinitionStore;
        private ProcessDefinitionCache<TKey, TProcessDefinition> cache;

        protected bool DisposeContext { private get; set; }
        protected DbContext Context { get; private set; }

        #region Constructor ...
        public ProcessDefinitionStore(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
            _processDefinitionStore = new EntityStore<TProcessDefinition>(context);
            cache = ProcessDefinitionCache<TKey, TProcessDefinition>.Instance;
        }
        #endregion

        public virtual IQueryable<TProcessDefinition> Entities
        {
            get { return _processDefinitionStore.EntitySet; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.Collect();
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (DisposeContext && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposed = true;
            Context = null;
            _processDefinitionStore = null;
        }

        public virtual Task<TProcessDefinition> FindByIdAsync(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            TProcessDefinition result = cache.GetById(id);
            if (result != null) return Task.FromResult(result);
            return _processDefinitionStore.GetByIdAsync(id);
        }

        public virtual TProcessDefinition FindById(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            TProcessDefinition result = cache.GetById(id);
            if (result != null) return result;
            return _processDefinitionStore.GetById(id);
        }

        public virtual async Task CreateAsync(TProcessDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processDefinitionStore.Create(item);
            await SaveChangesAsync().ConfigureAwait(false);
            cache.Add(item);
        }

        public virtual async Task UpdateAsync(TProcessDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processDefinitionStore.Update(item);
            await SaveChangesAsync().ConfigureAwait(false);
            cache.Set(item);
        }

        public virtual async Task DeleteAsync(TProcessDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processDefinitionStore.Delete(item);
            await SaveChangesAsync().ConfigureAwait(false);
            cache.Remove(item);
        }

        public virtual void Create(TProcessDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processDefinitionStore.Create(item);
            SaveChanges();
            cache.Add(item);
        }

        public virtual void Update(TProcessDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processDefinitionStore.Update(item);
            SaveChanges();
            cache.Set(item);
        }

        public virtual void Delete(TProcessDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processDefinitionStore.Delete(item);
            SaveChanges();
            cache.Remove(item);
        }
        private void SaveChanges()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    Context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        private async Task SaveChangesAsync()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await Context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }
    }
}
