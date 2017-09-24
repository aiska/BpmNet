using BPMNET.Entity;
using BPMNET.Entity.Store;

namespace BPMNET.Engine.Manager
{
    public class ProcessTaskManager : ProcessTaskManager<int, ProcessTaskStore, ProcessTaskEntity>
    {
        #region Constructor
        public ProcessTaskManager(ProcessTaskStore store) : base(store)
        {
        }
        #endregion
    }
}
