namespace BPMNET.Core
{
    public interface IProcessDefinition<TKey>
    {
        TKey Id { get; set; }
        TKey DeploymentId { get; set; }
        string ProcessId { get; set; }
        string ProcessName { get; set; }
        bool IsExecutable { get; set; }
        bool IsClosed { get; set; }
        int Version { get; set; }
    }
}
