namespace BPMNET.Entity.Store
{
    public class DataObjectStore : BaseStore<int, DataObject>
    {
        public DataObjectStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public DataObjectStore(BpmDbContext context) : base(context) { }
    }
}
