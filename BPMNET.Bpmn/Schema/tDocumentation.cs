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
    [XmlRoot("documentation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tDocumentation
    {

        private XmlNode[] anyField;

        private string idField;

        private string textFormatField;

        public tDocumentation()
        {
            textFormatField = "text/plain";
        }

            [XmlText()]
        [XmlAnyElement()]
        public XmlNode[] Any
        {
            get
            {
                return anyField;
            }
            set
            {
                anyField = value;
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
        [DefaultValue("text/plain")]
        public string textFormat
        {
            get
            {
                return textFormatField;
            }
            set
            {
                textFormatField = value;
            }
        }
    }
}
