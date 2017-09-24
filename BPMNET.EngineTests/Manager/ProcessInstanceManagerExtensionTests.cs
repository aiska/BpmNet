using BPMNET.Engine.Manager.Int;
using BPMNET.Entity.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BPMNET.Engine.Manager.Tests
{
    [TestClass()]
    public class ProcessInstanceManagerExtensionTests
    {
        ProcessInstanceStore store;
        ProcessInstanceManager manager;

        public ProcessInstanceManagerExtensionTests()
        {
            store = new ProcessInstanceStore();
            manager = new ProcessInstanceManager(store);
        }

        [TestMethod()]
        public void GetActiveProcessInstanceTest()
        {
            var instances = manager.GetActiveProcessInstance();
            Assert.IsTrue(instances.Length > 0);
        }

        [TestMethod()]
        public void GetProcessInstanceByProcessNameTest()
        {
            var instances = manager.GetProcessInstanceByProcessName("fixSystemFailure");
            Assert.IsTrue(instances.Length > 0);
        }

        [TestMethod()]
        public void GetAllSubProcessTest()
        {
            var instances = manager.GetProcessInstanceByProcessName("fixSystemFailure");
            var subProcess = manager.GetAllSubProcess(instances[0].Id);
            Assert.IsTrue(subProcess.Length > 0);
        }

        [TestMethod()]
        public void GetProcessInstanceTest()
        {
            var instances = manager.GetProcessInstanceByProcessName("fixSystemFailure");
            var instance = manager.GetProcessInstance(instances[0].Id);
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public void StartProcessInstanceTest()
        {
            var instances = manager.GetProcessInstanceByProcessName("fixSystemFailure");
            var instance = manager.StartProcessInstance(instances[0].ProcessDefinitionId, "Business Key");
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public void StartProcessInstanceTest1()
        {
            var instance = manager.StartProcessInstance("fixSystemFailure", "Business Key");
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public void ActivateAndSuspendTest()
        {
            var instance = manager.StartProcessInstance("fixSystemFailure", "Business Key");
            manager.ActivateInstance(instance.Id);
            manager.SuspendInstance(instance.Id);
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public void CancelTest()
        {
            var instance = manager.StartProcessInstance("fixSystemFailure", "Business Key");
            manager.CancelInstance(instance.Id, "Cancel Test");
            Assert.IsNotNull(instance);
        }
    }
}