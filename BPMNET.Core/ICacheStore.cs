namespace BPMNET.Core
{
    public interface ICacheStore<T>
        where T : class
    {
        void Add(string key, T value);
        T Get(string key);
        void Set(string key, T value);
        bool Exists(string key);
        void Remove(string key);
    }
}
