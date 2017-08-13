using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class Comment : Comment<string>
    { }

    public class Comment<TKey> : IComment<TKey>
    {
        public TKey Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public TKey ProcessTaskId { get; set; }
        public TKey ProcessInstanceId { get; set; }
        public string Type { get; set; }
        public string FullMessage { get; set; }

    }
}
