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
    [XmlRoot("lane", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tLane : tBaseElement
    {

        private tBaseElement partitionElementField;

        private string[] flowNodeRefField;

        private tLaneSet childLaneSetField;

        private string nameField;

        private XmlQualifiedName partitionElementRefField;

            public tBaseElement partitionElement
        {
            get
            {
                return partitionElementField;
            }
            set
            {
                partitionElementField = value;
            }
        }

            [XmlElement("flowNodeRef", DataType = "IDREF")]
        public string[] flowNodeRef
        {
            get
            {
                return flowNodeRefField;
            }
            set
            {
                flowNodeRefField = value;
            }
        }

            public tLaneSet childLaneSet
        {
            get
            {
                return childLaneSetField;
            }
            set
            {
                childLaneSetField = value;
            }
        }

            [XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName partitionElementRef
        {
            get
            {
                return partitionElementRefField;
            }
            set
            {
                partitionElementRefField = value;
            }
        }
    }
}
