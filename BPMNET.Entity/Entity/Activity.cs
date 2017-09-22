using BPMNET.Bpmn;
using BPMNET.Core;

namespace BPMNET.Entity
{
    public class Activity : IActivity<int>
    {
        public int ActivityId { get; set; }
        public int FlowId { get; set; }
        public string Id { get; set; }
        public int ProcessInstanceId { get; set; }
        public ProcessItemType ActivityType { get; set; }
    }
}
