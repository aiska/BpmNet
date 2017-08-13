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
    [XmlRoot("eventBasedGateway", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tEventBasedGateway : tGateway
    {

        private bool instantiateField;

        private tEventBasedGatewayType eventGatewayTypeField;

        public tEventBasedGateway()
        {
            instantiateField = false;
            eventGatewayTypeField = tEventBasedGatewayType.Exclusive;
        }

            [XmlAttribute()]
        [DefaultValue(false)]
        public bool instantiate
        {
            get
            {
                return instantiateField;
            }
            set
            {
                instantiateField = value;
            }
        }

            [XmlAttribute()]
        [DefaultValue(tEventBasedGatewayType.Exclusive)]
        public tEventBasedGatewayType eventGatewayType
        {
            get
            {
                return eventGatewayTypeField;
            }
            set
            {
                eventGatewayTypeField = value;
            }
        }
    }
}
