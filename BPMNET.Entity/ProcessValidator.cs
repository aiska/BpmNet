using System;
using System.Threading.Tasks;
using BPMNET.Core;
using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BPMNET.Entity
{
    public class ProcessValidator<TKey, TProcessInstance, TProcessDefinition, TProcessTask> :
        IProcessValidator<TKey, TProcessInstance, TProcessDefinition, TProcessTask>
        where TKey : IEquatable<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>
        where TProcessDefinition : class, IProcessDefinition<TKey>
        where TProcessTask : class, IProcessTask<TKey>
    {
        private ProcessManager<TKey, TProcessInstance, TProcessDefinition, TProcessTask> Manager;

        public ProcessValidator(ProcessManager<TKey, TProcessInstance, TProcessDefinition, TProcessTask> manager)
        {
            Manager = manager;
        }

        public BpmResult ValidateClaimTask(TProcessTask processTask, string userId)
        {
            List<string> list = new List<string>();
            if (processTask.Assignee != null && userId != null && !processTask.Assignee.Equals(userId))
            {
                list.Add("Task already Claim By '" + processTask.Assignee + "'.");
            }
            else
            {
                ValidateSuspended(processTask, list);
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public virtual async Task<BpmResult> ValidateClaimTaskAsync(TProcessTask processTask, string userId)
        {
            List<string> list = new List<string>();
            Task task = Task.Run(() => ValidateClaimTask(processTask, userId));
            await task;
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public BpmResult ValidateProcessDefinition(TProcessDefinition processDefinition)
        {
            List<string> list = new List<string>();
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processDefinition.ProcessDefinitionId == null)
            {
                list.Add("processDefinitionId cannot be null or empty'.");
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessDefinition Current = Manager.FindProcessDefinitionById(processDefinition.ProcessDefinitionId);
                if (Current != null && !Current.ProcessDefinitionId.Equals(processDefinition.ProcessDefinitionId))
                {
                    list.Add("processDefinition with id '" + processDefinition.ProcessDefinitionId + "' already exist.");
                }
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public virtual async Task<BpmResult> ValidateProcessDefinitionAsync(TProcessDefinition processDefinition)
        {
            List<string> list = new List<string>();
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processDefinition.ProcessDefinitionId == null)
            {
                list.Add("processDefinitionId cannot be null or empty'.");
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessDefinition Current = await Manager.FindProcessDefinitionByIdAsync(processDefinition.ProcessDefinitionId);
                if (Current != null && !Current.ProcessDefinitionId.Equals(processDefinition.ProcessDefinitionId))
                {
                    list.Add("processDefinition with id '" + processDefinition.ProcessDefinitionId + "' already exist.");
                }
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public BpmResult ValidateProcessInstance(TProcessInstance processInstance)
        {
            List<string> list = new List<string>();
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processInstance.ProcessInstanceId == null)
            {
                list.Add("processInstanceId cannot be null or empty'.");
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessInstance Current = Manager.FindProcessInstanceById(processInstance.ProcessInstanceId);
                if (Current != null && !Current.ProcessInstanceId.Equals(processInstance.ProcessInstanceId))
                {
                    list.Add("processInstance with id '" + processInstance.ProcessInstanceId + "' already exist.");
                }
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public virtual async Task<BpmResult> ValidateProcessInstanceAsync(TProcessInstance processInstance)
        {
            List<string> list = new List<string>();
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processInstance.ProcessInstanceId == null)
            {
                list.Add("processInstanceId cannot be null or empty'.");
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessInstance Current = await Manager.FindProcessInstanceByIdAsync(processInstance.ProcessInstanceId);
                if (Current != null && !Current.ProcessInstanceId.Equals(processInstance.ProcessInstanceId))
                {
                    list.Add("processInstance with id '" + processInstance.ProcessInstanceId + "' already exist.");
                }
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }
        public BpmResult ValidateProcessTask(TProcessTask processTask)
        {
            List<string> list = new List<string>();
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processTask.ProcessTaskId == null)
            {
                list.Add("processTaskId cannot be null or empty'.");
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessTask Current = Manager.FindProcessTaskById(processTask.ProcessTaskId);
                if (Current != null && !Current.ProcessTaskId.Equals(processTask.ProcessTaskId))
                {
                    list.Add("processTask with id '" + processTask.ProcessTaskId + "' already exist.");
                }
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public virtual async Task<BpmResult> ValidateProcessTaskAsync(TProcessTask processTask)
        {
            List<string> list = new List<string>();
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processTask.ProcessTaskId == null)
            {
                list.Add("processTaskId cannot be null or empty'.");
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessTask Current = await Manager.FindProcessTaskByIdAsync(processTask.ProcessTaskId);
                if (Current != null && !Current.ProcessTaskId.Equals(processTask.ProcessTaskId))
                {
                    list.Add("processTask with id '" + processTask.ProcessTaskId + "' already exist.");
                }
            }
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public BpmResult ValidateSuspendedTask(TProcessTask processTask)
        {
            List<string> list = new List<string>();
            ValidateSuspended(processTask, list);
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public void ValidateSuspended(TProcessTask processTask, List<string> list)
        {
            if (processTask.SuspensionState == ESuspensionState.SUSPENDED)
            {
                list.Add("Cannot claim a suspended task.");
            }
        }
    }
}