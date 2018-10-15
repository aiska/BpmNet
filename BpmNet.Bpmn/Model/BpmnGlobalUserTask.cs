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
    [XmlRoot("globalUserTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnGlobalUserTask : BpmnGlobalTask
    {
        public BpmnGlobalUserTask()
        {
            Implementation = "##unspecified";
        }

        [XmlElement("rendering")]
        public BpmnRendering[] Rendering { get; set; }

        [XmlAttribute("implementation")]
        [DefaultValue("##unspecified")]
        public string Implementation { get; set; }
    }
}
