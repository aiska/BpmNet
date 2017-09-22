using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BPMNET.Bpmn;
using BPMNET.Entity.Store;
using BPMNET.Entity;

namespace BPMNET.Engine.Manager.Int
{
    public class InstanceTask : IInstanceTask<int>
    {
        #region Properties
        protected ProcessInstanceStore Store { get; private set; }
        public string Assignee { get; private set; }
        public Core.TaskStatus CurrentStatus { get; set; }
        public int FlowNodeId { get; set; }
        public int Id { get; set; }
        public bool IsEnded { get; set; }
        public Core.TaskStatus PreviousStatus { get; set; }
        public int ProcessInstanceId { get; set; }
        public string TaskId { get; set; }
        public ProcessItemType TaskType { get; set; }
        public string TenantId { get; set; }
        public string Workgroup { get; set; }

        #endregion

        public InstanceTask(ProcessInstanceStore store, ProcessTaskEntity entity)
        {
            Store = store;
            CurrentStatus = entity.CurrentStatus;
            FlowNodeId = entity.FlowNodeId;
            Id = entity.Id;
            IsEnded = entity.IsEnded;
            PreviousStatus = entity.PreviousStatus;
            ProcessInstanceId = entity.ProcessInstanceId;
            TaskId = entity.TaskId;
            TaskType = entity.TaskType;
            TenantId = entity.TenantId;
            Workgroup = entity.Workgroup;
        }

        public Task AssignTask(IUser user)
        {
            throw new NotImplementedException();
        }

        public Task AssignTask(IUser user, IDictionary<string, object> variables)
        {
            throw new NotImplementedException();
        }

        public Task ClaimTask(IUser user)
        {
            throw new NotImplementedException();
        }

        public Task CompleteTask(IDictionary<string, object> variables)
        {
            throw new NotImplementedException();
        }
    }
}
