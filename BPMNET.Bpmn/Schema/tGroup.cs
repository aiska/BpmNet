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
    [XmlRoot("group", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tGroup : tArtifact
    {

        private XmlQualifiedName categoryValueRefField;

            [XmlAttribute()]
        public XmlQualifiedName categoryValueRef
        {
            get
            {
                return categoryValueRefField;
            }
            set
            {
                categoryValueRefField = value;
            }
        }
    }
}
