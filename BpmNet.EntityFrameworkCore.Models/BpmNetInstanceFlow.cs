using System;

namespace BpmNet.EntityFrameworkCore.Models
{
    public class BpmNetInstanceFlow : IBpmNetInstanceFlow
    {
        public BpmNetInstanceFlow()
        {
            Id = Guid.NewGuid();
            Start = DateTime.Now;
            Status = FlowResult.NotStarted;
        }
        public BpmNetInstanceFlow(Guid processInstanceId, string flowId) : this()
        {
            ProcessInstanceId = processInstanceId;
            FlowId = flowId;
        }

        public Guid Id { get; set; }
        public Guid ProcessInstanceId { get; set; }
        public string FlowId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Finnish { get; set; }
        public FlowResult Status { get; set; }
        public FlowElementType ElementType { get; set; }
        public int Duration { get; set; }
    }
}
