using BPMNET.Engine.Manager.Int;
using BPMNET.Entity.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager.Tests
{
    [TestClass()]
    public class ProcessInstanceManagerTests : IDisposable
    {
        ProcessInstanceStore store;
        ProcessInstanceManager manager;
        public ProcessInstanceManagerTests()
        {
            store = new ProcessInstanceStore();
            manager = new ProcessInstanceManager(store);
        }

        [TestMethod()]
        public async Task GetActiveByProcessNameAsyncTest()
        {
            var instances = await manager.GetActiveByProcessNameAsync();
            Assert.IsTrue(instances.Length > 0);
        }

        [TestMethod()]
        public async Task GetAllSubProcessAsyncTest()
        {
            var instances = await manager.GetActiveByProcessNameAsync();
            var subProcess = await manager.GetAllSubProcessAsync(instances[0].Id);
        }

        [TestMethod()]
        public async Task GetProcessInstanceByProcessNameAsyncTest()
        {
            var instances = await manager.GetProcessInstanceByProcessNameAsync("fixSystemFailure");
        }

        [TestMethod()]
        public async Task GetProcessInstanceAsyncTest()
        {
            var instances = await manager.GetActiveByProcessNameAsync();
            await manager.GetProcessInstanceAsync(instances[0].Id);
        }

        [TestMethod()]
        public async Task StartProcessInstanceAsyncTest()
        {
            var instance = await manager.StartProcessInstanceAsync("fixSystemFailure", "busineess key");
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public async Task StartProcessInstanceAsyncTest1()
        {
            var instance = await manager.StartProcessInstanceAsync(1, "busineess key");
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public async Task SuspendAndActivateAsyncTest()
        {
            var instance = await manager.StartProcessInstanceAsync("fixSystemFailure", "busineess key");
            await manager.SuspendInstanceAsync(instance.Id);
            await manager.ActivateInstanceAsync(instance.Id);
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public async Task CancelAsyncTest()
        {
            var instance = await manager.StartProcessInstanceAsync("fixSystemFailure", "busineess key");
            await manager.CancelInstanceAsync(instance.Id, "Test cancel");
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public void Dispose()
        {
            manager.Dispose();
            store.Dispose();
        }
    }
}