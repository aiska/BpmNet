using System;

namespace BPMNET.EntityCore.Entity
{
    public class ProcessInstanceVariable : ProcessVariableBase
    {
        public ProcessInstanceVariable()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid ProcessInstanceKey { get; set; }
    }
}
