using BPMNET.Core.Entity;

namespace BPMNET.Entity
{
    public class ProcessFlowEntity : ProcessFlowEntity<int>
    {
        public int ProcessFlowId { get; set; }
        public int ProcessInstanceId { get; set; }
        public int FlowFrom { get; set; }
        public int FlowTo { get; set; }
    }
}
