using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("scriptTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnScriptTask : BpmnTask
    {
        [XmlElement("script")]
        public XmlNode Script { get; set; }

        [XmlAttribute("scriptFormat")]
        public string ScriptFormat { get; set; }
    }
}
