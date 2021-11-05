using Microsoft.AspNetCore.Mvc;

namespace GenericImporter.API.Controllers
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
