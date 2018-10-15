using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    public static class SerializerService
    {
        public static Task<string> SerializeToStringAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEndAsync();
            }
        }

        public static Task<BpmnDefinitions> DeserializeFromStringAsync(string content, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                var serializer = new XmlSerializer(typeof(BpmnDefinitions));
                using (TextReader reader = new StringReader(content))
                {
                    return (BpmnDefinitions)serializer.Deserialize(reader);
                }
            });
        }

        public static Task<BpmnDefinitions> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                var serializer = new XmlSerializer(typeof(BpmnDefinitions));
                return (BpmnDefinitions)serializer.Deserialize(stream);
            }, cancellationToken);
        }

        public static Task<BpmnDefinitions> DeserializeAsync(string fileName, CancellationToken cancellationToken = default)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return DeserializeAsync(stream);
            }
        }
    }
}
