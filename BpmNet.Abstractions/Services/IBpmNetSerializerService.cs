using BpmNet.Bpmn;
using System.IO;

namespace BpmNet
{
    public interface IBpmNetSerializerService
    {
        BpmnDefinitions Deserialize(Stream stream);
        BpmnDefinitions Deserialize(string fileName);
    }
}
