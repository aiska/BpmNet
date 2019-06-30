using BpmNet.Bpmn;
using BpmNet.Serializer;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Core.Services
{
    public class BpmNetSerializerService : IBpmNetSerializer
    {
        private readonly object locker = new object();
        //public BpmnDefinitions Deserialize(Stream stream)
        //{
        //    var serializer = new XmlSerializer(typeof(BpmnDefinitions));
        //    return (BpmnDefinitions)serializer.Deserialize(stream);
        //}

        //public BpmnDefinitions Deserialize(string fileName)
        //{
        //    using (var stream = File.OpenRead(fileName))
        //    {
        //        return Deserialize(stream);
        //    }
        //}

        public Task<BpmnDefinitions> DeserializeBpmnStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                lock (locker)
                {
                    stream.Position = 0;
                    var serializer = new XmlSerializer(typeof(BpmnDefinitions));
                    return (BpmnDefinitions)serializer.Deserialize(stream);
                }
            }, cancellationToken);
        }

        public Task<BpmnDefinitions> DeserializeBpmnFileAsync(string fileName, CancellationToken cancellationToken)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return DeserializeBpmnStreamAsync(stream, cancellationToken);
            }
        }

        public Task<string> DeserializeStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            lock (locker)
            {
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEndAsync();
            }
        }

        public Task<Stream> SerializeAsync(string xml, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(xml);
                return (Stream)new MemoryStream(byteArray);
            }, cancellationToken);
        }

        public Task<string> SerializeBpmnAsync(BpmnDefinitions definitions, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var serializer = new XmlSerializer(typeof(BpmnDefinitions));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, definitions);
                    return stringWriter.ToString();
                }
            }, cancellationToken);
        }
    }
}
