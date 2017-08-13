using System;

namespace BPMNET.Exception
{

    [Serializable]
    public class BpmnProcessNotFoundException : System.Exception
    {
        public BpmnProcessNotFoundException() { }
        public BpmnProcessNotFoundException(string message) : base(message) { }
        public BpmnProcessNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected BpmnProcessNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
