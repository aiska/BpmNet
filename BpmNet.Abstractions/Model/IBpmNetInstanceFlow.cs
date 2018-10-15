using System;

namespace BpmNet
{
    public interface IBpmNetInstanceFlow
    {
        Guid Id { get; set; }
        FlowElementType ElementType { get; set; }
        string FlowId { get; set; }
        Guid ProcessInstanceId { get; set; }
        DateTime Start { get; set; }
        DateTime? Finnish { get; set; }
        int Duration { get; set; }
        FlowResult Status { get; set; }
    }
}