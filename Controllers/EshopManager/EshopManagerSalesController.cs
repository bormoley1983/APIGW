using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIGW.Controllers.EshopManager
{
    [ApiController]
    [Authorize]
    [Route("api/eshopmanager/sales")]
    public class EshopManagerSalesController : ControllerBase
    {
        private readonly ILogger<EshopManagerSalesController> _logger;

        public EshopManagerSalesController(ILogger<EshopManagerSalesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting eshopmanager sales.");
            // Call service to get goods
            return Ok(/* goods list */);
        }
    }
}
