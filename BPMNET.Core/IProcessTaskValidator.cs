using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessTaskValidator<TProcessTask> : IValidator<TProcessTask>
    {
        Task<BpmResult> ValidateProcessInstanceAsync(TProcessTask processInstance);
        BpmResult ValidateProcessInstance(TProcessTask processInstance);
    }
}
