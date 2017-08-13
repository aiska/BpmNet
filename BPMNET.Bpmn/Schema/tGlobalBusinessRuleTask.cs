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
    [XmlRoot("globalBusinessRuleTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tGlobalBusinessRuleTask : tGlobalTask
    {

        private string implementationField;

        public tGlobalBusinessRuleTask()
        {
            implementationField = "##unspecified";
        }

            [XmlAttribute()]
        [DefaultValue("##unspecified")]
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
    }
}
