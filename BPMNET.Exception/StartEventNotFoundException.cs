using System;

namespace BPMNET.Exception
{
    [Serializable]
    public class EventNotFoundException : System.Exception
    {
        private const string MESSAGE = "{0} in process id '{1}' Not Found.";
        public EventNotFoundException(string stringEvent, int processId) : this(stringEvent, processId, null) { }
        public EventNotFoundException(string stringEvent, int processId, System.Exception inner) : base(string.Format(MESSAGE, stringEvent, processId.ToString()), inner) { }
    }
}
