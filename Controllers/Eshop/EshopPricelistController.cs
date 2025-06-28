using APIGW.Services.Eshop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

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

        /// <summary>
        /// Updates external pricelists from the source database
        /// </summary>
        /// <returns>Update status and timestamp</returns>
        /// <response code="200">Update completed successfully</response>
        /// <response code="400">Configuration error</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePricelists()
        {
            _logger.LogInformation("Pricelist update requested");

            try
            {
                await _pricelistsService.UpdateAsync();
                var result = new
                {
                    success = true,
                    timestamp = DateTime.Now,
                    message = "Pricelist updated successfully",
                };

                _logger.LogInformation("Pricelist update completed successfully");
                return Ok(result);

            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Configuration error during pricelist update");
                return BadRequest(new { error = "Configuration error", details = ex.Message });
            }
            catch (MySqlException ex)
            {
                _logger.LogError(ex, "Database error during pricelist update");
                return StatusCode(500, new { error = "Database error", details = "Internal server error" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during pricelist update");
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
    }
}
