using System;

namespace BpmNet.Model
{
    public interface IBpmNetProcess
    {
        string Id { get; set; }
        string Name { get; set; }
        string DefinitionId { get; set; }
        bool IsExecutable { get; set; }
        bool IsClosed { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
