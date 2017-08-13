using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("ioSpecification", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tInputOutputSpecification : tBaseElement
    {

        private tDataInput[] dataInputField;

        private tDataOutput[] dataOutputField;

        private tInputSet[] inputSetField;

        private tOutputSet[] outputSetField;

        [XmlElement("dataInput")]
        public tDataInput[] dataInput
        {
            get
            {
                return dataInputField;
            }
            set
            {
                dataInputField = value;
            }
        }

        [XmlElement("dataOutput")]
        public tDataOutput[] dataOutput
        {
            get
            {
                return dataOutputField;
            }
            set
            {
                dataOutputField = value;
            }
        }

        [XmlElement("inputSet")]
        public tInputSet[] inputSet
        {
            get
            {
                return inputSetField;
            }
            set
            {
                inputSetField = value;
            }
        }

        [XmlElement("outputSet")]
        public tOutputSet[] outputSet
        {
            get
            {
                return outputSetField;
            }
            set
            {
                outputSetField = value;
            }
        }
    }
}
