using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IUserTrail
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
