using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("adHocSubProcess", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnAdHocSubProcess : BpmnSubProcess
    {
        public BpmnAdHocSubProcess()
        {
            CancelRemainingInstances = true;
        }

        public BpmnExpression completionCondition { get; set; }

        [XmlAttribute("cancelRemainingInstances")]
        [DefaultValue(true)]
        public bool CancelRemainingInstances { get; set; }

        [XmlAttribute("ordering")]
        public BpmnAdHocOrdering Ordering { get; set; }

        [XmlIgnore()]
        public bool OrderingSpecified { get; set; }
    }

}
