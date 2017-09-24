using BPMNET.Entity;
using BPMNET.Entity.Store;

namespace BPMNET.Engine.Manager.Int
{
    public class ProcessInstanceManager : ProcessInstanceManager<int, ProcessInstanceStore, ProcessInstanceEntity, FlowNodeEntity>
    {
        #region Constructor
        public ProcessInstanceManager(ProcessInstanceStore processInstanceStore) : base(processInstanceStore)
        {
        }
        #endregion
    }
}
