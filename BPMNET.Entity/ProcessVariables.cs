using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessVariables<TKey>
    {
        public long Id { get; set; }
        public TKey ProcessInstanceId { get; set; }
        public TKey ProcessTaskId { get; set; }
        public TKey ProcessExecutionId { get; set; }
        public bool? BitValue { get; set; }
        public long? LongValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public double? FloatValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public string StringValue { get; set; }
    }
}
