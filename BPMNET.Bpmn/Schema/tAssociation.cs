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
    [XmlRoot("association", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tAssociation : tArtifact
    {

        private XmlQualifiedName sourceRefField;

        private XmlQualifiedName targetRefField;

        private tAssociationDirection associationDirectionField;

        public tAssociation()
        {
            associationDirectionField = tAssociationDirection.None;
        }

            [XmlAttribute()]
        public XmlQualifiedName sourceRef
        {
            get
            {
                return sourceRefField;
            }
            set
            {
                sourceRefField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName targetRef
        {
            get
            {
                return targetRefField;
            }
            set
            {
                targetRefField = value;
            }
        }

            [XmlAttribute()]
        [DefaultValue(tAssociationDirection.None)]
        public tAssociationDirection associationDirection
        {
            get
            {
                return associationDirectionField;
            }
            set
            {
                associationDirectionField = value;
            }
        }
    }
}
