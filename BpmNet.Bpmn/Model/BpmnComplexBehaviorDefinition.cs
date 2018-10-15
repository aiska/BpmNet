using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("complexBehaviorDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnComplexBehaviorDefinition : BpmnBaseElement
    {
        [XmlElement("condition")]
        public BpmnFormalExpression Condition { get; set; }

        [XmlElement("event")]
        public BpmnImplicitThrowEvent Event { get; set; }
    }

}
