using BpmNet.Model;
using System;
using System.Collections.Generic;

namespace BpmNet.EntityFrameworkCore.Models
{
    public class BpmNetSubProcessInstance<TInstanceFlow> : IProcessInstance<TInstanceFlow>
        where TInstanceFlow : class, IBpmNetInstanceFlow
    {
        public ICollection<TInstanceFlow> Flows { get; set; }
        public Guid Id { get; set; }
        public string ProcessId { get; set; }
        public string BussinesKey { get; set; }
        public string TenantId { get; set; }
        public InstanceStatus Status { get; set; }
    }
}
