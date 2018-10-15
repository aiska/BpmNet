using System;

namespace BpmNet.Model
{
    public interface IBpmNetHistory
    {
        Guid Id { get; set; }
        Guid ProcessInstanceId { get; set; }
        string ProcessId { get; set; }
        string FlowId { get; set; }
        DateTime Start { get; set; }
        DateTime Finnish { get; set; }
        int Duration { get; set; }
        FlowResult Status { get; set; }
    }
}
