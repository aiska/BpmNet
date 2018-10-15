using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("ioBinding", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnInputOutputBinding : BpmnBaseElement
    {
        [XmlAttribute("operationRef")]
        public XmlQualifiedName OperationRef { get; set; }

        [XmlAttribute("inputDataRef", DataType = "IDREF")]
        public string InputDataRef { get; set; }

        [XmlAttribute("outputDataRef", DataType = "IDREF")]
        public string OutputDataRef { get; set; }
    }
}
