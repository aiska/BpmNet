using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tDataOutputAssociation))]
    [XmlInclude(typeof(tDataInputAssociation))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("dataAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tDataAssociation : tBaseElement
    {

        private string[] sourceRefField;

        private string targetRefField;

        private tFormalExpression transformationField;

        private tAssignment[] assignmentField;

        [XmlElement("sourceRef", DataType = "IDREF")]
        public string[] sourceRef
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

        [XmlElement(DataType = "IDREF")]
        public string targetRef
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

        public tFormalExpression transformation
        {
            get
            {
                return transformationField;
            }
            set
            {
                transformationField = value;
            }
        }

        [XmlElement("assignment")]
        public tAssignment[] assignment
        {
            get
            {
                return assignmentField;
            }
            set
            {
                assignmentField = value;
            }
        }
    }

}
