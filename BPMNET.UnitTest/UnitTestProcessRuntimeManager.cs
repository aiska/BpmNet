using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestProcessRuntimeManager
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProcessManager manager = new ProcessManager();
            manager.Dispose();
        }
    }
}
