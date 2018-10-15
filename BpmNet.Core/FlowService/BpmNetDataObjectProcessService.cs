using BpmNet.Abstractions.Flow;
using BpmNet.Bpmn;
using BpmNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    public class BpmNetDataObjectProcessService : IBpmNetDataObjectProcessService
    {
        public  Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnDataObject flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(FlowResult.Completed);
        }

        public Task OnCompleteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnDataObject flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            return Task.FromResult(0);
        }
    }
}
