using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tParallelGateway))]
    [XmlInclude(typeof(tInclusiveGateway))]
    [XmlInclude(typeof(tExclusiveGateway))]
    [XmlInclude(typeof(tEventBasedGateway))]
    [XmlInclude(typeof(tComplexGateway))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    public partial class tGateway : tFlowNode
    {

        private tGatewayDirection gatewayDirectionField;

        public tGateway()
        {
            gatewayDirectionField = tGatewayDirection.Unspecified;
        }

        [XmlAttribute()]
        [DefaultValue(tGatewayDirection.Unspecified)]
        public tGatewayDirection gatewayDirection
        {
            get
            {
                return gatewayDirectionField;
            }
            set
            {
                gatewayDirectionField = value;
            }
        }
    }
}
