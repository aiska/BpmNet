using BPMNET.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class DefinitionVariableStore<TKey> : IDisposable
        where TKey : IEquatable<TKey>
    {
        private EntityStore<DefinitionVariable<TKey>> _variableStore;
        public DbContext Context { get; private set; }
        protected bool DisposeContext { private get; set; }
        public DefinitionVariableStore(DbContext context)
        {
            context.ThrowIfNull();
            Context = context;
            _variableStore = new EntityStore<DefinitionVariable<TKey>>(context);
        }

        public IQueryable<DefinitionVariable<TKey>> Entities
        {
            get { return _variableStore.EntitySet; }
        }


        public Task<DefinitionVariable<TKey>> FindByIdAsync(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            id.ThrowIfNull();
            return _variableStore.GetByIdAsync(id);
        }

        public DefinitionVariable<TKey> FindById(TKey TaskId)
        {
            this.ThrowIfDisposed(_disposed);
            TaskId.ThrowIfNull();
            return _variableStore.GetById(TaskId);
        }

        public Task<DefinitionVariable<TKey>> FindByProcessDefinitionIdAsync(TKey processDefinition)
        {
            this.ThrowIfDisposed(_disposed);
            processDefinition.ThrowIfNull();
            return _variableStore.EntitySet.FirstOrDefaultAsync((DefinitionVariable<TKey> t) => t.ProcessDefinitionId.Equals(processDefinition));
        }

        public DefinitionVariable<TKey> FindByProcessDefinitionId(TKey processDefinition)
        {
            this.ThrowIfDisposed(_disposed);
            processDefinition.ThrowIfNull();
            return _variableStore.EntitySet.FirstOrDefault((DefinitionVariable<TKey> t) => t.ProcessDefinitionId.Equals(processDefinition));
        }

        public virtual async Task CreateAsync(DefinitionVariable<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Create(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(DefinitionVariable<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Update(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(DefinitionVariable<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Update(item);
            SaveChanges();
        }

        public virtual async Task DeleteAsync(DefinitionVariable<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Delete(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Delete(DefinitionVariable<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Delete(item);
            SaveChanges();
        }

        public void Create(DefinitionVariable<TKey> item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            _variableStore.Create(item);
            SaveChanges();
        }

        public virtual async Task<DefinitionVariable<TKey>> FindByProcessDefinitionIdAndNameAsync(TKey processDefinitionId, string variableName)
        {
            this.ThrowIfDisposed(_disposed);
            processDefinitionId.ThrowIfNull();
            variableName.ThrowIfNull();
            return await _variableStore.EntitySet.FirstOrDefaultAsync(t => t.ProcessDefinitionId.Equals(processDefinitionId) && t.VariableName.Equals(variableName)).ConfigureAwait(false);
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
