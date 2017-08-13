using BPMNET.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessVariablesStore<TKey> : IDisposable
        where TKey : IEquatable<TKey>
    {
        private EntityStore<ProcessVariables<TKey>> _variableStore;
        public DbContext Context { get; private set; }
        protected bool DisposeContext { private get; set; }
        public ProcessVariablesStore(DbContext context)
        {
            Check.ThrowIfNull(context);
            Context = context;
            _variableStore = new EntityStore<ProcessVariables<TKey>>(context);
        }

        public IQueryable<ProcessVariables<TKey>> Entities
        {
            get { return _variableStore.EntitySet; }
        }


        public Task<ProcessVariables<TKey>> FindByIdAsync(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            id.ThrowIfNull();
            return _variableStore.GetByIdAsync(id);
        }

        public ProcessVariables<TKey> FindById(TKey TaskId)
        {
            this.ThrowIfDisposed(_disposed);
            TaskId.ThrowIfNull();
            return _variableStore.GetById(TaskId);
        }

        public Task<ProcessVariables<TKey>> FindByProcessInstanceIdAsync(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            processInstanceId.ThrowIfNull();
            return _variableStore.EntitySet.FirstOrDefaultAsync((ProcessVariables<TKey> t) => t.ProcessInstanceId.Equals(processInstanceId));
        }

        public ProcessVariables<TKey> FindByProcessInstanceId(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            processInstanceId.ThrowIfNull();
            return _variableStore.EntitySet.FirstOrDefault((ProcessVariables<TKey> t) => t.ProcessInstanceId.Equals(processInstanceId));
        }

        public virtual async Task CreateAsync(ProcessVariables<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Create(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(ProcessVariables<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Update(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(ProcessVariables<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Update(item);
            SaveChanges();
        }

        public virtual async Task DeleteAsync(ProcessVariables<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Delete(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Delete(ProcessVariables<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Delete(item);
            SaveChanges();
        }

        public void Create(ProcessVariables<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Create(item);
            SaveChanges();
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
                    //TODO set maximum attemp to prefend infinite loop
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposed = true;
            Context = null;
            _variableStore = null;
        }
        #endregion
    }
}
