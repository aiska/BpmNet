using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("extension", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnExtension
    {
        public BpmnExtension()
        {
            MustUnderstand = false;
        }

        [XmlElement("documentation")]
        public BpmnDocumentation[] Documentation { get; set; }

        [XmlAttribute("definition")]
        public XmlQualifiedName Definition { get; set; }

        [XmlAttribute("mustUnderstand")]
        [DefaultValue(false)]
        public bool MustUnderstand { get; set; }
    }
}
