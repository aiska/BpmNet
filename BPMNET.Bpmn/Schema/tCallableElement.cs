using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tProcess))]
    [XmlInclude(typeof(tGlobalTask))]
    [XmlInclude(typeof(tGlobalUserTask))]
    [XmlInclude(typeof(tGlobalScriptTask))]
    [XmlInclude(typeof(tGlobalManualTask))]
    [XmlInclude(typeof(tGlobalBusinessRuleTask))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("callableElement", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCallableElement : tRootElement
    {

        private XmlQualifiedName[] supportedInterfaceRefField;

        private tInputOutputSpecification ioSpecificationField;

        private tInputOutputBinding[] ioBindingField;

        private string nameField;

        [XmlElement("supportedInterfaceRef")]
        public XmlQualifiedName[] supportedInterfaceRef
        {
            get
            {
                return supportedInterfaceRefField;
            }
            set
            {
                supportedInterfaceRefField = value;
            }
        }

        public tInputOutputSpecification ioSpecification
        {
            get
            {
                return ioSpecificationField;
            }
            set
            {
                ioSpecificationField = value;
            }
        }

        [XmlElement("ioBinding")]
        public tInputOutputBinding[] ioBinding
        {
            get
            {
                return ioBindingField;
            }
            set
            {
                ioBindingField = value;
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
    }
}
