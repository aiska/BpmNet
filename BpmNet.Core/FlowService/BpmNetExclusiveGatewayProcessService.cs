using BpmNet.Abstractions.Flow;
using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    /// <summary>
    /// Exclusive gateway is a diversion point of a business process flow.
    /// For a given instance of the process, there is only one of the paths can be taken.
    /// If two possible paths will only execute one but not both.
    /// </summary>
    public class BpmNetExclusiveGatewayProcessService : BpmNetGatewayProcessService, IBpmNetExclusiveGatewayProcessService
    {
        public  Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnExclusiveGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return base.ExecuteAsync(instance, flow, cancellationToken);
        }

        public Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnExclusiveGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(0);
        }
    }
}
