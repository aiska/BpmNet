using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("documentation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDocumentation
    {
        public BpmnDocumentation()
        {
            TextFormat = "text/plain";
        }

        [XmlText()]
        [XmlAnyElement()]
        public XmlNode[] Any { get; set; }

        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        [XmlAttribute("textFormat")]
        [DefaultValue("text/plain")]
        public string TextFormat { get; set; }
    }
}
