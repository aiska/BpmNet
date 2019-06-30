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
    [XmlRoot("definitions", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnDefinitions
    {
        public BpmnDefinitions()
        {
            ExpressionLanguage = "http://www.w3.org/1999/XPath";
            TypeLanguage = "http://www.w3.org/2001/XMLSchema";
        }

        [XmlElement("import")]
        public BpmnImport[] Import { get; set; }

        [XmlElement("extension")]
        public BpmnExtension[] Extension { get; set; }

        [XmlElement("category", typeof(BpmnCategory))]
        [XmlElement("collaboration", typeof(BpmnCollaboration))]
        [XmlElement("correlationProperty", typeof(BpmnCorrelationProperty))]
        [XmlElement("dataStore", typeof(BpmnDataStore))]
        [XmlElement("endPoint", typeof(BpmnEndPoint))]
        [XmlElement("error", typeof(BpmnError))]
        [XmlElement("escalation", typeof(BpmnEscalation))]
        [XmlElement("eventDefinition", typeof(BpmnEventDefinition))]
        [XmlElement("globalBusinessRuleTask", typeof(BpmnGlobalBusinessRuleTask))]
        [XmlElement("globalManualTask", typeof(BpmnGlobalManualTask))]
        [XmlElement("globalScriptTask", typeof(BpmnGlobalScriptTask))]
        [XmlElement("globalTask", typeof(BpmnGlobalTask))]
        [XmlElement("globalUserTask", typeof(BpmnGlobalUserTask))]
        [XmlElement("interface", typeof(BpmnInterface))]
        [XmlElement("itemDefinition", typeof(BpmnItemDefinition))]
        [XmlElement("message", typeof(BpmnMessage))]
        [XmlElement("partnerEntity", typeof(BpmnPartnerEntity))]
        [XmlElement("partnerRole", typeof(BpmnPartnerRole))]
        [XmlElement("process", typeof(BpmnProcess))]
        [XmlElement("resource", typeof(BpmnResource))]
        [XmlElement("rootElement", typeof(BpmnRootElement))]
        [XmlElement("signal", typeof(BpmnSignal))]
        public BpmnRootElement[] Items { get; set; }

        [XmlElement("BPMNDiagram", Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
        public BpmnDiagram[] BPMNDiagram { get; set; }

        [XmlElement("relationship")]
        public BpmnRelationship[] Relationship { get; set; }

        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("targetNamespace", DataType = "anyURI")]
        public string TargetNamespace { get; set; }

        [XmlAttribute("expressionLanguage", DataType = "anyURI")]
        [DefaultValue("http://www.w3.org/1999/XPath")]
        public string ExpressionLanguage { get; set; }

        [XmlAttribute("typeLanguage", DataType = "anyURI")]
        [DefaultValue("http://www.w3.org/2001/XMLSchema")]
        public string TypeLanguage { get; set; }

        [XmlAttribute("exporter")]
        public string Exporter { get; set; }

        [XmlAttribute("exporterVersion")]
        public string ExporterVersion { get; set; }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr { get; set; }
    }
}
