using System;

namespace BPMNET.Bpmn.Exception
{
    [Serializable]
    public class ItemDefinitionNotFoundException : System.Exception
    {
        public ItemDefinitionNotFoundException() { }
        public ItemDefinitionNotFoundException(string message) : base(message) { }
        public ItemDefinitionNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ItemDefinitionNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
