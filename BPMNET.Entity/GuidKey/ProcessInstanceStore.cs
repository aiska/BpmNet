using System;

namespace BPMNET.Entity.GuidKey
{
    public class ProcessInstanceStore : ProcessInstanceStore<Guid, ProcessInstance>
    {
        public ProcessInstanceStore() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessInstanceStore(BpmDbContext context) : base(context) { }
    }
}
