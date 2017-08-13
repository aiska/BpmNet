using System.Linq;

namespace BPMNET.Core
{
    public interface IQueryableStore<out T>
    {
        IQueryable<T> Entities { get; }
    }
}
