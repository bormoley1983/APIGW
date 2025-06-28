using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIGW.Controllers.EshopManager
{
    [ApiController]
    [Authorize]
    [Route("api/eshopmanager/goods")]
    public class EshopManagerGoodsController : ControllerBase
    {
        private readonly ILogger<EshopManagerGoodsController> _logger;

        public EshopManagerGoodsController(ILogger<EshopManagerGoodsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting eshopmanager goods.");
            // Call service to get goods
            return Ok(/* goods list */);
        }
    }
}
