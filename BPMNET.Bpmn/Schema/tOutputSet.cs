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
    [XmlRoot("outputSet", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tOutputSet : tBaseElement
    {

        private string[] dataOutputRefsField;

        private string[] optionalOutputRefsField;

        private string[] whileExecutingOutputRefsField;

        private string[] inputSetRefsField;

        private string nameField;

            [XmlElement("dataOutputRefs", DataType = "IDREF")]
        public string[] dataOutputRefs
        {
            get
            {
                return dataOutputRefsField;
            }
            set
            {
                dataOutputRefsField = value;
            }
        }

            [XmlElement("optionalOutputRefs", DataType = "IDREF")]
        public string[] optionalOutputRefs
        {
            get
            {
                return optionalOutputRefsField;
            }
            set
            {
                optionalOutputRefsField = value;
            }
        }

            [XmlElement("whileExecutingOutputRefs", DataType = "IDREF")]
        public string[] whileExecutingOutputRefs
        {
            get
            {
                return whileExecutingOutputRefsField;
            }
            set
            {
                whileExecutingOutputRefsField = value;
            }
        }

            [XmlElement("inputSetRefs", DataType = "IDREF")]
        public string[] inputSetRefs
        {
            get
            {
                return inputSetRefsField;
            }
            set
            {
                inputSetRefsField = value;
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
