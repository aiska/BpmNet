using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("category", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCategory : BpmnRootElement
    {
        [XmlElement("categoryValue")]
        public BpmnCategoryValue[] CategoryValue { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
