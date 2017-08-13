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
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DC")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DC", IsNullable = false)]
    public partial class Font
    {

        private string nameField;

        private double sizeField;

        private bool sizeFieldSpecified;

        private bool isBoldField;

        private bool isBoldFieldSpecified;

        private bool isItalicField;

        private bool isItalicFieldSpecified;

        private bool isUnderlineField;

        private bool isUnderlineFieldSpecified;

        private bool isStrikeThroughField;

        private bool isStrikeThroughFieldSpecified;

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
        public double size
        {
            get
            {
                return sizeField;
            }
            set
            {
                sizeField = value;
            }
        }

            [XmlIgnore()]
        public bool sizeSpecified
        {
            get
            {
                return sizeFieldSpecified;
            }
            set
            {
                sizeFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isBold
        {
            get
            {
                return isBoldField;
            }
            set
            {
                isBoldField = value;
            }
        }

            [XmlIgnore()]
        public bool isBoldSpecified
        {
            get
            {
                return isBoldFieldSpecified;
            }
            set
            {
                isBoldFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isItalic
        {
            get
            {
                return isItalicField;
            }
            set
            {
                isItalicField = value;
            }
        }

            [XmlIgnore()]
        public bool isItalicSpecified
        {
            get
            {
                return isItalicFieldSpecified;
            }
            set
            {
                isItalicFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isUnderline
        {
            get
            {
                return isUnderlineField;
            }
            set
            {
                isUnderlineField = value;
            }
        }

            [XmlIgnore()]
        public bool isUnderlineSpecified
        {
            get
            {
                return isUnderlineFieldSpecified;
            }
            set
            {
                isUnderlineFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isStrikeThrough
        {
            get
            {
                return isStrikeThroughField;
            }
            set
            {
                isStrikeThroughField = value;
            }
        }

            [XmlIgnore()]
        public bool isStrikeThroughSpecified
        {
            get
            {
                return isStrikeThroughFieldSpecified;
            }
            set
            {
                isStrikeThroughFieldSpecified = value;
            }
        }
    }
}
