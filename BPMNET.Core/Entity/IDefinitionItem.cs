using System;
using System.Collections.Generic;

namespace BPMNET.Core
{
    public interface IDefinitionItem<TKey>
    {
        TKey Id { get; set; }
        TKey DeploymentId { get; set; }
        string DefinitionItemId { get; set; }
        bool IsCollection { get; set; }
        string StructureRef { get; set; }
    }
}
