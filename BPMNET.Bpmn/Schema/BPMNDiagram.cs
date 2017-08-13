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
    public partial class BPMNDiagram : Diagram
    {

        private BPMNPlane bPMNPlaneField;

        private BPMNLabelStyle[] bPMNLabelStyleField;

            public BPMNPlane BPMNPlane
        {
            get
            {
                return bPMNPlaneField;
            }
            set
            {
                bPMNPlaneField = value;
            }
        }

            [XmlElement("BPMNLabelStyle")]
        public BPMNLabelStyle[] BPMNLabelStyle
        {
            get
            {
                return bPMNLabelStyleField;
            }
            set
            {
                bPMNLabelStyleField = value;
            }
        }
    }
}
