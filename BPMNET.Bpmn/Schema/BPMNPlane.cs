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
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI", IsNullable = false)]
    public partial class BPMNPlane : Plane
    {

        private XmlQualifiedName bpmnElementField;

            [XmlAttribute()]
        public XmlQualifiedName bpmnElement
        {
            get
            {
                return bpmnElementField;
            }
            set
            {
                bpmnElementField = value;
            }
        }

        private DiagramElement[] diagramElement1Field;

            [XmlElement(typeof(BPMNShape))]
        [XmlElement(typeof(BPMNEdge))]
        public DiagramElement[] DiagramElements
        {
            get
            {
                return diagramElement1Field;
            }
            set
            {
                diagramElement1Field = value;
            }
        }
    }

}
