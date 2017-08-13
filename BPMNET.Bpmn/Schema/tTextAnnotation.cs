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
    [XmlRoot("textAnnotation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tTextAnnotation : tArtifact
    {

        private XmlNode textField;

        private string textFormatField;

        public tTextAnnotation()
        {
            textFormatField = "text/plain";
        }

            public XmlNode text
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
