using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("globalScriptTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnGlobalScriptTask : BpmnGlobalTask
    {
        public XmlNode Script { get; set; }

        [XmlAttribute("scriptLanguage", DataType = "anyURI")]
        public string ScriptLanguage { get; set; }
    }
}
