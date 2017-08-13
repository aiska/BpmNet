namespace BPMNET.Core
{
    public interface IBpmEvent
    {
        string ExecutionId { get; set; }
        string ProcessDefinitionId { get; set; }
        string ProcessInstanceId { get; set; }
        EBpmEventType Type { get; set; }
    }
}
