using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnDataOutputAssociation))]
    [XmlInclude(typeof(BpmnDataInputAssociation))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("dataAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDataAssociation : BpmnBaseElement
    {
        [XmlElement("sourceRef", DataType = "IDREF")]
        public string[] SourceRef { get; set; }

        [XmlElement("targetRef", DataType = "IDREF")]
        public string TargetRef { get; set; }

        [XmlElement("transformation")]
        public BpmnFormalExpression Transformation { get; set; }

        [XmlElement("assignment")]
        public BpmnAssignment[] Assignment { get; set; }
    }

}
