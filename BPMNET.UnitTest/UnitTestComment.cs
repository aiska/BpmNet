using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestComment
    {
        [TestMethod]
        public void TestComment1()
        {
            Comment comment = new Comment();
            comment.CreateDate = new DateTime();
            comment.FullMessage = "";
            comment.Id = Guid.NewGuid().ToString();
            comment.ProcessInstanceId = Guid.NewGuid().ToString();
            comment.ProcessTaskId = Guid.NewGuid().ToString();
            comment.Type = "type";
            comment.UserId = "user";
            Assert.IsNotNull(comment.CreateDate);
            Assert.IsNotNull(comment.FullMessage);
            Assert.IsNotNull(comment.Id);
            Assert.IsNotNull(comment.ProcessInstanceId);
            Assert.IsNotNull(comment.ProcessTaskId);
            Assert.IsNotNull(comment.Type);
            Assert.IsNotNull(comment.UserId);
        }
    }
}
