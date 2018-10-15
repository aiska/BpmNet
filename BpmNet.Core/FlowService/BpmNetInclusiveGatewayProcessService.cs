using BpmNet.Abstractions.Flow;
using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    /// <summary>
    /// Inclusive gateway is also a division point of the business process.
    /// Unlike the exclusive gateway, inclusive gateway may trigger more than 1 out-going paths.
    /// Since inclusive gateway may trigger more than 1 out-going paths, 
    /// the condition checking process will have a little bit different then the exclusive gateway. 
    /// </summary>
    public class BpmNetInclusiveGatewayProcessService : BpmNetGatewayProcessService, IBpmNetInclusiveGatewayProcessService
    {
        public Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnInclusiveGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return base.ExecuteAsync(instance, flow, cancellationToken);
        }

        public Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnInclusiveGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(0);
        }
    }
}
