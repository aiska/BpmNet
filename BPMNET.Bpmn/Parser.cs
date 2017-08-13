using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    public class Parser
    {
        #region BPMN Parser
        public tDefinitions Deserialize(string fileName)
        {
            using (var xmlStream = new StreamReader(fileName))
            {
                var serialzer = new XmlSerializer(typeof(tDefinitions));
                return (tDefinitions)serialzer.Deserialize(xmlStream);
            }
        }

        public Task<tDefinitions> DeserializeAsync(string fileName)
        {
            return Task.Factory.StartNew(() => Deserialize(fileName));
        }

        private tProcess DeserializeProcess(string stringProcess)
        {
            using (var textWriter = new StringReader(stringProcess))
            {
                var serialzer = new XmlSerializer(typeof(tProcess));
                return (tProcess)serialzer.Deserialize(textWriter);
            }
        }

        public Task<tProcess> DeserializeProcessAsync(string stringProcess)
        {
            return Task.Factory.StartNew(() => DeserializeProcess(stringProcess));
        }

        public Task<string> SerializeProcessAsync(tProcess process)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var textWriter = new StringWriter())
                {
                    var xmlSerializer = new XmlSerializer(typeof(tProcess));
                    xmlSerializer.Serialize(textWriter, process);
                    return textWriter.ToString();
                }
            });
        }

        public Task SerializeAsync(string fileName, tDefinitions definition)
        {
            return Task.Factory.StartNew(() => Serialize(fileName, definition));
        }

        private void Serialize(string fileName, tDefinitions definition)
        {
            using (var xmlStream = new StreamWriter(fileName, false))
            {
                var serialzer = new XmlSerializer(typeof(tDefinitions));
                serialzer.Serialize(xmlStream, definition);
            }
        }
        #endregion
    }
}