using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNEdgeTests
    {
        [Fact]
        public void BPMNEdge_Populate()
        {
            BpmnEdge edge = new BpmnEdge
            {
                BPMNLabel = new BpmnLabel(),
                BpmnElement = XmlQualifiedName.Empty,
                SourceElement = XmlQualifiedName.Empty,
                TargetElement = XmlQualifiedName.Empty,
                MessageVisibleKind = MessageVisibleKind.initiating,
                MessageVisibleKindSpecified = false
            };
            Assert.NotNull(edge.BPMNLabel);
            Assert.NotNull(edge.BpmnElement);
            Assert.NotNull(edge.SourceElement);
            Assert.NotNull(edge.TargetElement);
            Assert.Equal(MessageVisibleKind.initiating, edge.MessageVisibleKind);
            Assert.False(edge.MessageVisibleKindSpecified);
        }
    }
}
