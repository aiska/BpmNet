using Microsoft.EntityFrameworkCore;

namespace BPMNET.EntityCore
{
    public class BpmnItemDefinitionStore : BaseElementStore<BpmnItemDefinition>
    {
        #region Constructor ...
        public BpmnItemDefinitionStore(DbContext context) : base(context) { }

        public BpmnItemDefinitionStore() : base() { }
        #endregion
    }
}
