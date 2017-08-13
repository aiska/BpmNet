using System;

namespace BPMNET.EntityCore.Entity
{
    public class ProcessTaskVariable : ProcessVariableBase
    {
        public ProcessTaskVariable()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid ProcessTaskKey { get; set; }
    }
}
