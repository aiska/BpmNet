using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using BPMNET.Core;
using BPMNET.Entity.Store;

namespace BPMNET.UnitTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestBpmDefaultDbContext
    {
        [TestMethod]
        public void TestBpmDbContextConStr()
        {
            string ConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            using (BpmDbContext ctx = new BpmDbContext(ConnStr))
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance actual = store.FindById("1");
                    Assert.IsNotNull(store.Context);
                    Assert.IsNotNull(store.Entities);
                }
            }
        }
        [TestMethod]
        public void TestStore()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance actual = store.FindById("1");
                    Assert.IsNotNull(store.Context);
                    Assert.IsNotNull(store.Entities);
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullContext()
        {
            ProcessInstanceStore store = new ProcessInstanceStore(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateNull()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    store.Create(null);
                }
            }
        }

        [TestMethod]
        public void TestProcessInstanceManagerNoParam()
        {
            using (ProcessInstanceStore store = new ProcessInstanceStore())
            {
                Assert.IsNull(store.FindById("3"));
            }
        }

        [TestMethod]
        public void TestProcessInstanceManagerThrowIfDisposed()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            store.Dispose();
            try
            {
                store.FindById("10");
            }
            catch (System.Exception)
            {
            }
        }

        [TestMethod]
        public void TestProcessInstanceStoreCreateAsync()
        {
            Task task;
            ProcessInstance data = new ProcessInstance();
            ProcessInstanceStore store = new ProcessInstanceStore();
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            task = store.CreateAsync(data);
            task.Wait();
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceStoreCreateAsyncNull()
        {
            Task task;
            ProcessInstanceStore store = new ProcessInstanceStore();
            try
            {
                task = store.CreateAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceUpdateAsync()
        {
            Task task;
            ProcessInstance data = new ProcessInstance();
            ProcessInstanceStore store = new ProcessInstanceStore();
            data = store.Entities.FirstOrDefault();
            data.TenantId = "";
            task = store.UpdateAsync(data);
            task.Wait();
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceStoreDeleteAsync()
        {
            Task task;
            ProcessInstance data = new ProcessInstance();
            ProcessInstanceStore store = new ProcessInstanceStore();
            data = store.Entities.FirstOrDefault();
            task = store.DeleteAsync(data);
            task.Wait();
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceUpdateAsyncNull()
        {
            Task task;
            ProcessInstanceStore store = new ProcessInstanceStore();
            try
            {
                task = store.UpdateAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceUpdateNull()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            try
            {
                store.Update(null);
            }
            catch (System.Exception)
            {
            }
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceDeleteAsync()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            Task task;
            try
            {
                task = store.DeleteAsync(null);
                task.Wait();
            }
            catch (System.Exception)
            {
            }
            try
            {
                store.Delete(null);
            }
            catch (System.Exception)
            {
            }
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessInstanceManagerNullAsync()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    var task = store.FindByIdAsync("2");
                    task.Wait();
                    task = store.FindByProcessInstanceNameAsync("2");
                    task.Wait();
                    var actual = store.FindByProcessInstanceName("2");

                    ProcessInstance pi = new ProcessInstance();
                    pi.ProcessInstanceId = Guid.NewGuid().ToString();
                    var taskCreate = store.CreateAsync(pi);
                    taskCreate.Wait();
                    try
                    {
                        taskCreate = store.CreateAsync(null);
                        taskCreate.Wait();
                    }
                    catch (System.Exception)
                    {
                    }

                    try
                    {
                        store.Create(null);
                    }
                    catch (System.Exception)
                    {
                    }

                    try
                    {
                        task = store.FindByIdAsync(null);
                        task.Wait();
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
        }

        [TestMethod]
        public void TestProcessInstanceManagerNullAsync2()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    var task = store.FindByIdAsync("2");
                    task.Wait();
                    task = store.FindByProcessInstanceNameAsync("2");
                    task.Wait();
                    var actual = store.FindByProcessInstanceName("2");

                    ProcessInstance pi = new ProcessInstance();
                    pi.ProcessInstanceId = Guid.NewGuid().ToString();
                    var taskCreate = store.CreateAsync(pi);
                    taskCreate.Wait();
                    try
                    {
                        taskCreate = store.CreateAsync(null);
                        taskCreate.Wait();
                    }
                    catch (System.Exception)
                    {
                    }

                    try
                    {
                        store.Create(null);
                    }
                    catch (System.Exception)
                    {
                    }

                    try
                    {
                        Task task2 = store.FindByIdAsync(null);
                        task2.Wait();
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreate()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance pi = new ProcessInstance();
                    pi.ProcessInstanceId = Guid.NewGuid().ToString();
                    pi.SuspensionState = ESuspensionState.ACTIVE;
                    pi.Name = "Test Process Instance";
                    pi.ProcessDefinitionId = new Guid().ToString();
                    pi.ProcessDefinitionName = "Process Definition Name";
                    pi.TenantId = "Tenant Id";
                    pi.BusinessKey = "Bussines Key";
                    pi.UserCandidates = "";
                    store.Create(pi);
                    Assert.IsNotNull(pi.ProcessInstanceId);
                    Assert.IsNotNull(pi.SuspensionState);
                    Assert.IsNotNull(pi.Name);
                    Assert.IsNotNull(pi.ProcessDefinitionId);
                    Assert.IsNotNull(pi.ProcessDefinitionName);
                    Assert.IsNotNull(pi.TenantId);
                    Assert.IsNotNull(pi.UserCandidates);
                }
            }
        }
    }
}
