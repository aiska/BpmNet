using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("sequenceFlow", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnSequenceFlow : BpmnFlowElement
    {
        [XmlElement("conditionExpression", typeof(BpmnFormalExpression))]
        public BpmnExpression ConditionExpression { get; set; }

        [XmlAttribute("sourceRef", DataType = "IDREF")]
        public string SourceRef { get; set; }

        [XmlAttribute("targetRef", DataType = "IDREF")]
        public string TargetRef { get; set; }

        [XmlAttribute("isImmediate")]
        public bool IsImmediate { get; set; }

        [XmlIgnore()]
        public bool IsImmediateSpecified { get; set; }
    }
}
