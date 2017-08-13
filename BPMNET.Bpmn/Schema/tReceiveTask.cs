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
    [XmlRoot("receiveTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tReceiveTask : tTask
    {

        private string implementationField;

        private bool instantiateField;

        private XmlQualifiedName messageRefField;

        private XmlQualifiedName operationRefField;

        public tReceiveTask()
        {
            implementationField = "##WebService";
            instantiateField = false;
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
        [DefaultValue(false)]
        public bool instantiate
        {
            get
            {
                return instantiateField;
            }
            set
            {
                instantiateField = value;
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
