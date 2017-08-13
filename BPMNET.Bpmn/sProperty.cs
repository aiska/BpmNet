using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.bpmnet.org/bpmn/schema/v1")]
    [XmlRoot("property", Namespace = "http://www.bpmnet.org/bpmn/schema/v1", IsNullable = false)]
    public class sProperty
    {
        [XmlAttribute()]
        public string id { get; set; }
        [XmlAttribute()]
        public string name { get; set; }
        [XmlAttribute()]
        public string label { get; set; }
        [XmlAttribute()]
        public string defaultValue { get; set; }
        [XmlElement()]
        public sValidation[] validation { get; set; }
        [XmlAttribute()]
        public XmlQualifiedName subjectRef { get; set; }
    }
}