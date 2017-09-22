using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class SequenceFlowStore : BaseStore<int, SequenceFlowEntity>
    {
        public SequenceFlowStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }

        public SequenceFlowStore(BpmDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SequenceFlowEntity>> GetNextSequenceFlowAsync(int sourceRef)
        {
            return await Entities.Where(t => t.SourceRef.Equals(sourceRef)).ToListAsync();
        }

        public IEnumerable<SequenceFlowEntity> GetNextSequenceFlow(int sourceRef)
        {
            return Entities.Where(t => t.SourceRef.Equals(sourceRef)).AsEnumerable();
        }
    }
}
