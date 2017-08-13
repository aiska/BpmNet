using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace BPMNET.UnitTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestProcessInstanceManager
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void TestProcessInstanceManagerConstruct()
        {
            ProcessManager manager = new ProcessManager(null);
        }

        [TestMethod]
        public void TestProcessInstanceManagerConstructn()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                ProcessManager manager = new ProcessManager(ctx);
            }
        }

        [TestMethod]
        public void TestProcessInstanceManagerConstruct2()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                ProcessDefinitionStore defStore = new ProcessDefinitionStore(ctx);
                ProcessInstanceStore insStore = new ProcessInstanceStore(ctx);
                ProcessTaskStore taskStore = new ProcessTaskStore(ctx);
                ProcessManager manager = new ProcessManager(defStore, insStore, taskStore);
            }
        }

        [TestMethod]
        public void TestFindProcessInstanceByIdAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = Task.Run(() => manager.FindProcessInstanceByIdAsync(null));
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            task = Task.Run(() => manager.FindProcessInstanceByIdAsync("1"));
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestFindProcessInstanceById()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.FindProcessInstanceById(null);
            }
            catch (System.Exception)
            {
            }
            manager.FindProcessInstanceById("1");
            manager.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void TestProcessInstanceManagerConstructNull()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    store.FindById(null);
                }
            }
        }

        [TestMethod]
        public void TestIsProcessDefinitionExistAsyncProcessInstanceManager()
        {
            ProcessManager manager = new ProcessManager();
            Task task = Task.Run(() => manager.IsProcessDefinitionExistAsync("1"));
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestIsProcessDefinitionExistAsyncProcessInstanceManager2()
        {
            ProcessManager manager = new ProcessManager();
            Task task = Task.Run(() => manager.IsProcessDefinitionExistAsync("1"));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestIsProcessDefinitionExistProcessInstanceManager()
        {
            ProcessManager manager = new ProcessManager();
            manager.IsProcessDefinitionExist("1");
            manager.Dispose();
        }

        [TestMethod]
        public void TestIsProcessDefinitionExistProcessInstanceManager2()
        {
            ProcessManager manager = new ProcessManager();
            manager.IsProcessDefinitionExist("2");
            manager.Dispose();
        }
        [TestMethod]
        public void TestCreateProcessInstanceAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = Task.Run(() => manager.CreateProcessInstanceAsync(null));
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = new ProcessInstance();
            task = Task.Run(() => manager.CreateProcessInstanceAsync(data));
            task.Wait();
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            task = Task.Run(() => manager.CreateProcessInstanceAsync(data));
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestCreateProcessInstance()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.CreateProcessInstance(null);
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = new ProcessInstance();
            manager.CreateProcessInstance(data);
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            manager.CreateProcessInstance(data);
            manager.Dispose();
        }
        [TestMethod]
        public void TestUpdateProcessInstanceAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = Task.Run(() => manager.UpdateProcessInstanceAsync(null));
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            task = Task.Run(() => manager.UpdateProcessInstanceAsync(data));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestUpdateProcessInstance()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.UpdateProcessInstance(null);
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            manager.UpdateProcessInstance(data);
            manager.Dispose();
        }
        [TestMethod]
        public void TestDeleteProcessInstanceAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = Task.Run(() => manager.DeleteProcessInstanceAsync(null));
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            task = Task.Run(() => manager.DeleteProcessInstanceAsync(data.ProcessInstanceId));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestDeleteProcessInstance()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.DeleteProcessInstance(null);
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            manager.DeleteProcessInstance(data.ProcessInstanceId);
            manager.Dispose();
        }

        [TestMethod]
        public void TestActivateProcessInstanceAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = Task.Run(() => manager.ActivateProcessInstanceByIdAsync(null));
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            task = Task.Run(() => manager.ActivateProcessInstanceByIdAsync(data.ProcessInstanceId));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestActivateProcessInstance()
        {
            ProcessManager manager = new ProcessManager();
            manager.ProcessDefinitions.FirstOrDefault();
            try
            {
                manager.ActivateProcessInstanceById(null);
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            manager.ActivateProcessInstanceById(data.ProcessInstanceId);
            manager.Dispose();
        }
        [TestMethod]
        public void TestStoreNotIQueryableGroupStore()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager = new ProcessManager(null);
                manager.ActivateProcessInstanceById(null);
            }
            catch (System.Exception)
            {
            }
            ProcessInstance data = manager.ProcessInstances.FirstOrDefault();
            manager.ActivateProcessInstanceById(data.ProcessInstanceId);
            manager.Dispose();
        }

        [TestMethod]
        public void TestFindProcessDefinitionByIdAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = Task.Run(() => manager.FindProcessDefinitionByIdAsync(null));
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            task = Task.Run(() => manager.FindProcessDefinitionByIdAsync("1"));
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestFindProcessDefinitionById()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.FindProcessDefinitionById(null);
            }
            catch (System.Exception)
            {
            }
            manager.FindProcessDefinitionById("1");
            manager.Dispose();
        }

        //[TestMethod]
        public void TestProcessDefinitionManagerFindNull()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessDefinitionStore store = new ProcessDefinitionStore(ctx))
                {
                    store.FindById(null);
                }
            }
        }

        [TestMethod]
        public void TestIsProcessDefinitionExistAsyncProcessDefinitionManager()
        {
            ProcessManager manager = new ProcessManager();
            Task task = Task.Run(() => manager.IsProcessDefinitionExistAsync("1"));
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestIsProcessDefinitionExistAsyncProcessDefinitionManager2()
        {
            ProcessManager manager = new ProcessManager();
            Task task = Task.Run(() => manager.IsProcessDefinitionExistAsync("1"));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestIsProcessDefinitionExistProcessDefinitionManager()
        {
            ProcessManager manager = new ProcessManager();
            manager.IsProcessDefinitionExist("1");
            manager.Dispose();
        }

        [TestMethod]
        public void TestIsProcessDefinitionExistProcessDefinitionManager2()
        {
            ProcessManager manager = new ProcessManager();
            manager.IsProcessDefinitionExist("2");
            manager.Dispose();
        }
        [TestMethod]
        public void TestCreateProcessDefinitionAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = manager.CreateProcessDefinitionAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessDefinition data = new ProcessDefinition();
            task = manager.CreateProcessDefinitionAsync(data);
            task.Wait();
            data.ProcessDefinitionId = Guid.NewGuid().ToString();
            task = manager.CreateProcessDefinitionAsync(data);
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestCreateProcessDefinition()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.CreateProcessDefinition(null);
            }
            catch (System.Exception)
            {
            }
            ProcessDefinition data = new ProcessDefinition();
            manager.CreateProcessDefinition(data);
            data.ProcessDefinitionId = Guid.NewGuid().ToString();
            manager.CreateProcessDefinition(data);
            manager.Dispose();
        }
        [TestMethod]
        public void TestUpdateProcessDefinitionAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = manager.UpdateProcessDefinitionAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessDefinition data = manager.ProcessDefinitions.FirstOrDefault();
            task = Task.Run(() => manager.UpdateProcessDefinitionAsync(data));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestUpdateProcessDefinition()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.UpdateProcessDefinition(null);
            }
            catch (System.Exception)
            {
            }
            ProcessDefinition data = manager.ProcessDefinitions.FirstOrDefault();
            manager.UpdateProcessDefinition(data);
            manager.Dispose();
        }
        [TestMethod]
        public void TestDeleteProcessDefinitionAsync()
        {
            Task taskDel = null;
            ProcessManager manager = new ProcessManager();
            try
            {
                ProcessDefinition data = manager.ProcessDefinitions.FirstOrDefault();
                if (data != null)
                {
                    taskDel = manager.DeleteProcessDefinitionAsync(data.ProcessDefinitionId);
                }
                Task taskDelNull = manager.DeleteProcessDefinitionAsync(null);
                //task = manager.DeleteProcessDefinitionAsync(null);
                taskDelNull.Wait();
            }
            catch (System.Exception)
            {
            }
            finally
            {
                if (taskDel != null) taskDel.Wait();
                manager.Dispose();
            }
        }
        [TestMethod]
        public void TestDeleteProcessDefinition()
        {
            ProcessManager manager = new ProcessManager();
            //try
            //{
            //    manager.DeleteProcessDefinition(null);
            //}
            //catch (System.Exception)
            //{
            //}
            try
            {
                ProcessDefinition data = manager.ProcessDefinitions.FirstOrDefault();
                if (data != null)
                {
                    manager.DeleteProcessDefinition(data.ProcessDefinitionId);
                }
            }
            catch (System.Exception)
            {
            }
            finally
            {
                manager.Dispose();
            }
        }

        [TestMethod]
        public void TestFindProcessTaskByIdAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = manager.FindProcessTaskByIdAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            task = manager.FindProcessTaskByIdAsync("1");
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestFindProcessTaskById()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.FindProcessTaskById(null);
            }
            catch (System.Exception)
            {
            }
            manager.FindProcessTaskById("1");
            manager.Dispose();
        }

        [TestMethod]
        public void TestProcessTaskManagerFindNull()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessTaskStore store = new ProcessTaskStore(ctx))
                {
                    try
                    {
                        store.FindById(null);
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
        }

        [TestMethod]
        public void TestIsProcessTaskExistAsyncProcessTaskManager()
        {
            ProcessManager manager = new ProcessManager();
            Task task = manager.IsProcessTaskExistAsync("1");
            task.Wait();
            manager.Dispose();
        }

        [TestMethod]
        public void TestIsProcessTaskExistAsyncProcessTaskManager2()
        {
            ProcessManager manager = new ProcessManager();
            Task task = manager.IsProcessTaskExistAsync("1");
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestIsProcessTaskExistProcessTaskManager()
        {
            ProcessManager manager = new ProcessManager();
            manager.IsProcessTaskExist("1");
            manager.Dispose();
        }

        [TestMethod]
        public void TestIsProcessTaskExistProcessTaskManager2()
        {
            ProcessManager manager = new ProcessManager();
            manager.IsProcessTaskExist("2");
            manager.Dispose();
        }
        [TestMethod]
        public void TestCreateProcessTaskAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = manager.CreateProcessTaskAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessTask data = new ProcessTask();
            task = manager.CreateProcessTaskAsync(data);
            task.Wait();
            data.ProcessTaskId = Guid.NewGuid().ToString();
            task = manager.CreateProcessTaskAsync(data);
            task.Wait();
            task.Dispose();
            manager.Dispose();
        }

        [TestMethod]
        public void TestCreateProcessTask()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.CreateProcessTask(null);
            }
            catch (System.Exception)
            {
            }
            ProcessTask data = new ProcessTask();
            manager.CreateProcessTask(data);
            data.ProcessTaskId = Guid.NewGuid().ToString();
            manager.CreateProcessTask(data);
            manager.Dispose();
        }
        [TestMethod]
        public void TestUpdateProcessTaskAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = manager.UpdateProcessTaskAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessTask data = manager.ProcessTasks.FirstOrDefault();
            task = manager.UpdateProcessTaskAsync(data);
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestUpdateProcessTask()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.UpdateProcessTask(null);
            }
            catch (System.Exception)
            {
            }
            ProcessTask data = manager.ProcessTasks.FirstOrDefault();
            manager.UpdateProcessTask(data);
            manager.Dispose();
        }
        [TestMethod]
        public void TestDeleteProcessTaskAsync()
        {
            Task task;
            ProcessManager manager = new ProcessManager();
            try
            {
                task = manager.DeleteProcessTaskAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            ProcessTask data = manager.ProcessTasks.FirstOrDefault();
            task = manager.DeleteProcessTaskAsync(data.ProcessTaskId);
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestDeleteProcessTask()
        {
            ProcessManager manager = new ProcessManager();
            try
            {
                manager.DeleteProcessTask(null);
            }
            catch (System.Exception)
            {
            }
            ProcessTask data = manager.ProcessTasks.FirstOrDefault();
            manager.DeleteProcessTask(data.ProcessTaskId);
            manager.Dispose();
        }
    }
}
