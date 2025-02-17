using Lamar.IoC.DLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lamar.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScopedServiceController : ControllerBase
    {
        private readonly IScopedService _scopedService;

        public ScopedServiceController(IScopedService scopedService)
        {
            _scopedService = scopedService;
        }

        [HttpGet(Name = "GetOperationId")]
        public IActionResult Get()
        {
            return Ok(new { OperationId = _scopedService.GetOperationId() });
        }
    }
}
