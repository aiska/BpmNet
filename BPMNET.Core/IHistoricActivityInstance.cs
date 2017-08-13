using System;
namespace BPMNET.Core
{
    public interface IHistoricActivityInstance
    {
        string Assignee { get; set; }
        string BpmId { get; set; }
        string BpmName { get; set; }
        string BpmType { get; set; }
        string CalledProcessInstanceId { get; set; }
        long DurationInMillis { get; set; }
        DateTime EndTime { get; set; }
        string ExecutionId { get; set; }
        string Id { get; set; }
        string ProcessDefinitionId { get; set; }
        string ProcessInstanceId { get; set; }
        DateTime StartTime { get; set; }
        string TaskId { get; set; }
        string TenantId { get; set; }
    }
}
