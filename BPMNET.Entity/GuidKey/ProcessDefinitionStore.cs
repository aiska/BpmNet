using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.GuidKey
{
    public class ProcessDefinitionStore : ProcessDefinitionStore<Guid, ProcessDefinition>
    {
        public ProcessDefinitionStore() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessDefinitionStore(DbContext context) : base(context)
        {

        }
    }
}
