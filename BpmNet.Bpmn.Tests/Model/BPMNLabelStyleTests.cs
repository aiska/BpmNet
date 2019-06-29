using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
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
