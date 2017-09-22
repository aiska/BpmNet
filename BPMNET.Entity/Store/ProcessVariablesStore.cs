using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class ProcessVariablesStore : BaseStore<int, ProcessVariableEntity>
    {
        public ProcessVariablesStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }

        public ProcessVariablesStore(BpmDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProcessVariableEntity>> GetAllVariableAsync(int processInstanceId)
        {
            return await Entities.Where(t => t.ProcessInstanceId.Equals(processInstanceId)).ToListAsync();
        }

        public async Task<ProcessVariableEntity> GetVariableByNameAsync(int processInstanceId, string name) 
        {
            return await Entities.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.Name.Equals(name));
        }

        public IEnumerable<ProcessVariableEntity> GetAllVariable(int processInstanceId)
        {
            return Entities.Where(t => t.ProcessInstanceId.Equals(processInstanceId)).AsEnumerable();
        }
    }
}
