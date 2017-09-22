using BPMNET.Bpmn;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;
using BPMNET.Engine.Entity;

namespace BPMNET.Entity.Store
{
    public class FlowNodeStore : BaseStore<int, FlowNodeEntity>
    {
        private readonly IDbSet<SequenceFlowEntity> SequenceFlow;

        public FlowNodeStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public FlowNodeStore(BpmDbContext context) : base(context)
        {
            SequenceFlow = context.Set<SequenceFlowEntity>();
        }

        public async Task<IEnumerable<FlowNodeEntity>> GetStartEvent(int parentId)
        {
            return await Entities.Where(t => t.ParentId.Value.Equals(parentId) && t.ItemType == ProcessItemType.StartEvent).ToListAsync();
        }

        public async Task<IFlowNode[]> GetPreviousFlowAsync(int flowNodeId)
        {
            IQueryable<IFlowNode> queryable =
                from fn in Store.DbEntitySet
                join sf in SequenceFlow on fn.Id equals sf.SourceRef
                where sf.ItemSourceTarget.Equals(flowNodeId)
                select fn as IFlowNode;
            return await queryable.ToArrayAsync();
        }
        public IEnumerable<FlowNodeEntity> GetPreviousFlow(int flowNodeId)
        {
            IQueryable<FlowNodeEntity> queryable =
                from fn in Store.DbEntitySet
                join sf in SequenceFlow on fn.FlowNodeId equals sf.SourceRef
                where sf.TargetRef.Equals(flowNodeId)
                select fn;
            return queryable.AsEnumerable();
        }

        public async Task<IEnumerable<FlowNodeEntity>> GetNextFlowAsync(int flowNodeId)
        {
            IQueryable<FlowNodeEntity> queryable =
                from fn in Store.DbEntitySet
                join sf in SequenceFlow on fn.FlowNodeId equals sf.TargetRef
                where sf.SourceRef.Equals(flowNodeId)
                select fn;
            return await queryable.ToListAsync();
        }

        //public async Task<FlowNode> GetNextFlowFirstOrDefaultAsync(int flowNodeId)
        //{
        //    IQueryable<FlowNode> queryable =
        //        from fn in Store.DbEntitySet
        //        join sf in SequenceFlow on fn.FlowNodeId equals sf.ItemSourceTarget
        //        where sf.ItemSourceRef.Equals(flowNodeId)
        //        select fn;
        //    return await queryable.FirstOrDefaultAsync();
        //}

        //public FlowNode GetNextFlowFirstOrDefault(int flowNodeId)
        //{
        //    IQueryable<FlowNode> queryable =
        //        from fn in Store.DbEntitySet
        //        join sf in SequenceFlow on fn.FlowNodeId equals sf.ItemSourceTarget
        //        where sf.ItemSourceRef.Equals(flowNodeId)
        //        select fn;
        //    return queryable.FirstOrDefault();
        //}

        //public IEnumerable<FlowNode> GetNextFlow(int flowNodeId)
        //{
        //    IQueryable<FlowNode> queryable =
        //        from fn in Store.DbEntitySet
        //        join sf in SequenceFlow on fn.FlowNodeId equals sf.ItemSourceTarget
        //        where sf.ItemSourceRef.Equals(flowNodeId)
        //        select fn;
        //    return queryable.AsEnumerable();
        //}

    }
}
