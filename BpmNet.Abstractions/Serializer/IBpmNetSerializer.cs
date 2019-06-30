using BpmNet.Bpmn;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Serializer
{
    public interface IBpmNetSerializer
    {
        Task<string> SerializeBpmnAsync(BpmnDefinitions definitions, CancellationToken cancellationToken);
        Task<Stream> SerializeAsync(string xml, CancellationToken cancellationToken);

        Task<BpmnDefinitions> DeserializeBpmnStreamAsync(Stream stream, CancellationToken cancellationToken);
        Task<BpmnDefinitions> DeserializeBpmnFileAsync(string fileName, CancellationToken cancellationToken);
        Task<string> DeserializeStreamAsync(Stream stream, CancellationToken cancellationToken);
    }
}
