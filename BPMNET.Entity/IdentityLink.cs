using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class IdentityLink : IdentityLink<string>
    { }
    public class IdentityLink<TKey> : IIdentityLink<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey IdentityLinkId { get; set; }
        public TKey ProcessTaskId { get; set; }
        public string Group { get; set; }
        public EIdentityLinkType Type { get; set; }
        public string Username { get; set; }
        public string ProcessInstanceId { get; set; }
    }
}
