using Microsoft.EntityFrameworkCore;

namespace BPMNET.EntityCore.Store
{
    public class BpmnDefinitionStore : BaseElementStore<BpmnDefinition>
    {
        #region Constructor ...
        public BpmnDefinitionStore(DbContext context) : base(context) { }

        public BpmnDefinitionStore() : base() { }
        #endregion
    }
}
