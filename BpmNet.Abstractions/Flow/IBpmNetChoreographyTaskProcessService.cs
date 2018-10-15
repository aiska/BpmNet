using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Abstractions.Flow
{
    public interface IBpmNetChoreographyTaskProcessService
    {
        Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnChoreographyTask flow, CancellationToken cancellationToken)
          where TInstanceFlow : IBpmNetInstanceFlow;

        Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnChoreographyTask flow, CancellationToken cancellationToken)
           where TInstanceFlow : IBpmNetInstanceFlow;
    }
}
