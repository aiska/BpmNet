using System;
using System.Diagnostics;
using System.Xml.Serialization;
namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("conditionalEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnConditionalEventDefinition : BpmnEventDefinition
    {
        [XmlElement("condition")]
        public BpmnExpression Condition { get; set; }
    }

}
