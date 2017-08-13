using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(Edge))]
    [XmlInclude(typeof(LabeledEdge))]
    [XmlInclude(typeof(BPMNEdge))]
    [XmlInclude(typeof(Node))]
    [XmlInclude(typeof(Plane))]
    [XmlInclude(typeof(BPMNPlane))]
    [XmlInclude(typeof(Label))]
    [XmlInclude(typeof(BPMNLabel))]
    [XmlInclude(typeof(Shape))]
    [XmlInclude(typeof(LabeledShape))]
    [XmlInclude(typeof(BPMNShape))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class DiagramElement
    {

        private DiagramElementExtension extensionField;

        private string idField;

        private XmlAttribute[] anyAttrField;

            public DiagramElementExtension extension
        {
            get
            {
                return extensionField;
            }
            set
            {
                extensionField = value;
            }
        }

            [XmlAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

            [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr
        {
            get
            {
                return anyAttrField;
            }
            set
            {
                anyAttrField = value;
            }
        }
    }

}
