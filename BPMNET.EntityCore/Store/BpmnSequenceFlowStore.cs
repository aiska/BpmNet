using Microsoft.EntityFrameworkCore;

namespace BPMNET.EntityCore
{
    public class BpmnSequenceFlowStore : BaseElementStore<BpmnSequenceFlow>
    {
        #region Constructor ...
        public BpmnSequenceFlowStore(DbContext context) : base(context) { }

        public BpmnSequenceFlowStore() : base() { }
        #endregion
    }
}
