namespace BPMNET.Core
{
    public interface IProcessVariable<TKey>
    {
        TKey ProcessVariablesId { get; set; }
        TKey ProcessInstanceId { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        string StructureRef { get; set; }
    }
}
