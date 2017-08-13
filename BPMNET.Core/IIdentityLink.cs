
namespace BPMNET.Core
{
    public interface IIdentityLink<TKey> : IProcessTaskKey<TKey>
    {
        TKey IdentityLinkId { get; }
        string Group { get; set; }
        EIdentityLinkType Type { get; set; }
        string Username { get; set; }
        string ProcessInstanceId { get; set; }
    }
}
