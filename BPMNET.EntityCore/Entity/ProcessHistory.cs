using System;

namespace BPMNET.EntityCore
{
    public class ProcessHistory
    {
        public ProcessHistory()
        {
            ProcessHistoryId = Guid.NewGuid();
        }
        public Guid ProcessHistoryId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessInstanceName { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public DateTime Inserted { get; set; }
    }
}
