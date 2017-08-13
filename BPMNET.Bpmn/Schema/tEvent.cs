using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tThrowEvent))]
    [XmlInclude(typeof(tIntermediateThrowEvent))]
    [XmlInclude(typeof(tImplicitThrowEvent))]
    [XmlInclude(typeof(tEndEvent))]
    [XmlInclude(typeof(tCatchEvent))]
    [XmlInclude(typeof(tStartEvent))]
    [XmlInclude(typeof(tIntermediateCatchEvent))]
    [XmlInclude(typeof(tBoundaryEvent))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("event", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tEvent : tFlowNode
    {

        private tProperty[] propertyField;

            [XmlElement("property")]
        public tProperty[] property
        {
            get
            {
                return propertyField;
            }
            set
            {
                propertyField = value;
            }
        }
    }

}
