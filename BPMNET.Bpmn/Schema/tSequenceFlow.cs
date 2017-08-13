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
    [XmlRoot("sequenceFlow", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tSequenceFlow : tFlowElement
    {

        private tExpression conditionExpressionField;

        private string sourceRefField;

        private string targetRefField;

        private bool isImmediateField;

        private bool isImmediateFieldSpecified;

        public tExpression conditionExpression
        {
            get
            {
                return conditionExpressionField;
            }
            set
            {
                conditionExpressionField = value;
            }
        }

        [XmlAttribute(DataType = "IDREF")]
        public string sourceRef
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

        [XmlAttribute(DataType = "IDREF")]
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

        [XmlAttribute()]
        public bool isImmediate
        {
            get
            {
                return isImmediateField;
            }
            set
            {
                isImmediateField = value;
            }
        }

        [XmlIgnore()]
        public bool isImmediateSpecified
        {
            get
            {
                return isImmediateFieldSpecified;
            }
            set
            {
                isImmediateFieldSpecified = value;
            }
        }
    }
}
