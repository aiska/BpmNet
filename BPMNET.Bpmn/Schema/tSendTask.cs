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
    [XmlRoot("sendTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tSendTask : tTask
    {

        private string implementationField;

        private XmlQualifiedName messageRefField;

        private XmlQualifiedName operationRefField;

        public tSendTask()
        {
            implementationField = "##WebService";
        }

            [XmlAttribute()]
        [DefaultValue("##WebService")]
        public string implementation
        {
            get
            {
                return implementationField;
            }
            set
            {
                implementationField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName messageRef
        {
            get
            {
                return messageRefField;
            }
            set
            {
                messageRefField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName operationRef
        {
            get
            {
                return operationRefField;
            }
            set
            {
                operationRefField = value;
            }
        }
    }
}
