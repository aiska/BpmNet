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
    [XmlRoot("startEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnStartEvent : BpmnCatchEvent
    {
        public BpmnStartEvent()
        {
            IsInterrupting = true;
        }

        [XmlAttribute("isInterrupting")]
        [DefaultValue(true)]
        public bool IsInterrupting { get; set; }
    }
}
