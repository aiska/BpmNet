namespace BPMNET.Entity.IntKey
{
    public class ProcessInstanceStore : ProcessInstanceStore<int, ProcessInstance>
    {
        public ProcessInstanceStore() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessInstanceStore(BpmDbContext context) : base(context) { }
    }
}
