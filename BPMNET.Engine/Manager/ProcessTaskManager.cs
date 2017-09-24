using BPMNET.Bpmn;
using BPMNET.Core;
using System;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager
{
    public class ProcessTaskManager<TKey, TProcessTaskStore, TProcessTask> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessTaskStore : class, IProcessTaskStore<TKey, TProcessTask>
        where TProcessTask : class, IProcessTask<TKey>
    {
        protected TProcessTaskStore Store { get; private set; }

        #region Constructor
        public ProcessTaskManager(TProcessTaskStore store)
        {
            Store = store;
        }
        #endregion

        #region Dispose
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
                Store.Dispose();
            }
            _disposed = true;
        }
        #endregion

        #region SubRoutine

        public async Task<TProcessTask[]> GetProcessTaskByFlowNodeIdAsync(string name)
        {
            return await Store.GetProcessTaskByFlowNodeIdAsync(name);
        }

        public async Task<TProcessTask> CreateTaskAsync(TKey processInstanceId, TKey nodeId, string nodeName, ProcessItemType ItemType)
        {
            return await Store.CreateTaskAsync(processInstanceId, nodeId, nodeName, ItemType);
        }

        #endregion


    }
}
