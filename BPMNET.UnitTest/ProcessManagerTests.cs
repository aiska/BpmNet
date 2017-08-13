using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.Tests
{
    [TestClass()]
    public class ProcessManagerTests : IDisposable
    {
        ProcessManager manager;
        public ProcessManagerTests()
        {
            manager = new ProcessManager();
        }

        public void Dispose()
        {
            manager.Dispose();
        }

        [TestMethod()]
        public void CreateProcessDefinitionTest()
        {
            ProcessDefinition def = new ProcessDefinition();
            def.ProcessDefinitionId = Guid.NewGuid().ToString();
            Task task = manager.CreateProcessDefinitionAsync(def);
            task.Wait();
        }

        [TestMethod()]
        public void CreateProcessInstanceTest()
        {
            ProcessInstance processInstance = new ProcessInstance();
            processInstance.ProcessInstanceId = "1";
            Task task = manager.CreateProcessInstanceAsync(processInstance);
            task.Wait();
        }

        [TestMethod()]
        public void CreateProcessTaskAsyncTest()
        {
            ProcessTask processTask = new ProcessTask();
            processTask.ProcessTaskId = "1";
            processTask.ProcessInstanceId = "1";
            Task task = manager.CreateProcessTaskAsync(processTask);
            task.Wait();
        }

        //[TestMethod()]
        public void CompleteProcessTaskAsyncTest()
        {
            Dictionary<string, object> variable = new Dictionary<string, object>();
            variable.Add("test1", "test");
            Task task = manager.CompleteProcessTaskAsync("1", variable);
            task.Wait();
        }

        [TestMethod()]
        public void ProcessManagerTest()
        {
        }

        [TestMethod()]
        public void ProcessManagerTest1()
        {

        }

        [TestMethod()]
        public void DisposeTest()
        {

        }

        [TestMethod()]
        public void FindProcessInstanceByIdAsyncTest()
        {

        }

        [TestMethod()]
        public void FindProcessInstanceByIdTest()
        {

        }

        [TestMethod()]
        public void CreateProcessInstanceAsyncTest()
        {

        }

        [TestMethod()]
        public void CreateProcessInstanceTest1()
        {

        }

        [TestMethod()]
        public void UpdateProcessInstanceAsyncTest()
        {

        }

        [TestMethod()]
        public void UpdateProcessInstanceTest()
        {

        }

        [TestMethod()]
        public void DeleteProcessInstanceAsyncTest()
        {

        }

        [TestMethod()]
        public void DeleteProcessInstanceTest()
        {

        }

        [TestMethod()]
        public void ActivateProcessInstanceByIdAsyncTest()
        {

        }

        [TestMethod()]
        public void ActivateProcessInstanceByIdTest()
        {

        }

        [TestMethod()]
        public void IsProcessDefinitionExistAsyncTest()
        {

        }

        [TestMethod()]
        public void IsProcessDefinitionExistTest()
        {

        }

        [TestMethod()]
        public void FindProcessDefinitionByIdAsyncTest()
        {

        }

        [TestMethod()]
        public void FindProcessDefinitionByIdTest()
        {

        }

        [TestMethod()]
        public void CreateProcessDefinitionAsyncTest()
        {

        }

        [TestMethod()]
        public void UpdateProcessDefinitionAsyncTest()
        {

        }

        [TestMethod()]
        public void UpdateProcessDefinitionTest()
        {

        }

        [TestMethod()]
        public void DeleteProcessDefinitionAsyncTest()
        {

        }

        [TestMethod()]
        public void DeleteProcessDefinitionTest()
        {

        }

        [TestMethod()]
        public void IsProcessTaskExistAsyncTest()
        {

        }

        [TestMethod()]
        public void IsProcessTaskExistTest()
        {

        }

        [TestMethod()]
        public void FindProcessTaskByIdAsyncTest()
        {

        }

        [TestMethod()]
        public void FindProcessTaskByIdTest()
        {

        }

        [TestMethod()]
        public void CreateProcessTaskAsyncTest1()
        {

        }

        [TestMethod()]
        public void CreateProcessTaskTest()
        {

        }

        [TestMethod()]
        public void UpdateProcessTaskAsyncTest()
        {

        }

        [TestMethod()]
        public void UpdateProcessTaskTest()
        {

        }

        [TestMethod()]
        public void DeleteProcessTaskAsyncTest()
        {

        }

        [TestMethod()]
        public void DeleteProcessTaskTest()
        {

        }

        [TestMethod()]
        public void ClaimProcessTaskAsyncTest()
        {

        }

        [TestMethod()]
        public void ClaimProcessTaskTest()
        {

        }

        [TestMethod()]
        public void UnClaimProcessTaskAsyncTest()
        {

        }

        [TestMethod()]
        public void UnClaimProcessTaskTest()
        {

        }

        [TestMethod()]
        public void CompleteProcessTaskTest()
        {

        }

        [TestMethod()]
        public void CompleteProcessTaskAsyncTest1()
        {

        }

        [TestMethod()]
        public void CompleteProcessTaskAsyncTest2()
        {

        }
    }
}