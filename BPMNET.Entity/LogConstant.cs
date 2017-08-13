using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    internal static class LogConstant
    {
        internal const string FindProcessInstanceByIdAsync = "FindProcessInstanceByIdAsync, processInstanceId={0}";
        internal const string FindProcessInstanceById = "FindProcessInstanceById, processInstanceId={0}";
        internal const string CreateProcessInstanceAsync = "CreateProcessInstanceAsync, processInstance={0}";
        internal const string CreateProcessInstance = "CreateProcessInstance, processInstance={0}";
        internal const string UpdateProcessInstanceAsync = "UpdateProcessInstanceAsync, processInstance={0}";
        internal const string UpdateProcessInstance = "UpdateProcessInstance, processInstance={0}";
        internal const string DeleteProcessInstanceAsync = "DeleteProcessInstanceAsync, processInstanceId={0}";
        internal const string DeleteProcessInstance = "DeleteProcessInstance, processInstanceId={0}";
        internal const string ActivateProcessInstanceByIdAsync = "ActivateProcessInstanceByIdAsync, processInstanceId={0}";
        internal const string ActivateProcessInstanceById = "ActivateProcessInstanceById, processInstanceId={0}";
        internal const string IsProcessDefinitionExistAsync = "IsProcessDefinitionExistAsync, ProcessDefinitionId={0}";
        internal const string IsProcessDefinitionExist = "IsProcessDefinitionExist, ProcessDefinitionId={0}";
        internal const string FindProcessDefinitionByIdAsync = "FindProcessDefinitionByIdAsync, ProcessDefinitionId={0}";
        internal const string FindProcessDefinitionById = "FindProcessDefinitionById, ProcessDefinitionId={0}";
        internal const string CreateProcessDefinitionAsync = "CreateProcessDefinitionAsync, processDefinition={0}";
        internal const string CreateProcessDefinition = "CreateProcessDefinition, processDefinition={0}";
        internal const string UpdateProcessDefinitionAsync = "UpdateProcessDefinitionAsync, processDefinition={0}";
        internal const string DeleteProcessDefinitionAsync = "DeleteProcessDefinitionAsync, processDefinitionId={0}";
        internal const string DeleteProcessDefinition = "DeleteProcessDefinition, processDefinitionId={0}";
        internal const string IsProcessTaskExist = "IsProcessTaskExist, processTaskId={0}";
        internal const string FindProcessTaskByIdAsync = "FindProcessTaskByIdAsync, processTaskId={0}";
        internal const string FindProcessTaskById = "FindProcessTaskById, processTaskId={0}";
        internal const string CreateProcessTaskAsync = "CreateProcessTaskAsync, processTask={0}";
        internal const string CreateProcessTask = "CreateProcessTask, processTask={0}";
        internal const string UpdateProcessTaskAsync = "UpdateProcessTaskAsync, processTask={0}";
        internal const string UpdateProcessTask = "UpdateProcessTask, processTask={0}";
        internal const string DeleteProcessTaskAsync = "DeleteProcessTaskAsync, processTaskId={0}";
        internal const string DeleteProcessTask = "DeleteProcessTask, processTaskId={0}";
        internal const string ClaimProcessTaskAsync = "ClaimProcessTaskAsync, processTaskId={0}, userId={1}";
        internal const string ClaimProcessTask = "ClaimProcessTask, processTaskId={0}, userId={1}";
        internal const string UnClaimProcessTaskAsync = "UnClaimProcessTaskAsync, processTaskId={0}";
        internal const string UnClaimProcessTask = "UnClaimProcessTask, processTaskId={0}";
        internal const string CompleteProcessTask = "CompleteProcessTask, processTaskId={0}";
        internal const string CompleteProcessTaskAsync = "CompleteProcessTaskAsync, processTaskId={0}";
        internal const string CompleteProcessTaskAsync2 = "CompleteProcessTaskAsync, processTaskId={0}";
    }
}
