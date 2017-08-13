using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(BPMNDiagram))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Diagram
    {

        private string nameField;

        private string documentationField;

        private double resolutionField;

        private bool resolutionFieldSpecified;

        private string idField;

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
        public string documentation
        {
            get
            {
                return documentationField;
            }
            set
            {
                documentationField = value;
            }
        }

            [XmlAttribute()]
        public double resolution
        {
            get
            {
                return resolutionField;
            }
            set
            {
                resolutionField = value;
            }
        }

            [XmlIgnore()]
        public bool resolutionSpecified
        {
            get
            {
                return resolutionFieldSpecified;
            }
            set
            {
                resolutionFieldSpecified = value;
            }
        }

            [XmlAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }
}
