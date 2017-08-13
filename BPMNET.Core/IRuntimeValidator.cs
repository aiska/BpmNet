using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IRuntimeValidator<TKey, TProcessInstance, TIdentityLink, TProcessTask>
        where TProcessInstance : IProcessInstance<TKey>
        where TIdentityLink : IIdentityLink<TKey>
        where TProcessTask : IProcessTask<TKey>
    {
        Task<BpmResult> ValidateProcessInstanceAsync(TProcessInstance processInstance);
        Task<BpmResult> ValidateProcessTaskAsync(TProcessTask processTask);
        Task<BpmResult> ValidateIdentityAsync(TIdentityLink identity);
    }
}
