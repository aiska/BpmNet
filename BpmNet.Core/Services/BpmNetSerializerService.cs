using BpmNet.Bpmn;
using System.IO;
using System.Xml.Serialization;

namespace BpmNet.Core.Services
{
    public class BpmNetSerializerService : IBpmNetSerializerService
    {
        public BpmnDefinitions Deserialize(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(BpmnDefinitions));
            return (BpmnDefinitions)serializer.Deserialize(stream);
        }

        public BpmnDefinitions Deserialize(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return Deserialize(stream);
            }
        }
    }
}
