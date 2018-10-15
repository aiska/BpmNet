using BpmNet.Model;
using System;

namespace BpmNet.EntityFrameworkCore.Models
{
    public class BpmNetDefinition : IBpmNetDefinition
    {
        public BpmNetDefinition()
        {
        }

        public string Id { get; set; }
        public string Xml { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
