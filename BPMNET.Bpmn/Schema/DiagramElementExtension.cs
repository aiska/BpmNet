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
    [XmlType(AnonymousType = true, Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    public partial class DiagramElementExtension
    {

        private XmlElement[] anyField;

            [XmlAnyElement()]
        public XmlElement[] Any
        {
            get
            {
                return anyField;
            }
            set
            {
                anyField = value;
            }
        }
    }
}
