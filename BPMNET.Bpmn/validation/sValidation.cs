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
    public abstract class sValidation
    {
        public string id { get; set; }
    }
}