using BPMNET.Core;

namespace BPMNET.Entity.IntKey
{
    public class ProcessManager : ProcessManager<int, ProcessInstance, ProcessDefinition, ProcessTask>
    {
        public ProcessManager() : base(new BpmDbContext())
        {
        }
        public ProcessManager(BpmDbContext context) : base(context)
        {
        }
        public ProcessManager(IProcessDefinitionStore<int, ProcessDefinition> definitionStore,
            IProcessInstanceStore<int, ProcessInstance> instanceStore,
            IProcessTaskStore<int, ProcessTask> taskStore) :
            base(definitionStore, instanceStore, taskStore)
        {
        }
    }
}
