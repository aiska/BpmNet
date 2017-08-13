using System;
using System.Collections.Generic;

namespace BPMNET.Core
{
    public interface IProcessItemDefinition<TKey>
    {
        TKey Id { get; set; }
        TKey ProcessDefinitionId { get; set; }
        string Name { get; set; }
        string Incoming { get; set; }
        string Outgoing { get; set; }
        string SourceRef { get; set; }
        string TargetRef { get; set; }
        string CompletionQuantity { get; set; }
        bool IsForCompensation { get; set; }
        string StartQuantity { get; set; }
        EProcessItemType Type { get; set; }
        ICollection<string> UserCandidates { get; set; }
        ICollection<string> RoleCandidates { get; set; }
        DateTime? DueDate { get; set; }
    }
}
