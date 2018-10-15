using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("compensateEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCompensateEventDefinition : BpmnEventDefinition
    {
        [XmlAttribute("waitForCompletion")]
        public bool WaitForCompletion { get; set; }

        [XmlIgnore()]
        public bool WaitForCompletionSpecified { get; set; }

        [XmlAttribute("activityRef")]
        public XmlQualifiedName ActivityRef { get; set; }
    }

}
