using System;

namespace BpmNet.Core
{
    /// <summary>
    /// Provides various settings needed to configure the BpmNet core services.
    /// </summary>
    public class BpmNetCoreOptions
    {
        /// <summary>
        /// Gets or sets the type corresponding to the default Definition entity,
        /// </summary>
        public Type DefaultDefinitionType { get; set; }

        public Type DefaultProcessType { get; set; }

        public Type DefaultProcessInstanceType { get; set; }

        public Type DefaultProcessInstanceFlowType { get; set; }
        
        public Type DefaultHistoryFlowType { get; set; }

        public double CacheTime { get; set; } = 60000;
    }
}
