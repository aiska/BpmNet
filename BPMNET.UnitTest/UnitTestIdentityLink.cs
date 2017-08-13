using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using BPMNET.Core;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestIdentityLink
    {
        [TestMethod]
        public void TestIdentityLink1()
        {
            IdentityLink data = new IdentityLink();
            data.Group = "group";
            data.IdentityLinkId = Guid.NewGuid().ToString();
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            data.ProcessTaskId = Guid.NewGuid().ToString();
            data.Type = EIdentityLinkType.Owner;
            data.Username = "user";
            Assert.IsNotNull(data.Group);
            Assert.IsNotNull(data.IdentityLinkId);
            Assert.IsNotNull(data.ProcessInstanceId);
            Assert.IsNotNull(data.ProcessTaskId);
            Assert.IsNotNull(data.Type);
            Assert.IsNotNull(data.Username);
        }
    }
}
