using BpmNet.Bpmn;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet
{
    public interface IBpmNetDefinitionService
    {
        Task<BpmnDefinitions> DeployAsync(string filePath, bool replace, CancellationToken cancellationToken = default);
        Task<BpmnDefinitions> DeployAsync(string filePath, CancellationToken cancellationToken = default);
        Task<BpmnDefinitions> DeployAsync(Stream stream, bool replace, CancellationToken cancellationToken = default);
        Task<BpmnDefinitions> DeployAsync(Stream stream, CancellationToken cancellationToken = default);
        Task<bool> IsExistsAsync(string id, CancellationToken cancellationToken = default);
        Task<BpmnDefinitions> GetDefinitionAsync(string id, CancellationToken cancellationToken = default);
    }
}
