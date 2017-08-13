using System;

namespace BPMNET.Exception
{
    [Serializable]
    public class TaskAlreadyClaimedException : BpmNetException
    {
        public TaskAlreadyClaimedException() : base() { }
        public TaskAlreadyClaimedException(string message) : base(message) { }
        public TaskAlreadyClaimedException(string message, System.Exception inner) : base(message, inner) { }
    }
}
