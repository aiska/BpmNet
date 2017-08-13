using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tGateway))]
    [XmlInclude(typeof(tParallelGateway))]
    [XmlInclude(typeof(tInclusiveGateway))]
    [XmlInclude(typeof(tExclusiveGateway))]
    [XmlInclude(typeof(tEventBasedGateway))]
    [XmlInclude(typeof(tComplexGateway))]
    [XmlInclude(typeof(tChoreographyActivity))]
    [XmlInclude(typeof(tSubChoreography))]
    [XmlInclude(typeof(tChoreographyTask))]
    [XmlInclude(typeof(tCallChoreography))]
    [XmlInclude(typeof(tEvent))]
    [XmlInclude(typeof(tThrowEvent))]
    [XmlInclude(typeof(tIntermediateThrowEvent))]
    [XmlInclude(typeof(tImplicitThrowEvent))]
    [XmlInclude(typeof(tEndEvent))]
    [XmlInclude(typeof(tCatchEvent))]
    [XmlInclude(typeof(tStartEvent))]
    [XmlInclude(typeof(tIntermediateCatchEvent))]
    [XmlInclude(typeof(tBoundaryEvent))]
    [XmlInclude(typeof(tActivity))]
    [XmlInclude(typeof(tTask))]
    [XmlInclude(typeof(tUserTask))]
    [XmlInclude(typeof(tServiceTask))]
    [XmlInclude(typeof(tSendTask))]
    [XmlInclude(typeof(tScriptTask))]
    [XmlInclude(typeof(tReceiveTask))]
    [XmlInclude(typeof(tManualTask))]
    [XmlInclude(typeof(tBusinessRuleTask))]
    [XmlInclude(typeof(tSubProcess))]
    [XmlInclude(typeof(tTransaction))]
    [XmlInclude(typeof(tAdHocSubProcess))]
    [XmlInclude(typeof(tCallActivity))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("flowNode", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tFlowNode : tFlowElement
    {

        private XmlQualifiedName[] incomingField;

        private XmlQualifiedName[] outgoingField;

        [XmlElement("incoming")]
        public XmlQualifiedName[] incoming
        {
            get
            {
                return incomingField;
            }
            set
            {
                incomingField = value;
            }
        }

        [XmlElement("outgoing")]
        public XmlQualifiedName[] outgoing
        {
            get
            {
                return outgoingField;
            }
            set
            {
                outgoingField = value;
            }
        }
    }

}
