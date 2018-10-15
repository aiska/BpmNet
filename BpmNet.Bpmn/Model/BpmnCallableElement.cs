using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnProcess))]
    [XmlInclude(typeof(BpmnGlobalTask))]
    [XmlInclude(typeof(BpmnGlobalUserTask))]
    [XmlInclude(typeof(BpmnGlobalScriptTask))]
    [XmlInclude(typeof(BpmnGlobalManualTask))]
    [XmlInclude(typeof(BpmnGlobalBusinessRuleTask))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("callableElement", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCallableElement : BpmnRootElement
    {
        [XmlElement("supportedInterfaceRef")]
        public XmlQualifiedName[] SupportedInterfaceRef { get; set; }

        [XmlElement("ioSpecification")]
        public BpmnInputOutputSpecification IoSpecification { get; set; }

        [XmlElement("ioBinding")]
        public BpmnInputOutputBinding[] IoBinding { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
