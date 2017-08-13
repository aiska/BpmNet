using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestBpmContextManager
    {
        [TestMethod]
        public void TestBpmContextManagerContruct()
        {
            //BpmContextManager manager = new BpmContextManager();
            //manager.Dispose();
        }
        [TestMethod]
        public void TestBpmContextManagerContruct2()
        {
            //BpmContextManager manager = new BpmContextManager("DefaultConnection", "string", DatabaseGeneratedOption.None);
            //manager.Dispose();
        }

        [TestMethod]
        public void TestBpmContextManagerUsing()
        {
            //using (BpmContextManager manager = new BpmContextManager())
            //{
            //    Assert.IsNotNull(manager);
            //    Assert.IsNotNull(manager.Bpm());
            //    manager.Context.Dispose();
            //    manager.Dispose();
            //}
        }

    }
}
