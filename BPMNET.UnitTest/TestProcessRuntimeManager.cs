using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System.Threading.Tasks;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestProcessRuntimeManager
    {
        [TestMethod]
        public void TestProcessRuntimeManagerStringKey()
        {
            ProcessManager manager = new ProcessManager();
            manager.Dispose();
        }
        [TestMethod]
        public void TestCreateProcessInstance()
        {
            ProcessManager manager = new ProcessManager();
            ProcessInstance pi = new ProcessInstance();
            pi.Name = "test";
            Task.Run(() => manager.CreateProcessInstanceAsync(pi));
            Task.WaitAll();
            manager.Dispose();
        }
        
    }
}
