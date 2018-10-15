using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("error", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnError : BpmnRootElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("errorCode")]
        public string ErrorCode { get; set; }

        [XmlAttribute("structureRef")]
        public XmlQualifiedName StructureRef { get; set; }
    }
}
