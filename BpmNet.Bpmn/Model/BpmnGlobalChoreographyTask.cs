using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("globalChoreographyTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnGlobalChoreographyTask : BpmnChoreography
    {

        [XmlAttribute("initiatingParticipantRef")]
        public XmlQualifiedName InitiatingParticipantRef { get; set; }
    }
}
