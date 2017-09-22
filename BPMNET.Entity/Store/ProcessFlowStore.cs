using BPMNET.Core;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BPMNET.Entity.Store
{
    public class ProcessFlowStore : BaseStore<int, ProcessFlowEntity>, IProcessFlowStore<int, ProcessFlowEntity>
    {
        public ProcessFlowStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessFlowStore(BpmDbContext context) : base(context) { }

        public async Task<ProcessFlowEntity> GetProcessFlowAsync(int processInstanceId, int flowFrom, int flowTo)
        {
            return await Entities.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowFrom.Equals(flowFrom) && t.FlowTo.Equals(flowTo));
        }

        public async Task<bool> IsExistAsync(int processInstanceId, int flowFrom, int flowTo)
        {
            return await Entities.AnyAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowFrom.Equals(flowFrom) && t.FlowTo.Equals(flowTo));
        }
    }
}
