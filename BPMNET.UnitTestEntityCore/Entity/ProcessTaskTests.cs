using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BPMNET.EntityCore.Tests
{
    [TestClass()]
    public class ProcessTaskTests
    {
        [TestMethod()]
        public void GetHashCodeTest()
        {
            ProcessTask processTask = new ProcessTask();
            Assert.IsNotNull(processTask.ProcessTaskId);
            Assert.IsNull(processTask.ProcessTaskName);
            Assert.IsNull(processTask.ProcessTaskOwner);
            Assert.AreEqual(processTask.ParentTaskId, Guid.Empty);
            Assert.AreEqual(processTask.Priority, default(int));
            Assert.AreEqual(processTask.ProcessKey, Guid.Empty);
            Assert.AreEqual(processTask.ProcessInstanceId, Guid.Empty);
            Assert.AreEqual(processTask.ProcessItemDefinitionId, Guid.Empty);
            Assert.AreEqual(processTask.SuspensionState, ESuspensionState.ACTIVE);
            Assert.AreEqual(processTask.Inserted, default(DateTime));
            Assert.AreEqual(processTask.LastUpdated, default(DateTime));
            Assert.IsNotNull(processTask.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest()
        {

        }

        [TestMethod()]
        public void EqualsTest1()
        {

        }
    }
}