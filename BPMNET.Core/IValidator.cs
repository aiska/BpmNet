using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IValidator<in T>
    {
        BpmResult Validate(T item);
        Task<BpmResult> ValidateAsync(T item);
    }
}
