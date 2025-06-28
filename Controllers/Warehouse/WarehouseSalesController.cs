using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIGW.Controllers.Warehouse
{
    [ApiController]
    [Authorize]
    [Route("api/warehouse/sales")]
    public class WarehouseSalesController : ControllerBase
    {
        private readonly ILogger<WarehouseSalesController> _logger;

        public WarehouseSalesController(ILogger<WarehouseSalesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting warehouse goods.");
            // Call service to get goods
            return Ok(/* goods list */);
        }
    }
}