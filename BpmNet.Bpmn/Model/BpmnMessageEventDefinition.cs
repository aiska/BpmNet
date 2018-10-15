using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("messageEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnMessageEventDefinition : BpmnEventDefinition
    {
        [XmlAttribute("operationRef")]
        public XmlQualifiedName OperationRef { get; set; }

        [XmlAttribute("messageRef")]
        public XmlQualifiedName MessageRef { get; set; }
    }
}