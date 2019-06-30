using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNShapeTests
    {
        [Fact]
        public void BPMNShape_Populate()
        {
            BpmnShape shape = new BpmnShape
            {
                BPMNLabel = new BpmnLabel(),
                BpmnElement = XmlQualifiedName.Empty,
                IsHorizontal = false,
                IsHorizontalSpecified = false,
                IsExpanded = false,
                IsExpandedSpecified = false,
                IsMarkerVisible = false,
                IsMarkerVisibleSpecified = false,
                IsMessageVisible = false,
                IsMessageVisibleSpecified = false,
                ParticipantBandKind = ParticipantBandKind.bottom_initiating,
                ParticipantBandKindSpecified = false,
                ChoreographyActivityShape = XmlQualifiedName.Empty
            };
            Assert.NotNull(shape.BPMNLabel);
            Assert.NotNull(shape.BpmnElement);
            Assert.False(shape.IsHorizontal);
            Assert.False(shape.IsHorizontalSpecified);
            Assert.False(shape.IsExpanded);
            Assert.False(shape.IsExpandedSpecified);
            Assert.False(shape.IsMarkerVisible);
            Assert.False(shape.IsMarkerVisibleSpecified);
            Assert.False(shape.IsMessageVisible);
            Assert.False(shape.IsMessageVisibleSpecified);
            Assert.Equal(ParticipantBandKind.bottom_initiating, shape.ParticipantBandKind);
            Assert.False(shape.ParticipantBandKindSpecified);
            Assert.NotNull(shape.ChoreographyActivityShape);
        }
    }
}
