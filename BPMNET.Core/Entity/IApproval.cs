using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IApproval<TKey>
    {
        int ApprovalId { get; set; }
        string Assignee { get; set; }
        string Group { get; set; }
        int Level { get; set; }
        int Order { get; set; }
        string Criteria { get; set; }
    }
}
