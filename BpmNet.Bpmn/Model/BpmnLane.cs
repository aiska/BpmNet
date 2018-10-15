using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("lane", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnLane : BpmnBaseElement
    {
        public BpmnBaseElement PartitionElement { get; set; }

        [XmlElement("flowNodeRef", DataType = "IDREF")]
        public string[] FlowNodeRef { get; set; }

        public BpmnLaneSet ChildLaneSet { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("partitionElementRef")]
        public XmlQualifiedName PartitionElementRef { get; set; }
    }
}
