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
    [XmlRoot("boundaryEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnBoundaryEvent : BpmnCatchEvent
    {
        public BpmnBoundaryEvent()
        {
            CancelActivity = true;
        }

        [XmlAttribute("cancelActivity")]
        [DefaultValue(true)]
        public bool CancelActivity { get; set; }

        [XmlAttribute("attachedToRef")]
        public XmlQualifiedName AttachedToRef { get; set; }
    }
}
