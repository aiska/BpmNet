using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnExpression))]
    [XmlInclude(typeof(BpmnFormalExpression))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("baseElementWithMixedContent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnBaseElementWithMixedContent
    {
        [XmlElement("documentation")]
        public BpmnDocumentation[] Documentation { get; set; }

        public BpmnExtensionElements ExtensionElements { get; set; }

        [XmlText()]
        public string[] Text { get; set; }

        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr { get; set; }
    }

}
