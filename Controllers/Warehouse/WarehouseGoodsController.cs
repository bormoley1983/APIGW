using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIGW.Controllers.Warehouse
{
    [ApiController]
    [Authorize]
    [Route("api/warehouse/goods")]
    public class WarehouseGoodsController : ControllerBase
    {
        private readonly ILogger<WarehouseGoodsController> _logger;

         public WarehouseGoodsController(ILogger<WarehouseGoodsController> logger)
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