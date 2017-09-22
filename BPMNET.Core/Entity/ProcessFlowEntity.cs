using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core.Entity
{
    public interface ProcessFlowEntity<TKey>
    {
        TKey ProcessFlowId { get; set; }
        TKey ProcessInstanceId { get; set; }
        TKey FlowFrom { get; set; }
        TKey FlowTo { get; set; }
    }
}
