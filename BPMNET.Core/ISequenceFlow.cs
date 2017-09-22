namespace BPMNET.Core
{
    public interface ISequenceFlow<TKey>
    {
        TKey Id { get; set; }
        TKey SourceId { get; set; }
        TKey TargetId { get; set; }
        string SequenceFlowId { get; set; }
        string SequenceFlowName { get; set; }
        string SourceRef { get; set; }
        string TargetRef { get; set; }
        string ConditionExpression { get; set; }
    }
}
