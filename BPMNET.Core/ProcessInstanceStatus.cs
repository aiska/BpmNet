using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public  enum ProcessInstanceStatus
    {
        Active = 1,
        Suspended = 2,
        Canceled = 3,
        Completed = 9
    }
}
