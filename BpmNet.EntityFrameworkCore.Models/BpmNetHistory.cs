using System;
using BpmNet.Model;

namespace BpmNet.EntityFrameworkCore.Models
{
    public class BpmNetHistory : IBpmNetHistory
    {
        public Guid Id { get; set; }
        public Guid ProcessInstanceId { get; set; }
        public string ProcessId { get; set; }
        public string FlowId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finnish { get; set; }
        public int Duration { get; set; }
        public FlowResult Status { get; set; }
    }
}
