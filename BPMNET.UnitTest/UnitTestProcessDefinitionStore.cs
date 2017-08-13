using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace BPMNET.UnitTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UnitTestProcessDefinitionStore
    {
        [TestMethod]
        public void TestProcessDefinitionStoreConstruct()
        {
            ProcessDefinitionStore store = new ProcessDefinitionStore();
            store.Dispose();
        }

        [TestMethod]
        public void TestProcessDefinitionStore1()
        {
            ProcessDefinitionStore store = new ProcessDefinitionStore(new BpmDbContext());
            store.Dispose();
            try
            {
                store.FindById("1");
            }
            catch (System.Exception)
            {
            }
        }

        [TestMethod]
        public void TestProcessDefinitionStoreFindByIdAsync2()
        {
            Task task;
            ProcessDefinitionStore store = new ProcessDefinitionStore(new BpmDbContext());
            task = Task.Run(() => store.FindByIdAsync("1"));
            task.Wait();
            store.Dispose();
        }
        [TestMethod]
        public void TestProcessDefinitionStoreFindById2()
        {
            BpmDbContext context = new BpmDbContext();
            context.Database.Log = s => Debug.WriteLine(s);
            ProcessDefinitionStore store = new ProcessDefinitionStore(context);
            store.FindByIdAsync("1");
            store.Dispose();
        }
    }
}
