using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIGW.Controllers.Warehouse
{
    [ApiController]
    [Authorize]
    [Route("api/warehouse/customers")]
    public class WareHouseCustomersController : ControllerBase
    {
        private readonly ILogger<WareHouseCustomersController> _logger;

        public WareHouseCustomersController(ILogger<WareHouseCustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting warehouse customers.");
            // Call service to get goods
            return Ok(/* goods list */);
        }
    }
}