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
    [XmlRoot("dataStore", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDataStore : BpmnRootElement
    {
        public BpmnDataStore()
        {
            IsUnlimited = true;
        }

        [XmlElement("dataState")]
        public BpmnDataState DataState { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("capacity", DataType = "integer")]
        public string Capacity { get; set; }

        [XmlAttribute("isUnlimited")]
        [DefaultValue(true)]
        public bool IsUnlimited { get; set; }

        [XmlAttribute("itemSubjectRef")]
        public XmlQualifiedName ItemSubjectRef { get; set; }
    }
}
