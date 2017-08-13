using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity.GuidKey;
using System.Configuration;
using System;
using BPMNET.Core;
using System.Threading.Tasks;

namespace BPMNET.UnitTestGuid
{
    [TestClass]
    public class TestBpmGuidDbContext
    {
        [TestMethod]
        public void TestGuidStore()
        {
            string ConnStr = ConfigurationManager.ConnectionStrings["test"].ToString();
            using (BpmDbContext ctx = new BpmDbContext(ConnStr))
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    //Task<ProcessInstance> actual = store.FindByIdAsync(Guid.NewGuid());
                    //actual.Wait();
                    Assert.IsNotNull(store.Context);
                    Assert.IsNotNull(store.Entities);
                }
            }
        }

        [TestMethod]
        public void TestBpmContextManager()
        {
            //using (Entity.BpmContextManager manager = new Entity.BpmContextManager())
            //{
            //    Assert.IsNotNull(manager);
            //}
        }

        [TestMethod]
        public void TestBpmDbContextGuidNoCon()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                Assert.IsNotNull(actual);
            }
        }
        [TestMethod]
        public void TestBpmDbContextGuidConnStr()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                Assert.IsNotNull(actual);
            }
        }
        [TestMethod]
        public void TestBpmDbContextGuidNoConnStr()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                Assert.IsNotNull(actual);
            }
        }
        [TestMethod]
        public void TestProcessInstanceManagerGuid()
        {
            using (BpmDbContext actual = new BpmDbContext())
            {
                ProcessManager manager = new ProcessManager(actual);
            }
        }
        [TestMethod]
        public void TestProcessInstanceManagerGuidConstruct()
        {
            ProcessManager manager = new ProcessManager();
            manager.Dispose();
        }
        [TestMethod]
        public void TestProcessInstanceStore()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            store.Dispose();
        }
        [TestMethod]
        public void TestCreateGuid()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance pi = new ProcessInstance();
                    pi.SuspensionState = ESuspensionState.ACTIVE;
                    pi.Name = "Test Process Instance";
                    pi.ProcessDefinitionId = Guid.NewGuid();
                    pi.ProcessDefinitionName = "Process Definition Name";
                    pi.TenantId = "Tenant Id";
                    pi.UserCandidates = "";
                    Task task = store.CreateAsync(pi);
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
        public void TestCreateGuid2()
        {
            using (BpmDbContext ctx = new BpmDbContext())
            {
                using (ProcessInstanceStore store = new ProcessInstanceStore(ctx))
                {
                    ProcessInstance pi = new ProcessInstance();
                    pi.SuspensionState = ESuspensionState.ACTIVE;
                    pi.Name = "Test Process Instance";
                    pi.ProcessDefinitionId = Guid.NewGuid();
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