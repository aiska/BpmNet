using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("dataStoreReference", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDataStoreReference : BpmnFlowElement
    {
        [XmlElement("dataState")]
        public BpmnDataState DataState { get; set; }

        [XmlAttribute("itemSubjectRef")]
        public XmlQualifiedName ItemSubjectRef { get; set; }

        [XmlAttribute("dataStoreRef")]
        public XmlQualifiedName DataStoreRef { get; set; }
    }
}
