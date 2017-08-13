using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Exception;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestTaskAlreadyClaimedException
    {
        [TestMethod]
        public void TestTaskAlreadyClaimedExceptionPlain()
        {
            TaskAlreadyClaimedException ex = new TaskAlreadyClaimedException();
            Assert.IsNotNull(ex);
        }
        [TestMethod]
        public void TestTaskAlreadyClaimedExceptionMsg()
        {
            TaskAlreadyClaimedException ex = new TaskAlreadyClaimedException("Error Message");
            Assert.IsNotNull(ex);
        }
        [TestMethod]
        public void TaskAlreadyClaimedExceptionMsgInner()
        {
            TaskAlreadyClaimedException ex = new TaskAlreadyClaimedException("Error Message", new ArgumentNullException("null"));
            Assert.IsNotNull(ex);
        }
    }
}
