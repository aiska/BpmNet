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
    [XmlRoot("receiveTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnReceiveTask : BpmnTask
    {
        public BpmnReceiveTask()
        {
            Implementation = "##WebService";
            Instantiate = false;
        }

        [XmlAttribute("implementation")]
        [DefaultValue("##WebService")]
        public string Implementation { get; set; }

        [XmlAttribute("instantiate")]
        [DefaultValue(false)]
        public bool Instantiate { get; set; }

        [XmlAttribute("messageRef")]
        public XmlQualifiedName MessageRef { get; set; }

        [XmlAttribute("operationRef")]
        public XmlQualifiedName OperationRef { get; set; }
    }
}
