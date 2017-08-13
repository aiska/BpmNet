using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System.Threading.Tasks;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestProcessDefinitionManager
    {
        [TestMethod]
        public void TestCreateProcessDefinitionAsync()
        {
            ProcessDefinitionManager manager = new ProcessDefinitionManager();
            ProcessDefinition data = new ProcessDefinition();
            Task task = Task.Run(() => manager.CreateProcessDefinitionAsync(data));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestCreateProcessDefinitionAsync2()
        {
            ProcessDefinitionManager manager = new ProcessDefinitionManager();
            ProcessDefinition data = new ProcessDefinition();
            Task task = Task.Run(() => manager.CreateProcessDefinitionAsync(data));
            task.Wait();
            manager.Dispose();
        }
        [TestMethod]
        public void TestCreateProcessDefinition()
        {
            ProcessDefinitionManager manager = new ProcessDefinitionManager();
            ProcessDefinition data = new ProcessDefinition();
            manager.CreateProcessDefinition(data);
            manager.Dispose();
        }
    }
}
