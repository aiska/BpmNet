using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace BPMNET.Entity
{
    public class ProcessTask : ProcessTask<string>
    { }
    public class ProcessTask<TKey> : IProcessTask<TKey>
    {
        public ProcessTask()
        {
            TaskDate = DateTime.Now;
            SuspensionState = ESuspensionState.ACTIVE;
        }
        public string Assignee { get; set; }

        public string BusinessKey { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string ExecutionId { get; set; }

        public DateTime? getDueDate { get; set; }

        public Dictionary<string, object> TaskVariables { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string ParentTaskId { get; set; }

        public int Priority { get; set; }

        public TKey ProcessDefinitionId { get; set; }

        public TKey ProcessInstanceId { get; set; }

        public TKey ProcessItemDefinitionId { get; set; }

        public DateTime TaskDate { get; set; }

        public TKey ProcessTaskId { get; set; }

        public string TenantId { get; set; }

        public ESuspensionState SuspensionState { get; set; }
    }
}
