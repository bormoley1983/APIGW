using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIGW.Controllers.Warehouse
{
    [ApiController]
    [Authorize]
    [Route("api/warehouse/orders")]
    public class WarehouseOrdersController : ControllerBase
    {
        private readonly ILogger<WarehouseOrdersController> _logger;

        public WarehouseOrdersController(ILogger<WarehouseOrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting warehouse orders.");
            // Call service to get goods
            return Ok(/* goods list */);
        }
    }
}