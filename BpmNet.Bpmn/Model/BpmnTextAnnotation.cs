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
    [XmlRoot("textAnnotation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnTextAnnotation : BpmnArtifact
    {

        private XmlNode textField;

        private string textFormatField;

        public BpmnTextAnnotation()
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
