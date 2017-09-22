using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface ITimeTrail
    {
        DateTime UtcCreatedDate { get; set; }
        DateTime? UtcModifiedDate { get; set; }
    }
}
