using BPMNET.Core;

namespace BPMNET.Entity
{
    public class SequenceFlowEntity : ISequenceFlow<int>
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public string SequenceFlowId { get; set; }
        public string SequenceFlowName { get; set; }
        public string SourceRef { get; set; }
        public string TargetRef { get; set; }
        public string ConditionExpression { get; set; }
    }
}
