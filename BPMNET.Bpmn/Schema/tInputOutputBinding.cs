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
    [XmlRoot("ioBinding", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tInputOutputBinding : tBaseElement
    {

        private XmlQualifiedName operationRefField;

        private string inputDataRefField;

        private string outputDataRefField;

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

            [XmlAttribute(DataType = "IDREF")]
        public string inputDataRef
        {
            get
            {
                return inputDataRefField;
            }
            set
            {
                inputDataRefField = value;
            }
        }

            [XmlAttribute(DataType = "IDREF")]
        public string outputDataRef
        {
            get
            {
                return outputDataRefField;
            }
            set
            {
                outputDataRefField = value;
            }
        }
    }
}
