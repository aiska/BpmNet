using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("complexGateway", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnComplexGateway : BpmnGateway
    {
        [XmlElement("activationCondition")]
        public BpmnExpression ActivationCondition { get; set; }

        [XmlAttribute("default", DataType = "IDREF")]
        public string Default { get; set; }
    }
}
