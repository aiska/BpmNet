using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class ActivityStore : BaseStore<int, Activity>
    {
        public ActivityStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ActivityStore(BpmDbContext context) : base(context)
        {
        }
    }
}
