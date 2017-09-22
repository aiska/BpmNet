using System;

namespace BPMNET.Exception
{
    [Serializable]
    public class CouldNotLoadBpmnFileException : System.Exception
    {
        public CouldNotLoadBpmnFileException() { }
        public CouldNotLoadBpmnFileException(string filename) : base(filename) {
        }
        public CouldNotLoadBpmnFileException(string filename, System.Exception inner) : base(string.Format("Could not Load BPMN file '{0}'", filename), inner) { }
        protected CouldNotLoadBpmnFileException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
