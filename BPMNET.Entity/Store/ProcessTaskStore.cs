using BPMNET.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BPMNET.Entity.Store
{
    public class ProcessTaskStore : BaseStore<int, ProcessTaskEntity>
    {
        private readonly IDbSet<ProcessInstanceEntity> _processInstanceSet;
        public ProcessTaskStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }

        public async Task<ProcessTaskEntity> GetProcessTaskAsync(int processInstanceId, string taskName)
        {
            return await Entities.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.Name.Equals(taskName));
        }

        public ProcessTaskStore(BpmDbContext context) : base(context)
        {
            _processInstanceSet = context.Set<ProcessInstanceEntity>();
        }

        public async Task<IEnumerable<ProcessTaskEntity>> GetActiveProcessTaskAsync(int processInstanceId)
        {
            return await Store.EntitySet.Where(t => t.ProcessInstanceId.Equals(processInstanceId) && !t.IsDone).ToListAsync();
        }

        public async Task<ProcessTaskEntity> GetCurrentProcessTaskByName(int processInstanceId, string taskName)
        {
            taskName.ThrowIfNull();
            return await Store.EntitySet.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.Name.Equals(taskName));
        }

        public async Task<IEnumerable<ProcessTaskEntity>> GetAllProcessInstanceAsync(string taskName)
        {
            taskName.ThrowIfNull();
            return await Entities.Where(t => t.Name.Equals(taskName)).ToListAsync();
        }

        public ProcessTaskEntity GetProcessTaskByFlowProcess(int flowNodeId, int processInstanceId)
        {
            return Entities.FirstOrDefault(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowNodeId.Equals(flowNodeId));
        }

        public async Task<bool> IsTaskDoneAsync(int flowNodeId, int processInstanceId)
        {
            return await Entities.Where(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowNodeId.Equals(flowNodeId)).Select(t => t.IsDone).SingleAsync();
        }

    }
}
