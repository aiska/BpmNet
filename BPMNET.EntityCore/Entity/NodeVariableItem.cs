using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.EntityCore.Entity
{
    public class NodeVariableItem
    {
        public Guid Id { get; set; }
        public string VariableName { get; set; }
        public string DataType { get; set; }
        public Guid ProcessItemKey { get; set; }
    }
}
