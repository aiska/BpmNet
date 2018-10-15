using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BpmNet.Api.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeployController : ControllerBase
    {
        private readonly IBpmNetDefinitionService _definitionService;
        public DeployController(IBpmNetDefinitionService definitionService)
        {
            _definitionService = definitionService;
        }

        [HttpPost]
        public async Task<IActionResult> DeployAsync(IFormFile bpmnFile)
        {
            using (var stream = bpmnFile.OpenReadStream())
            {
                await _definitionService.DeployAsync(stream, default);
            }
            return Ok();
        }
    }
}
