using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("outputSet", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnOutputSet : BpmnBaseElement
    {
        [XmlElement("dataOutputRefs", DataType = "IDREF")]
        public string[] DataOutputRefs { get; set; }

        [XmlElement("optionalOutputRefs", DataType = "IDREF")]
        public string[] OptionalOutputRefs { get; set; }

        [XmlElement("whileExecutingOutputRefs", DataType = "IDREF")]
        public string[] WhileExecutingOutputRefs { get; set; }

        [XmlElement("inputSetRefs", DataType = "IDREF")]
        public string[] InputSetRefs { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
