namespace BPMNET.Core.Variable
{
    public interface IVariable<T>
    {
        string Name { get; set; }
        EStoreType StoreType { get; }
        bool Cachable { get; }
        bool CheckForStore(object value);
        T Value { get; }
    }
}
