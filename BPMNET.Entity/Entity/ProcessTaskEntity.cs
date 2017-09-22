
using BPMNET.Bpmn;
using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class ProcessTaskEntity : IProcessTask<int>, IAuditTrail
    {
        public ProcessTaskEntity()
        {
            PreviousStatus = TaskStatus.New;
            CurrentStatus = TaskStatus.New;
            SuspensionState = ESuspensionState.ACTIVE;
        }

        public int Id { get; set; }
        public int FlowNodeId { get; set; }
        public string TaskId { get; set; }
        public int ProcessInstanceId { get; set; }
        public ProcessItemType TaskType { get; set; }
        public bool IsEnded { get; set; }
        public string Assignee { get; set; }
        public TaskStatus CurrentStatus { get; set; }
        public TaskStatus PreviousStatus { get; set; }
        public string Workgroup { get; set; }
        public string TenantId { get; set; }
        public ESuspensionState SuspensionState { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime? UtcModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
