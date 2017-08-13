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
    public partial class Bounds
    {

        private double xField;

        private double yField;

        private double widthField;

        private double heightField;

            [XmlAttribute()]
        public double x
        {
            get
            {
                return xField;
            }
            set
            {
                xField = value;
            }
        }

            [XmlAttribute()]
        public double y
        {
            get
            {
                return yField;
            }
            set
            {
                yField = value;
            }
        }

            [XmlAttribute()]
        public double width
        {
            get
            {
                return widthField;
            }
            set
            {
                widthField = value;
            }
        }

            [XmlAttribute()]
        public double height
        {
            get
            {
                return heightField;
            }
            set
            {
                heightField = value;
            }
        }
    }
}
