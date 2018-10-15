using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("inputSet", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnInputSet : BpmnBaseElement
    {
        [XmlElement("dataInputRefs", DataType = "IDREF")]
        public string[] DataInputRefs { get; set; }

        [XmlElement("optionalInputRefs", DataType = "IDREF")]
        public string[] OptionalInputRefs { get; set; }

        [XmlElement("whileExecutingInputRefs", DataType = "IDREF")]
        public string[] WhileExecutingInputRefs { get; set; }

        [XmlElement("outputSetRefs", DataType = "IDREF")]
        public string[] OutputSetRefs { get; set; }

        [XmlAttribute()]
        public string Name { get; set; }
    }
}
