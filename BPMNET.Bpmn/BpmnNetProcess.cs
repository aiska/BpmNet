using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Bpmn
{
    public class BpmnNetProcess
    {
        private tProcess _process;
        public BpmnNetProcess(tProcess process)
        {
            _process = process;
        }

        public tFlowElement GetFlowElement(string flowId)
        {
            flowId.ThrowIfNull();
            return _process.Items.Single(t => t.id.Equals(flowId));
        }

        public bool TryGetFlowElement(string id, out tFlowElement elm)
        {
            elm = null;
            if (id == null) return false;
            elm = _process.Items.FirstOrDefault(t => t.id.Equals(id));
            return (elm != null);
        }

        public tSequenceFlow GetSequenceFlow(string flowId)
        {
            flowId.ThrowIfNull();
            return _process.Items.OfType<tSequenceFlow>().Single(t => t.id.Equals(flowId));
        }

        public bool TryGetSequenceFlow(string id, out tSequenceFlow elm)
        {
            elm = null;
            if (id == null) return false;
            elm = _process.Items.OfType<tSequenceFlow>().FirstOrDefault(t => t.id.Equals(id));
            return (elm != null);
        }

        public IEnumerable<tProperty> GetProcessProperties(tDefinitions definition, string processId)
        {
            processId.ThrowIfNull();
            tProcess process = GetProcess(definition, processId);
            return process.property;
        }

    }
}
