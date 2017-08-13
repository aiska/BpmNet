using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestBpmResult
    {
        [TestMethod]
        public void TestSuccess()
        {
            BpmResult result = BpmResult.Success;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeeded);
        }
        [TestMethod]
        public void TestFailed()
        {
            BpmResult result = BpmResult.Failed("error1","error2");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Errors);
            Assert.IsFalse(result.Succeeded);
        }
        [TestMethod]
        public void TestEmptyFailed()
        {
            BpmResult result = BpmResult.Failed();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Errors);
            Assert.IsFalse(result.Succeeded);
        }
        [TestMethod]
        public void TestNullFailed()
        {
            BpmResult result = BpmResult.Failed(null);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Errors);
            Assert.IsFalse(result.Succeeded);
        }
    }
}
