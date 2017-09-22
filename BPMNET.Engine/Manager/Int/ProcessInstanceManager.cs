using BPMNET.Core;
using BPMNET.Entity;
using BPMNET.Entity.Store;
using System.Threading.Tasks;
using System;

namespace BPMNET.Engine.Manager.Int
{
    public class ProcessInstanceManager : ProcessInstanceManager<int, ProcessInstanceStore, Instance, InstanceTask, ProcessInstanceEntity, FlowNodeEntity>
    {
        #region Constructor
        public ProcessInstanceManager(ProcessInstanceStore processInstanceStore) : base(processInstanceStore)
        {
        }
        #endregion

        #region SubRoutine
        public override async Task<Instance> GetProcessInstanceAsync(int processInstanceId)
        {
            var entity = await Store.GetProcessInstanceAsync(processInstanceId);
            return new Instance(Store, entity);
        }

        public override async Task<Instance> StartProcessInstanceAsync(string process, string businessKey)
        {
            var entity = await Store.StartProcessInstanceAsync(process, businessKey);
            return new Instance(Store, entity);
        }

        public override async Task<Instance> StartProcessInstanceAsync(int processId, string businessKey)
        {
            var processInstance = await Store.StartProcessInstanceAsync(processId, businessKey);
            return new Instance(Store, processInstance);
        }
        #endregion
    }
}
