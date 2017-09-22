namespace BPMNET.Entity.Store
{
    public class DefinitionVariableStore : BaseStore<int, DefinitionVariable>
    {
        public DefinitionVariableStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public DefinitionVariableStore(BpmDbContext context) : base(context)
        {
        }
    }
}
