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
    [XmlRoot("import", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tImport
    {

        private string namespaceField;

        private string locationField;

        private string importTypeField;

            [XmlAttribute(DataType = "anyURI")]
        public string @namespace
        {
            get
            {
                return namespaceField;
            }
            set
            {
                namespaceField = value;
            }
        }

            [XmlAttribute()]
        public string location
        {
            get
            {
                return locationField;
            }
            set
            {
                locationField = value;
            }
        }

            [XmlAttribute(DataType = "anyURI")]
        public string importType
        {
            get
            {
                return importTypeField;
            }
            set
            {
                importTypeField = value;
            }
        }
    }
}
