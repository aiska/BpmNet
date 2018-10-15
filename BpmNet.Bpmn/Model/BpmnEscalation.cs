using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("escalation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnEscalation : BpmnRootElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("escalationCode")]
        public string EscalationCode { get; set; }

        [XmlAttribute("structureRef")]
        public XmlQualifiedName StructureRef { get; set; }
    }
}
