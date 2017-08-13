namespace BPMNET.Core
{
    public interface IProcessInstanceKey<T>
    {
        T ProcessInstanceId { get; set; }
    }

    public interface IProcessInstanceKey : IProcessInstanceKey<string> { 
    }
}
