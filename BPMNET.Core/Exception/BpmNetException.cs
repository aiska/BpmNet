using System;

namespace BPMNET.Exception
{
    [Serializable]
    public class BpmNetException : System.Exception
    {
        public BpmNetException() { }
        public BpmNetException(string message) : base(message) { }
        public BpmNetException(string message, System.Exception inner) : base(message, inner) { }
    }
}
