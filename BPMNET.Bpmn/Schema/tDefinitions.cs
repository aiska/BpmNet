using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("definitions", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tDefinitions
    {

        private tImport[] importField;

        private tExtension[] extensionField;

        private tRootElement[] itemsField;

        private BPMNDiagram[] bPMNDiagramField;

        private tRelationship[] relationshipField;

        private string idField;

        private string nameField;

        private string targetNamespaceField;

        private string expressionLanguageField;

        private string typeLanguageField;

        private string exporterField;

        private string exporterVersionField;

        private XmlAttribute[] anyAttrField;

        public tDefinitions()
        {
            expressionLanguageField = "http://www.w3.org/1999/XPath";
            typeLanguageField = "http://www.w3.org/2001/XMLSchema";
        }

        [XmlElement("import")]
        public tImport[] import
        {
            get
            {
                return importField;
            }
            set
            {
                importField = value;
            }
        }

        [XmlElement("extension")]
        public tExtension[] extension
        {
            get
            {
                return extensionField;
            }
            set
            {
                extensionField = value;
            }
        }

        [XmlElement("category", typeof(tCategory))]
        [XmlElement("collaboration", typeof(tCollaboration))]
        [XmlElement("correlationProperty", typeof(tCorrelationProperty))]
        [XmlElement("dataStore", typeof(tDataStore))]
        [XmlElement("endPoint", typeof(tEndPoint))]
        [XmlElement("error", typeof(tError))]
        [XmlElement("escalation", typeof(tEscalation))]
        [XmlElement("eventDefinition", typeof(tEventDefinition))]
        [XmlElement("globalBusinessRuleTask", typeof(tGlobalBusinessRuleTask))]
        [XmlElement("globalManualTask", typeof(tGlobalManualTask))]
        [XmlElement("globalScriptTask", typeof(tGlobalScriptTask))]
        [XmlElement("globalTask", typeof(tGlobalTask))]
        [XmlElement("globalUserTask", typeof(tGlobalUserTask))]
        [XmlElement("interface", typeof(tInterface))]
        [XmlElement("itemDefinition", typeof(tItemDefinition))]
        [XmlElement("message", typeof(tMessage))]
        [XmlElement("partnerEntity", typeof(tPartnerEntity))]
        [XmlElement("partnerRole", typeof(tPartnerRole))]
        [XmlElement("process", typeof(tProcess))]
        [XmlElement("resource", typeof(tResource))]
        [XmlElement("rootElement", typeof(tRootElement))]
        [XmlElement("signal", typeof(tSignal))]
        public tRootElement[] Items
        {
            get
            {
                return itemsField;
            }
            set
            {
                itemsField = value;
            }
        }

        [XmlElement("BPMNDiagram", Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
        public BPMNDiagram[] BPMNDiagram
        {
            get
            {
                return bPMNDiagramField;
            }
            set
            {
                bPMNDiagramField = value;
            }
        }

        [XmlElement("relationship")]
        public tRelationship[] relationship
        {
            get
            {
                return relationshipField;
            }
            set
            {
                relationshipField = value;
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        [XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        public string targetNamespace
        {
            get
            {
                return targetNamespaceField;
            }
            set
            {
                targetNamespaceField = value;
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        [DefaultValue("http://www.w3.org/1999/XPath")]
        public string expressionLanguage
        {
            get
            {
                return expressionLanguageField;
            }
            set
            {
                expressionLanguageField = value;
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        [DefaultValue("http://www.w3.org/2001/XMLSchema")]
        public string typeLanguage
        {
            get
            {
                return typeLanguageField;
            }
            set
            {
                typeLanguageField = value;
            }
        }

        [XmlAttribute()]
        public string exporter
        {
            get
            {
                return exporterField;
            }
            set
            {
                exporterField = value;
            }
        }

        [XmlAttribute()]
        public string exporterVersion
        {
            get
            {
                return exporterVersionField;
            }
            set
            {
                exporterVersionField = value;
            }
        }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr
        {
            get
            {
                return anyAttrField;
            }
            set
            {
                anyAttrField = value;
            }
        }
    }
}
