using BpmNet.Bpmn;
using BpmNet.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.FlowService
{
    public class BpmNetGatewayProcessService
    {
        public Task<FlowResult> ExecuteAsync<TInstanceFlow>(IProcessInstance<TInstanceFlow> instance, BpmnGateway flow, CancellationToken cancellationToken) where TInstanceFlow : IBpmNetInstanceFlow
        {
            for (int i = 0; i < flow.Incoming.Length; i++)
            {
                var instanceflow = instance.Flows.FirstOrDefault(t => t.FlowId == flow.Incoming[i].Name);
                if (instanceflow == null ||
                    (instanceflow.Status != FlowResult.NotProcessing &&
                    instanceflow.Status != FlowResult.Completed))
                {
                    Task.FromResult(FlowResult.WaitingOtherProcess);
                }
            }
            return Task.FromResult(FlowResult.Completed);
        }
    }
}
