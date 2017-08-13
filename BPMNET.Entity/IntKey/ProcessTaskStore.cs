using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.IntKey
{
    public class ProcessTaskStore : ProcessTaskStore<int, ProcessTask>
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
