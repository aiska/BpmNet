using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("laneSet", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnLaneSet : BpmnBaseElement
    {
        [XmlElement("lane")]
        public BpmnLane[] Lane { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
