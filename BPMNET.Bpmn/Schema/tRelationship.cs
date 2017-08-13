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
    [XmlRoot("relationship", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tRelationship : tBaseElement
    {

        private XmlQualifiedName[] sourceField;

        private XmlQualifiedName[] targetField;

        private string typeField;

        private tRelationshipDirection directionField;

        private bool directionFieldSpecified;

            [XmlElement("source")]
        public XmlQualifiedName[] source
        {
            get
            {
                return sourceField;
            }
            set
            {
                sourceField = value;
            }
        }

            [XmlElement("target")]
        public XmlQualifiedName[] target
        {
            get
            {
                return targetField;
            }
            set
            {
                targetField = value;
            }
        }

            [XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

            [XmlAttribute()]
        public tRelationshipDirection direction
        {
            get
            {
                return directionField;
            }
            set
            {
                directionField = value;
            }
        }

            [XmlIgnore()]
        public bool directionSpecified
        {
            get
            {
                return directionFieldSpecified;
            }
            set
            {
                directionFieldSpecified = value;
            }
        }
    }
}
