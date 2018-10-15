using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DC")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DC", IsNullable = false)]
    public partial class Font
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("size")]
        public double Size { get; set; }

        [XmlIgnore()]
        public bool SizeSpecified { get; set; }

        [XmlAttribute("isBold")]
        public bool IsBold { get; set; }

        [XmlIgnore()]
        public bool IsBoldSpecified { get; set; }

        [XmlAttribute("isItalic")]
        public bool IsItalic { get; set; }

        [XmlIgnore()]
        public bool IsItalicSpecified { get; set; }

        [XmlAttribute("isUnderline")]
        public bool IsUnderline { get; set; }

        [XmlIgnore()]
        public bool IsUnderlineSpecified { get; set; }

        [XmlAttribute("isStrikeThrough")]
        public bool IsStrikeThrough { get; set; }

        [XmlIgnore()]
        public bool IsStrikeThroughSpecified { get; set; }
    }
}
