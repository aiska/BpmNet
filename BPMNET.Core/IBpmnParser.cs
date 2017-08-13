using BPMNET.Bpmn;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IBpmnParser
    {
        Task<tDefinitions> DeserializeAsync(string fileName);
        Task SerializeAsync(string fileName, tDefinitions definition);
        Task<tProcess> DeserializeProcessAsync(string stringProcess);
        Task<string> SerializeProcessAsync(tProcess process);
    }
}
