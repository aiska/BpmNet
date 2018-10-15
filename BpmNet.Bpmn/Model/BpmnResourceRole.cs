using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnPerformer))]
    [XmlInclude(typeof(BpmnHumanPerformer))]
    [XmlInclude(typeof(BpmnPotentialOwner))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("resourceRole", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnResourceRole : BpmnBaseElement
    {
        [XmlElement("resourceAssignmentExpression", typeof(BpmnResourceAssignmentExpression))]
        [XmlElement("resourceParameterBinding", typeof(BpmnResourceParameterBinding))]
        [XmlElement("resourceRef", typeof(XmlQualifiedName))]
        public object[] Items { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

}
