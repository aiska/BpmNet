using BPMNET.Bpmn;

namespace BPMNET.Core
{
    public interface IProcessTask<TKey>
    {
        TKey Id { get; set; }
        TKey FlowNodeId { get; set; }
        TKey ProcessInstanceId { get; set; }
        string TaskId { get; set; }
        ProcessItemType TaskType { get; set; }
        bool IsEnded { get; set; }
        string Assignee { get; set; }
        TaskStatus CurrentStatus { get; set; }
        TaskStatus PreviousStatus { get; set; }
        string Workgroup { get; set; }
        string TenantId { get; set; }
    }
}
