using System;

namespace BPMNET.EntityCore
{
    public interface IAuditTrail
    {
        DateTime Inserted { get; set; }
        DateTime LastUpdated { get; set; }
        byte[] Timestamp { get; set; }
    }
}
