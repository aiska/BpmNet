using BpmNet.Abstractions.Flow;
using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    public class BpmNetComplexGatewayProcessService : BpmNetGatewayProcessService, IBpmNetComplexGatewayProcessService
    {
        public Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnComplexGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return base.ExecuteAsync(instance, flow, cancellationToken);
        }

        public Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnComplexGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(0);
        }
    }
}
