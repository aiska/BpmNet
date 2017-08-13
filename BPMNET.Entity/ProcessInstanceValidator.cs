using BPMNET.Configuration;
using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    internal class ProcessInstanceValidator<TKey, TProcessInstance, TProcessDefinition> : IProcessInstanceValidator<TProcessInstance>
        where TKey : IEquatable<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>
        where TProcessDefinition : class, IProcessDefinition<TKey>
    {
        private ProcessInstanceManager<TKey, TProcessInstance, TProcessDefinition> Manager;

        public ProcessInstanceValidator(ProcessInstanceManager<TKey, TProcessInstance, TProcessDefinition> manager)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            Manager = manager;
        }

        public BpmResult Validate(TProcessInstance processInstance)
        {
            if (processInstance == null)
                throw new ArgumentNullException("processInstance");
            List<string> list = new List<string>();
            ValidateProcessDefinition(processInstance, list);
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        public async Task<BpmResult> ValidateAsync(TProcessInstance processInstance)
        {
            List<string> list = new List<string>();
            await ValidateProcessDefinitionAsync(processInstance, list);
            return list.Count > 0 ? BpmResult.Failed(list.ToArray()) : BpmResult.Success;
        }

        private async Task ValidateProcessDefinitionAsync(TProcessInstance processInstance, List<string> list)
        {
            if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None && processInstance.ProcessInstanceId == null)
            {
                list.Add("processInstanceId cannot be null or empty'.");
                return;
            }
            else if (Config.Instance.GeneratedOption == DatabaseGeneratedOption.None)
            {
                TProcessInstance Current = await Manager.FindProcessInstanceByIdAsync(processInstance.ProcessInstanceId);
                if (Current != null && Current.ProcessDefinitionId.Equals(processInstance.ProcessInstanceId))
                {
                    list.Add("processInstance with id '" + processInstance.ProcessDefinitionId + "' already exist.");
                }
            }
            //bool procDefExist = await processInstanceManager.IsProcessDefinitionExistAsync(processInstance.ProcessDefinitionId);
            //if (!procDefExist) list.Add("ProcessDefinition '" + processInstance.ProcessDefinitionId  + "' not found.");
        }

        private void ValidateProcessDefinition(TProcessInstance processInstance, List<string> list)
        {
            bool procDefExist = Manager.IsProcessDefinitionExist(processInstance.ProcessDefinitionId);
            if (!procDefExist) list.Add("ProcessDefinition '" + processInstance.ProcessDefinitionId + "' not found.");
        }
    }
}