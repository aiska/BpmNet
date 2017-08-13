using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.IntKey
{
    public class ProcessDefinitionStore : ProcessDefinitionStore<int, ProcessDefinition>
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
