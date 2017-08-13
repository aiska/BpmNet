using BPMNET.Core.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class DefinitionVariable<TKey>
    {
        public TKey ProcessDefinitionId { get; set; }

        public TKey VariableName { get; set; }

        public EStoreType StoreType { get; set; }
    }
}
