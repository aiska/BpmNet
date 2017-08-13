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
    [XmlRoot("participantMultiplicity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tParticipantMultiplicity : tBaseElement
    {

        private int minimumField;

        private int maximumField;

        public tParticipantMultiplicity()
        {
            minimumField = 0;
            maximumField = 1;
        }

            [XmlAttribute()]
        [DefaultValue(0)]
        public int minimum
        {
            get
            {
                return minimumField;
            }
            set
            {
                minimumField = value;
            }
        }

            [XmlAttribute()]
        [DefaultValue(1)]
        public int maximum
        {
            get
            {
                return maximumField;
            }
            set
            {
                maximumField = value;
            }
        }
    }
}
