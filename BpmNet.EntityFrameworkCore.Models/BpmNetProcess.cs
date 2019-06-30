using BpmNet.Model;
using System;

namespace BpmNet.EntityFrameworkCore.Models
{
    public class BpmNetProcess : IBpmNetProcess
    {
        public BpmNetProcess()
        {
            TimeStamp = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string DefinitionId { get; set; }
        public bool IsExecutable { get; set; }
        public bool IsClosed { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
