using Microsoft.EntityFrameworkCore;

namespace BPMNET.EntityCore
{
    public class BpmnProcessStore : BaseElementStore<BpmnProcess>
    {
        #region Constructor ...
        public BpmnProcessStore(DbContext context) : base(context) { }

        public BpmnProcessStore() : base() { }
        #endregion
    }
}
