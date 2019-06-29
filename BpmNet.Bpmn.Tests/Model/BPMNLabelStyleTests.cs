using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNLabelStyleStyleTests
    {
        [Fact]
        public void BPMNLabelStyle_Populate()
        {
            BPMNLabelStyle labelStyle = new BPMNLabelStyle
            {
                Font = new Font()
            };
            Assert.NotNull(labelStyle.Font);
        }
    }
}
