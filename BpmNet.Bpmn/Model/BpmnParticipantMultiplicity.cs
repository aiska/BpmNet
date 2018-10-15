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
    [XmlRoot("participantMultiplicity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnParticipantMultiplicity : BpmnBaseElement
    {
        public BpmnParticipantMultiplicity()
        {
            Minimum = 0;
            Maximum = 1;
        }

        [XmlAttribute("minimum")]
        [DefaultValue(0)]
        public int Minimum { get; set; }

        [XmlAttribute("maximum")]
        [DefaultValue(1)]
        public int Maximum { get; set; }
    }
}
