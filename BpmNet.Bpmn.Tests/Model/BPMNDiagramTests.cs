using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNDiagramTests
    {
        [Fact]
        public void BPMNDiagram_Populate()
        {
            BPMNDiagram diagram = new BPMNDiagram {
                BPMNPlane = new BPMNPlane (),
                BPMNLabelStyle = new BPMNLabelStyle[0] { }
            };
            Assert.NotNull(diagram.BPMNPlane);
            Assert.NotNull(diagram.BPMNLabelStyle);
        }
    }
}
