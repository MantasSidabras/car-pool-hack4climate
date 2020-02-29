using Microsoft.AspNetCore.Mvc;

namespace CarPool.Trip.Web
{
    [ApiController]
    public class TripController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("Healthy");
        }
    }
}
