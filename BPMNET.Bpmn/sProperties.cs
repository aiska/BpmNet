using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.bpmnet.org/bpmn/schema/v1")]
    [XmlRoot("properties", Namespace = "http://www.bpmnet.org/bpmn/schema/v1", IsNullable = false)]
    public partial class sProperties : sItemObject
    {
        [XmlAttribute()]
        public string id { get; set; }

        [XmlElement("property", typeof(sProperty))]
        public sProperty[] property { get; set; }
    }
}
