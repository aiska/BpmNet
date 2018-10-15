using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnGlobalUserTask))]
    [XmlInclude(typeof(BpmnGlobalScriptTask))]
    [XmlInclude(typeof(BpmnGlobalManualTask))]
    [XmlInclude(typeof(BpmnGlobalBusinessRuleTask))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("globalTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnGlobalTask : BpmnCallableElement
    {

        [XmlElement("performer", typeof(BpmnPerformer))]
        [XmlElement("resourceRole", typeof(BpmnResourceRole))]
        public BpmnResourceRole[] Items { get; set; }
    }
}
