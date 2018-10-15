using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("import", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnImport
    {
        [XmlAttribute("namespace", DataType = "anyURI")]
        public string Namespace { get; set; }

        [XmlAttribute("location")]
        public string Location { get; set; }

        [XmlAttribute("importType", DataType = "anyURI")]
        public string ImportType { get; set; }
    }
}
