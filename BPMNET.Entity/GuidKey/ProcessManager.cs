using BPMNET.Core;
using System;

namespace BPMNET.Entity.GuidKey
{
    public class ProcessManager : ProcessManager<Guid, ProcessInstance, ProcessDefinition, ProcessTask>
    {
        public ProcessManager() : base(new BpmDbContext())
        {
        }
        public ProcessManager(BpmDbContext context) : base(context)
        {
        }
        public ProcessManager(IProcessDefinitionStore<Guid, ProcessDefinition> definitionStore,
            IProcessInstanceStore<Guid, ProcessInstance> instanceStore,
            IProcessTaskStore<Guid, ProcessTask> taskStore) :
            base(definitionStore, instanceStore, taskStore)
        {
        }
    }
}
