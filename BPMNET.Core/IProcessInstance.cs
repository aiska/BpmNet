namespace BPMNET.Core
{
    public interface IProcessInstance<TKey>
    {
        TKey Id { get; set; }
        TKey ProcessDefinitionId { get; set; }
        string TenantId { get; set; }
        string BusinessKey { get; set; }
        string ProcessId { get; set; }
        bool IsSuspended { get; set; }
        bool IsEnded { get; set; }
        ProcessInstanceStatus Status { get; set; }
    }
}
