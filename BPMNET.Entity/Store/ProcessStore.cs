using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class ProcessStore : BaseStore<int, ProcessDefinitionEntity>
    {
        public ProcessStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessStore(BpmDbContext context) : base(context) { }

        public async Task<IEnumerable<int>> SuspendProcessAsync(IEnumerable<int> definitionIds)
        {
            this.ThrowIfDisposed(_disposed);
            var entries = Entities.Where(t => definitionIds.Contains(t.DeploymentId));
            await entries.ForEachAsync(a =>
            {
                a.IsSuspended = true;
                a.UtcModifiedDate = DateTime.UtcNow;
            });
            await SaveChangesAsync();
            return entries.Select(t => t.Id);
        }

        public async Task<ProcessDefinitionEntity> FindByBpmnIdAsync(string id)
        {
            this.ThrowIfDisposed(_disposed);
            id.ThrowIfNull();
            return await Store.EntitySet.FirstOrDefaultAsync(t => t.ProcessId.Equals(id) && !t.IsSuspended);
        }

        public async Task<ProcessDefinitionEntity> GetByFlowIdAsync(int flowNodeId)
        {
            return await Entities.FirstOrDefaultAsync(t => t.FlowNodeId.Equals(flowNodeId));
        }
    }
}
