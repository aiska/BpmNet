using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("choreographyTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnChoreographyTask : BpmnChoreographyActivity
    {

        [XmlElement("messageFlowRef")]
        public XmlQualifiedName[] MessageFlowRef { get; set; }
    }
}
