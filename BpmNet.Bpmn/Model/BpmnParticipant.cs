using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("participant", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnParticipant : BpmnBaseElement
    {
        [XmlElement("interfaceRef")]
        public XmlQualifiedName[] InterfaceRef { get; set; }

        [XmlElement("endPointRef")]
        public XmlQualifiedName[] EndPointRef { get; set; }

        [XmlElement("participantMultiplicity")]
        public BpmnParticipantMultiplicity ParticipantMultiplicity { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("processRef")]
        public XmlQualifiedName ProcessRef { get; set; }
    }
}
