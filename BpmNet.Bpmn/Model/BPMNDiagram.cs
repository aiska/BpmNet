using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI", IsNullable = false)]
    public partial class BpmnDiagram : Diagram
    {
        [XmlElement("BPMNPlane")]
        public BpmnPlane BPMNPlane { get; set; }

        [XmlElement("BPMNLabelStyle")]
        public BpmnLabelStyle[] BPMNLabelStyle { get; set; }
    }
}
