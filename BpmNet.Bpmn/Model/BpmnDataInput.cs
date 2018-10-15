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
    [XmlRoot("dataInput", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDataInput : BpmnBaseElement
    {
        public BpmnDataInput()
        {
            IsCollection = false;
        }

        [XmlElement("dataState")]
        public BpmnDataState DataState { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("itemSubjectRef")]
        public XmlQualifiedName ItemSubjectRef { get; set; }

        [XmlAttribute("isCollection")]
        [DefaultValue(false)]
        public bool IsCollection { get; set; }
    }
}
