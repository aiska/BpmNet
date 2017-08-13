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
    [XmlRoot("extension", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tExtension
    {

        private tDocumentation[] documentationField;

        private XmlQualifiedName definitionField;

        private bool mustUnderstandField;

        public tExtension()
        {
            mustUnderstandField = false;
        }

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

            [XmlAttribute()]
        public XmlQualifiedName definition
        {
            get
            {
                return definitionField;
            }
            set
            {
                definitionField = value;
            }
        }

            [XmlAttribute()]
        [DefaultValue(false)]
        public bool mustUnderstand
        {
            get
            {
                return mustUnderstandField;
            }
            set
            {
                mustUnderstandField = value;
            }
        }
    }
}
