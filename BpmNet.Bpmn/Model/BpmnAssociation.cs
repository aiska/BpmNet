using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("association", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnAssociation : BpmnArtifact
    {
        public BpmnAssociation()
        {
            AssociationDirection = BpmnAssociationDirection.None;
        }

        [XmlAttribute("sourceRef")]
        public XmlQualifiedName SourceRef { get; set; }

        [XmlAttribute("targetRef")]
        public XmlQualifiedName TargetRef { get; set; }

        [XmlAttribute("associationDirection")]
        [DefaultValue(BpmnAssociationDirection.None)]
        public BpmnAssociationDirection AssociationDirection { get; set; }
    }
}
