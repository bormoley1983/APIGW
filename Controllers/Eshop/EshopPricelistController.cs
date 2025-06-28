using APIGW.Controllers.EshopManager;
using APIGW.Services.Eshop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIGW.Controllers.Eshop
{
    [ApiController]
    //[Authorize]
    [Route("api/eshop/pricelist")]
    public class EshopPricelistController : ControllerBase
    {
        private readonly ILogger<EshopPricelistController> _logger;
        private readonly EshopExternalPricelistsService _pricelistsService;
        
        public EshopPricelistController(
            ILogger<EshopPricelistController> logger,
            EshopExternalPricelistsService pricelistsService)
        {
            _logger = logger;
            _pricelistsService = pricelistsService;
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePricelists()
        {
            _logger.LogInformation("Updating external pricelists.");

            try
            {
                await _pricelistsService.UpdateAsync();
                return Ok(DateTime.Now);
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return StatusCode(500, $"Update failed: {ex.Message}");
            }
        }
    }
}
