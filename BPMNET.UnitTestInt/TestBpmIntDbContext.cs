using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity.IntKey;
using System.Configuration;
using System.Threading.Tasks;
using BPMNET.Core;

namespace BPMNET.UnitTestInt
{
    [TestClass]
    public class TestBpmIntDbContext
    {

        [TestMethod]
        public void TestCreateIntAsync()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance data = new ProcessInstance();
                    data.SuspensionState = ESuspensionState.ACTIVE;
                    data.Name = "Test Process Instance";
                    data.ProcessDefinitionId = 0;
                    data.ProcessDefinitionName = "Process Definition Name";
                    data.TenantId = "Tenant Id";
                    data.UserCandidates = "";
                    Task task = store.CreateAsync(data);
                    task.Wait();
                    Assert.IsNotNull(data.ProcessInstanceId);
                    Assert.IsNotNull(data.SuspensionState);
                    Assert.IsNotNull(data.Name);
                    Assert.IsNotNull(data.ProcessDefinitionId);
                    Assert.IsNotNull(data.ProcessDefinitionName);
                    Assert.IsNotNull(data.TenantId);
                    Assert.IsNotNull(data.UserCandidates);
                }
            }
        }

        [TestMethod]
        public void TestStore()
        {
            string ConnStr = ConfigurationManager.ConnectionStrings["test"].ToString();
            using (BpmDbContext ctx = new BpmDbContext(ConnStr))
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance actual = store.FindById(1);
                    Assert.IsNotNull(store.Context);
                    Assert.IsNotNull(store.Entities);
                }
                ProcessInstanceStore store2 = new ProcessInstanceStore();
                store2.Dispose();
            }
        }

        [TestMethod]
        public void TestBpmDbContextIntNoCon()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                Assert.IsNotNull(actual);
            }
        }
        [TestMethod]
        public void TestBpmDbContextIntConnStr()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                Assert.IsNotNull(actual);
            }
        }
        [TestMethod]
        public void TestBpmDbContextIntNoConnStr()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                Assert.IsNotNull(actual);
            }
        }
        [TestMethod]
        public void TestProcessInstanceManagerInt()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                ProcessManager manager = new ProcessManager(actual);
            }
        }

        [TestMethod]
        public void TestProcessInstanceManagerConstruct1()
        {
            ProcessManager manager = new ProcessManager();
            manager.Dispose();
        }

        [TestMethod]
        public void TestBpmContextManagerInt1()
        {
            //using (Entity.BpmContextManager manager = new Entity.BpmContextManager())
            //{
            //    Assert.IsNotNull(manager);
            //}
        }

        [TestMethod]
        public void TestBpmContextManagerInt2()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                ProcessManager manager = new ProcessManager(actual);
            }
        }

        [TestMethod]
        public void TestCreateInt()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance pi = new ProcessInstance();
                    pi.SuspensionState = ESuspensionState.ACTIVE;
                    pi.Name = "Test Process Instance";
                    pi.ProcessDefinitionId = 0;
                    pi.ProcessDefinitionName = "Process Definition Name";
                    pi.TenantId = "Tenant Id";
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
        [TestMethod]
        public void TestConstruct2()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                ProcessDefinitionStore defStore = new ProcessDefinitionStore();
                ProcessInstanceStore insStore = new ProcessInstanceStore();
                ProcessTaskStore taskStore = new ProcessTaskStore();
                ProcessManager manager = new ProcessManager(defStore, insStore, taskStore);
                defStore.Dispose();
                insStore.Dispose();
                manager.Dispose();
            }
        }
        [TestMethod]
        public void TestConstruct3()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                ProcessDefinitionStore defStore = new ProcessDefinitionStore(ctx);
                ProcessInstanceStore insStore = new ProcessInstanceStore(ctx);
                ProcessTaskStore taskStore = new ProcessTaskStore();
                ProcessManager manager = new ProcessManager(defStore, insStore, taskStore);
                defStore.Dispose();
                insStore.Dispose();
                manager.Dispose();
            }
        }
    }
}
