using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class DeploymentManager<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition> : IDisposable
        where TKey : IEquatable<TKey>
        where TDeployment : class, IDeployment<TKey>
        where TProcessDefinition : class, IProcessDefinition<TKey>
        where TProcessItemDefinition : class, IProcessItemDefinition<TKey>

    {
        protected DbContext Context { get; private set; }
        protected bool DisposeContext { private get; set; }
        private IDeploymentValidator<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition> _deploymentValidator;
        public IDeploymentValidator<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition> DeploymentValidator
        {
            get
            {
                return _deploymentValidator;
            }
            set
            {
                Check.ThrowIfNull(value);
                _deploymentValidator = value;
            }
        }
        #region Dispose ...
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (DisposeContext && Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
                //DefinitionStore.Dispose();
                //InstanceStore.Dispose();
            }
            _disposed = true;
        }
        #endregion
    }
}
