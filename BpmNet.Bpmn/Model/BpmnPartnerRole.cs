using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("partnerRole", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnPartnerRole : BpmnRootElement
    {
        [XmlElement("participantRef")]
        public XmlQualifiedName[] ParticipantRef { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
