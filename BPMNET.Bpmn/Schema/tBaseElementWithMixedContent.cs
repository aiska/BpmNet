using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tExpression))]
    [XmlInclude(typeof(tFormalExpression))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("baseElementWithMixedContent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tBaseElementWithMixedContent
    {

        private tDocumentation[] documentationField;

        private tExtensionElements extensionElementsField;

        private string[] textField;

        private string idField;

        private XmlAttribute[] anyAttrField;

        [XmlElement("documentation")]
        public tDocumentation[] documentation
        {
            get
            {
                return documentationField;
            }
            set
            {
                documentationField = value;
            }
        }

        public tExtensionElements extensionElements
        {
            get
            {
                return extensionElementsField;
            }
            set
            {
                extensionElementsField = value;
            }
        }

        [XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
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
