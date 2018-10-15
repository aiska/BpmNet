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
    [XmlRoot("dataObject", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDataObject : BpmnFlowElement
    {
        public BpmnDataObject()
        {
            IsCollection = false;
        }

        [XmlElement("dataState")]
        public BpmnDataState DataState { get; set; }

        [XmlAttribute("itemSubjectRef")]
        public XmlQualifiedName ItemSubjectRef { get; set; }

        [XmlAttribute("isCollection")]
        [DefaultValue(false)]
        public bool IsCollection { get; set; }
    }
}
