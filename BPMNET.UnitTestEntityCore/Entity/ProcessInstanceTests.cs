using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BPMNET.EntityCore.Tests
{
    [TestClass()]
    public class ProcessInstanceTests
    {
        [TestMethod()]
        public void GetHashCodeTest()
        {
            ProcessInstance instance = new ProcessInstance();
            Assert.IsNotNull(instance.ProcessInstanceId);
            Assert.AreEqual(instance.ProcessKey, Guid.Empty);
            Assert.IsNull(instance.ProcessInstanceName);
            Assert.IsNull(instance.BusinessKey);
            Assert.AreEqual(instance.SuspensionState, ESuspensionState.ACTIVE);
            Assert.IsNull(instance.UserCandidates);
            Assert.IsNull(instance.Owner);
            Assert.AreEqual(instance.Inserted, default(DateTime));
            Assert.AreEqual(instance.LastUpdated, default(DateTime));
            Assert.IsNotNull(instance.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            ProcessInstance instance = new ProcessInstance();
            ProcessInstance instanceCompare = new ProcessInstance();
            Assert.IsTrue(instance.Equals(instanceCompare));
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            ProcessInstance instance = new ProcessInstance();
            object instanceCompare = new ProcessInstance();
            Assert.IsTrue(instance.Equals(instanceCompare));
        }
    }
}