using BPMNET.Core;
using BPMNET.Entity;
using BPMNET.Entity.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager.Int
{
    public class Instance : IInstance<int, Instance, InstanceTask>
    {
        #region Properties
        protected ProcessInstanceStore Store { get; private set; }
        public string BusinessKey { get; private set; }
        public int Id { get; private set; }
        public bool IsEnded { get; private set; }
        public bool IsSuspended { get; private set; }
        public int ProcessDefinitionId { get; private set; }
        public string ProcessId { get; private set; }
        public ProcessInstanceStatus Status { get; private set; }
        public string TenantId { get; private set; }
        #endregion

        public Instance(ProcessInstanceStore store, ProcessInstanceEntity entity)
        {
            Store = store;
            BusinessKey = entity.BusinessKey;
            Id = entity.Id;
            IsEnded = entity.IsEnded;
            IsSuspended = entity.IsSuspended;
            ProcessDefinitionId = entity.ProcessDefinitionId;
            ProcessId = entity.ProcessId;
            Status = entity.Status;
            TenantId = entity.TenantId;
        }

        public async Task ActivateAsync()
        {
            ProcessInstanceEntity entity = await Store.GetProcessInstanceAsync(Id);
            entity.IsSuspended = false;
        }

        public Task CancelInstanceAsync(string reason)
        {
            throw new NotImplementedException();
        }

        public async Task<Instance[]> GetAllSubProcess()
        {
            var subprocs = await Store.GetAllSubProcessAsync(Id);
            var result = new Instance[subprocs.Length];
            for (int i = 0; i < subprocs.Length; i++)
            {
                result[i] = new Instance(Store, subprocs[i]);
            }
            return result;
        }

        public Task<InstanceTask> GetCurrentTask()
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, object>> GetVariables()
        {
            throw new NotImplementedException();
        }

        public Task SuspendInstanceAsync(string reason)
        {
            throw new NotImplementedException();
        }
    }
}
