using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    public class BpmNetUserTaskProcessService : IBpmNetUserTaskProcessService
    {
        public Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnUserTask flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(FlowResult.InProcess);
        }

        public Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnUserTask flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(0);
        }
    }
}
