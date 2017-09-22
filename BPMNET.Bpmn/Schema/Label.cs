using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(BPMNLabel))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Label : Node
    {

        private Bounds boundsField;

        [XmlElement(Namespace = "http://www.omg.org/spec/DD/20100524/DC")]
        public Bounds Bounds
        {
            get
            {
                return boundsField;
            }
            set
            {
                boundsField = value;
            }
        }
    }

}
