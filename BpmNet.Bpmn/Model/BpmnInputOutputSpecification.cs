using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("ioSpecification", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnInputOutputSpecification : BpmnBaseElement
    {
        [XmlElement("dataInput")]
        public BpmnDataInput[] DataInput { get; set; }

        [XmlElement("dataOutput")]
        public BpmnDataOutput[] DataOutput { get; set; }

        [XmlElement("inputSet")]
        public BpmnInputSet[] InputSet { get; set; }

        [XmlElement("outputSet")]
        public BpmnOutputSet[] OutputSet { get; set; }
    }
}
