using BpmNet.EntityFrameworkCore.Models;
using BpmNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BpmNet.Api.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessInstanceController : ControllerBase
    {
        private readonly IBpmNetProcessService _processInstanceService;

        public ProcessInstanceController(IBpmNetProcessService processInstanceService)
        {
            _processInstanceService = processInstanceService;
        }

        [HttpPost("StartProcess")]
        public async Task<IActionResult> CreateProcess(string processId, string bussinessKey)
        {
            var instance = await _processInstanceService.StartProcessAsync(processId, bussinessKey, default);
            return Ok(instance);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetProcessInstanceAsync(string processId)
        {
            var instances = await _processInstanceService.ListProcessInstanceAsync(query =>
            {
                return query.Cast<BpmNetProcessInstance>().Include(t => t.Flows).Where(t => t.ProcessId == processId);
            }, default);
            return Ok(instances);
        }

        [HttpGet("Flow")]
        public async Task<IActionResult> GetProcessInstanceFlowAsync(string processId, string flowId)
        {
            var instances = await _processInstanceService.ListProcessInstanceAsync(query =>
            {
                return query.Cast<BpmNetProcessInstance>().Where(t => t.ProcessId == processId && t.Flows.Any(flow => flow.FlowId == flowId));
            }, default);
            return Ok(instances);
        }
    }
}
