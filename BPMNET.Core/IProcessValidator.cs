using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessValidator<TKey, TProcessInstance, TProcessDefinition, TProcessTask>
        where TKey : IEquatable<TKey>
        where TProcessInstance : IProcessInstance<TKey>
        where TProcessDefinition : IProcessDefinition<TKey>
        where TProcessTask : IProcessTask<TKey>
    {
        Task<BpmResult> ValidateProcessInstanceAsync(TProcessInstance processInstance);
        BpmResult ValidateProcessInstance(TProcessInstance processInstance);
        Task<BpmResult> ValidateProcessDefinitionAsync(TProcessDefinition processDefinition);
        BpmResult ValidateProcessDefinition(TProcessDefinition processDefinition);
        Task<BpmResult> ValidateProcessTaskAsync(TProcessTask processTask);
        BpmResult ValidateProcessTask(TProcessTask processTask);
        Task<BpmResult> ValidateClaimTaskAsync(TProcessTask processTask, string userId);
        BpmResult ValidateClaimTask(TProcessTask processTask, string userId);
        BpmResult ValidateSuspendedTask(TProcessTask processTask);
    }
}