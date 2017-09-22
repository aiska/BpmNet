using BPMNET.Core.Variable;

namespace BPMNET.Core
{
    public interface IDefinitionVariable<TKey>
    {
        TKey DefinitionVariableId { get; set; }
        TKey DefinitionId { get; set; }
        string VariableName { get; set; }
        EStoreType StoreType { get; set; }
    }
}