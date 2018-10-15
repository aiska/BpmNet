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
    public partial class BPMNDiagram : Diagram
    {
        [XmlElement("BPMNPlane")]
        public BPMNPlane BPMNPlane { get; set; }

        [XmlElement("BPMNLabelStyle")]
        public BPMNLabelStyle[] BPMNLabelStyle { get; set; }
    }
}
