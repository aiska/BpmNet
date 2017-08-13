using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class HistoricDetail : IHistoricDetail
    {
        public string Id { get; set; }
        public string ProcessInstanceId { get; set; }
        public string BpmInstanceId { get; set; }
        public string ExecutionId { get; set; }
        public string TaskId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
