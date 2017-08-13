using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Exception
{

    [Serializable]
    public class BpmnVariableEmptyException : System.Exception
    {
        private const string _MESSAGE = "Variable '{0}' cannot be null or empty.";
        private const string DEFAULT_MESSAGE = "Variable cannot be null or empty.";

        public BpmnVariableEmptyException() : base(DEFAULT_MESSAGE) { }
        public BpmnVariableEmptyException(string name) : base(string.Format(_MESSAGE, name)) {
        }
        public BpmnVariableEmptyException(string name, System.Exception inner) : base(string.Format(_MESSAGE, name), inner) { }
        protected BpmnVariableEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
