using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.bpmnet.org/bpmn")]
    [XmlRoot("approval", Namespace = "http://www.bpmnet.org/bpmn", IsNullable = false)]
    public partial class tApproval
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
