namespace BPMNET.Entity.Store
{
    public class DefinitionItemStore : BaseStore<int, DefinitionItemEntity>
    {
        public DefinitionItemStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public DefinitionItemStore(BpmDbContext context) : base(context)
        {
        }
    }
}
