using BpmNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpmNet.Api.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IBpmNetProcessService _processService;

    }
}
