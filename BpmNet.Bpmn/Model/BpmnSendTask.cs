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
    [XmlRoot("sendTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnSendTask : BpmnTask
    {
        public BpmnSendTask()
        {
            Implementation = "##WebService";
        }

        [XmlAttribute("implementation")]
        [DefaultValue("##WebService")]
        public string Implementation { get; set; }

        [XmlAttribute("messageRef")]
        public XmlQualifiedName MessageRef { get; set; }

        [XmlAttribute("operationRef")]
        public XmlQualifiedName OperationRef { get; set; }
    }
}
