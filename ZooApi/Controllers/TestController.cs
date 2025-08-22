using Microsoft.AspNetCore.Mvc;

namespace ZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Test controller is working!", timestamp = DateTime.UtcNow });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { id = id, message = $"Test endpoint with ID: {id}", timestamp = DateTime.UtcNow });
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new { status = "healthy", service = "ZooApi", timestamp = DateTime.UtcNow });
        }
    }
}