using System;

namespace BPMNET.Bpmn.Exception
{
    [Serializable]
    public class ProcessNotFoundException : System.Exception
    {
        public ProcessNotFoundException() { }
        public ProcessNotFoundException(string message) : base(message) { }
        public ProcessNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ProcessNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
