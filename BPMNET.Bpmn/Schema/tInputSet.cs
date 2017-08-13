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
    [XmlRoot("inputSet", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tInputSet : tBaseElement
    {

        private string[] dataInputRefsField;

        private string[] optionalInputRefsField;

        private string[] whileExecutingInputRefsField;

        private string[] outputSetRefsField;

        private string nameField;

        [XmlElement("dataInputRefs", DataType = "IDREF")]
        public string[] dataInputRefs
        {
            get
            {
                return dataInputRefsField;
            }
            set
            {
                dataInputRefsField = value;
            }
        }

        [XmlElement("optionalInputRefs", DataType = "IDREF")]
        public string[] optionalInputRefs
        {
            get
            {
                return optionalInputRefsField;
            }
            set
            {
                optionalInputRefsField = value;
            }
        }

        [XmlElement("whileExecutingInputRefs", DataType = "IDREF")]
        public string[] whileExecutingInputRefs
        {
            get
            {
                return whileExecutingInputRefsField;
            }
            set
            {
                whileExecutingInputRefsField = value;
            }
        }

        [XmlElement("outputSetRefs", DataType = "IDREF")]
        public string[] outputSetRefs
        {
            get
            {
                return outputSetRefsField;
            }
            set
            {
                outputSetRefsField = value;
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
