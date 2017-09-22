using System;

namespace BPMNET.Core
{
    public interface IAuditTrail : ITimeTrail, IUserTrail
    {
    }
}
