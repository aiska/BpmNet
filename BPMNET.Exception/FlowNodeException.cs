using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Exception
{
    [Serializable]
    public class FlowNodeException : System.Exception
    {
        private const string MESSAGE = "Flow node Id '{0}; is not {1} node.";
        public FlowNodeException(string flowNode, string type) : this(flowNode, type, null) { }
        public FlowNodeException(string flowNode, string type, System.Exception inner) : base(string.Format(MESSAGE, flowNode, type), inner) { }
    }
}
