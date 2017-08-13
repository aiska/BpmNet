using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class HistoricActivityInstance : IHistoricActivityInstance
    {
        public string Id { get; set; }
        public string BpmId { get; set; }
        public string BpmName { get; set; }
        public string BpmType { get; set; }
        public string ProcessDefinitionId { get; set; }
        public string ProcessInstanceId { get; set; }
        public string ExecutionId { get; set; }
        public string TaskId { get; set; }
        public string CalledProcessInstanceId { get; set; }
        public string Assignee { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long DurationInMillis { get; set; }
        public string TenantId { get; set; }
    }
}
