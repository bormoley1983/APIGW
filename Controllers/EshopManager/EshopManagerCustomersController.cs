using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIGW.Controllers.EshopManager
{
    [ApiController]
    [Authorize]
    [Route("api/eshopmanager/customers")]
    public class EshopManagerCustomersController : ControllerBase
    {
        private readonly ILogger<EshopManagerCustomersController> _logger;

        public EshopManagerCustomersController(ILogger<EshopManagerCustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting eshopmanager customers.");
            // Call service to get goods
            return Ok(/* goods list */);
        }

    }
}
