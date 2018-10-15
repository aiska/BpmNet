using System;
using System.Collections.Generic;

namespace BpmNet.Model
{
    public interface IProcessInstance
    {
        Guid Id { get; set; }
        string ProcessId { get; set; }
        string BussinesKey { get; set; }
        string TenantId { get; set; }
        InstanceStatus Status { get; set; }
    }

    public interface IProcessInstance<TInstanceFlow> : IProcessInstance
        where TInstanceFlow : IBpmNetInstanceFlow
    {
        ICollection<TInstanceFlow> Flows { get; set; }
    }
}