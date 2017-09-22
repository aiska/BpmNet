using System;
namespace BPMNET.Core
{
    public interface IProcessInstanceHistory
    {
        Guid ProcessInstanceHistoryId { get; set; }
        Guid ProcessInstanceId { get; set; }
        Guid ExecutionId { get; set; }
        Guid TaskId { get; set; }
        Guid CalledProcessInstanceId { get; set; }
        string Assignee { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        long DurationInMillis { get; set; }
        string TenantId { get; set; }
    }
}
