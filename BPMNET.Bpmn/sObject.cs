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
    [XmlRoot("object", Namespace = "http://www.bpmnet.org/bpmn/schema/v1", IsNullable = false)]
    public class sObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public sItemObject[] items { get; set; }
    }
}
