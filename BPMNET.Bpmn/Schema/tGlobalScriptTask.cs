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
    [XmlRoot("globalScriptTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tGlobalScriptTask : tGlobalTask
    {

        private XmlNode scriptField;

        private string scriptLanguageField;

            public XmlNode script
        {
            get
            {
                return scriptField;
            }
            set
            {
                scriptField = value;
            }
        }

            [XmlAttribute(DataType = "anyURI")]
        public string scriptLanguage
        {
            get
            {
                return scriptLanguageField;
            }
            set
            {
                scriptLanguageField = value;
            }
        }
    }
}
