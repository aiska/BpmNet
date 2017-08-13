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
    [XmlRoot("transaction", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tTransaction : tSubProcess
    {

        private string methodField;

        public tTransaction()
        {
            methodField = "##Compensate";
        }

            [XmlAttribute()]
        [DefaultValue("##Compensate")]
        public string method
        {
            get
            {
                return methodField;
            }
            set
            {
                methodField = value;
            }
        }
    }
}
