using BpmNet.Abstractions.Flow;
using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    public class BpmNetReceiveTaskProcessService : IBpmNetReceiveTaskProcessService
    {
        public  Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnReceiveTask flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(FlowResult.Completed);
        }

        public Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnReceiveTask flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(0);
        }
    }
}
