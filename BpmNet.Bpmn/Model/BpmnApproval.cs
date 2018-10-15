using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.bpmnet.org/bpmn")]
    [XmlRoot("approval", Namespace = "http://www.bpmnet.org/bpmn", IsNullable = false)]
    public partial class BpmnApproval
    {
        [XmlAttribute("Assignee")]
        public string Assignee { get; set; }
        [XmlAttribute("Group", Namespace = "http://www.bpmnet.org/bpmn")]
        public string Group { get; set; }
        [XmlAttribute("Level")]
        public int Level { get; set; }
        [XmlAttribute("Order")]
        public int Order { get; set; }
        [XmlAttribute("Criteria")]
        public string Criteria { get; set; }
    }
}
