using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.GuidKey
{
    public class ProcessTaskStore : ProcessTaskStore<Guid, ProcessTask>
    {
        public ProcessTaskStore() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessTaskStore(BpmDbContext context) : base(context)
        {
        }
    }
}
