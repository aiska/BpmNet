
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BPMNET.Core
{
    public interface IProcessTask<TKey> : IProcessTaskKey<TKey>, IProcessInstanceKey<TKey>
    {

        /// <summary>
        /// Name or Title of Task
        /// </summary>
        string Name { get; set; }

        TKey ProcessDefinitionId { get; set; }

        /// <summary>
        /// Free text description of task
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The UserId of the person that is responsible for this task.
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        /// The UserId of the person to which this task is delegated.
        /// </summary>
        string Assignee { get; set; }

        /// <summary>
        /// Reference to the path of execution or null if it is not related to a process instance.
        /// </summary>
        string ExecutionId { get; set; }
        /// <summary>
        /// Indication of how important/urgent this task is
        /// </summary>
        int Priority { get; set; }

        string BusinessKey { get; set; }
        /// <summary>
        /// The id of the activity in the process defining this task or null if this is not related to a process
        /// </summary>
        TKey ProcessItemDefinitionId { get; set; }
        /// <summary>
        /// The date/time when this task was created
        /// </summary>
        DateTime TaskDate { get; set; }
        /// <summary>
        /// Due date of the task.
        /// </summary>
        DateTime? getDueDate { get; set; }

        /// <summary>
        /// The category of the task. This is an optional field and allows to 'tag'
        /// tasks as belonging to a certain category.
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// The parent task for which this task is a subtask
        /// </summary>
        string ParentTaskId { get; set; }
        /// <summary>
        /// The tenant identifier of this task
        /// </summary>
        string TenantId { get; set; }

        /// <summary>
        /// Returns the local task variables if requested in the task query
        /// </summary>
        Dictionary<string, object> TaskVariables { get; set; }
        ESuspensionState SuspensionState { get; set; }
    }
}
