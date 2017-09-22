using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    public class BpmnetParser
    {
        public static void SerializeDefinition(string fileName, tDefinitions definition)
        {
            using (var xmlStream = new StreamWriter(fileName, false))
            {
                var serialzer = new XmlSerializer(typeof(tDefinitions));
                serialzer.Serialize(xmlStream, definition);
            }
        }

        public static string SerializeDefinition(tDefinitions definition)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(tDefinitions));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, definition);
                return textWriter.ToString();
            }
        }

        public static XmlDocument GetXmlDocument(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            return xmlDoc;
        }

        public static tDefinitions DeserializeDefinitionString(string xml)
        {
            using (var StringReader = new StringReader(xml))
            {
                var serialzer = new XmlSerializer(typeof(tDefinitions));
                return (tDefinitions)serialzer.Deserialize(StringReader);
            }
        }

        public static tDefinitions DeserializeDefinition(string fileName)
        {
            using (var xmlStream = new StreamReader(fileName))
            {
                var serialzer = new XmlSerializer(typeof(tDefinitions));
                return (tDefinitions)serialzer.Deserialize(xmlStream);

            }
        }

        public async Task<tDefinitions> DeserializeDefinitionAsync(string fileName)
        {
            return await Task.Run(() => DeserializeDefinition(fileName));
        }

        private static tProcess DeserializeProcess(string stringProcess)
        {
            using (var textWriter = new StringReader(stringProcess))
            {
                var serialzer = new XmlSerializer(typeof(tProcess));
                return (tProcess)serialzer.Deserialize(textWriter);
            }
        }

        public static async Task<tProcess> DeserializeProcessAsync(string stringProcess)
        {
            return await Task.Run(() => DeserializeProcess(stringProcess));
        }

        public static async Task<string> SerializeProcessAsync(tProcess process)
        {
            return await Task.Run(() =>
            {
                using (var textWriter = new StringWriter())
                {
                    var xmlSerializer = new XmlSerializer(typeof(tProcess));
                    xmlSerializer.Serialize(textWriter, process);
                    return textWriter.ToString();
                }
            });
        }

        public static async Task SerializeDefinitionAsync(string fileName, tDefinitions definition)
        {
            await Task.Run(() => SerializeDefinition(fileName, definition));
        }
    }
}
