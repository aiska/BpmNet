using System;
using System.Collections.Generic;

namespace BPMNET.Core
{
    public interface IProcessEvent
    {
        string Id { get; set; }
        string Action { get; set; }
        ICollection<string> MessageParts { get; set; }
        string Message { get; set; }
        string UserId { get; set; }
        DateTime CreateDate { get; set; }
        string TaskId { get; set; }
        string ProcessInstanceId { get; set; }
    }
}
