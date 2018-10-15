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
    [XmlRoot("userTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnUserTask : BpmnTask
    {
        public BpmnUserTask()
        {
            Implementation = "##unspecified";
        }

        [XmlElement("rendering")]
        public BpmnRendering[] Rendering { get; set; }

        [XmlAttribute("implementation")]
        [DefaultValue("##unspecified")]
        public string Implementation { get; set; }

        [XmlAttribute("group", Namespace = "http://www.bpmnet.org/bpmn")]
        public string Group { get; set; }

        [XmlElement("approval", Namespace = "http://www.bpmnet.org/bpmn")]
        public BpmnApproval[] Approval { get; set; }
    }
}
