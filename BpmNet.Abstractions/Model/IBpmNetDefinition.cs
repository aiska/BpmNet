using System;

namespace BpmNet.Model
{
    public interface IBpmNetDefinition
    {
        string Id { get; set; }
        DateTime TimeStamp { get; set; }
        string Xml { get; set; }
    }
}