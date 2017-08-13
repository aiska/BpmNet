namespace BPMNET.Core
{
    public interface IProcessTaskKey<T>
    {
        T ProcessTaskId { get; set; }
    }
}
