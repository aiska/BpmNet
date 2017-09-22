using BPMNET.Core;
using BPMNET.Core.Variable;

namespace BPMNET.Entity
{
    public class ProcessVariableEntity : IProcessVariable<int>
    {
        public int ProcessVariablesId { get; set; }
        public int ProcessInstanceId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string StructureRef { get; set; }
    }
}
