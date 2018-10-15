using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet
{
    public interface IBpmNetUserTaskProcessService
    {
        Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnUserTask flow, CancellationToken cancellationToken)
          where TInstanceFlow : IBpmNetInstanceFlow;

        Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnUserTask flow, CancellationToken cancellationToken)
           where TInstanceFlow : IBpmNetInstanceFlow;

    }
}
