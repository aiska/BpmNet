using Microsoft.EntityFrameworkCore;

namespace BPMNET.EntityCore
{
    public class BpmnFlowNodeStore : BaseElementStore<BpmnFlowNode>
    {
        #region Constructor ...
        public BpmnFlowNodeStore(DbContext context) : base(context) { }

        public BpmnFlowNodeStore() : base() { }
        #endregion
    }
}
