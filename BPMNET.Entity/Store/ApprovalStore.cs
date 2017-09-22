namespace BPMNET.Entity.Store
{
    public class ApprovalStore : BaseStore<int, Approval>
    {
        public ApprovalStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ApprovalStore(BpmDbContext context) : base(context)
        {
        }
    }
}
