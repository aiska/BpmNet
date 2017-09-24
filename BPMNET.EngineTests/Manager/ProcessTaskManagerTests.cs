using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Engine.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNET.Entity.Store;
using BPMNET.Bpmn;

namespace BPMNET.Engine.Manager.Tests
{
    [TestClass()]
    public class ProcessTaskManagerTests : IDisposable
    {
        ProcessTaskStore store;
        ProcessTaskManager manager;

        public ProcessTaskManagerTests()
        {
            store = new ProcessTaskStore();
            manager = new ProcessTaskManager(store);
        }


        [TestMethod()]
        public async Task GetProcessTaskByFlowNodeIdAsyncTest()
        {
            var task = await manager.GetProcessTaskByFlowNodeIdAsync("IDE");
        }

        [TestMethod()]
        public async Task CreateTaskAsyncTest()
        {
            var task = await manager.CreateTaskAsync(24, 17, "IDE", ProcessItemType.UserTask);
        }

        [TestMethod()]
        public void Dispose()
        {
            manager.Dispose();
        }
    }
}