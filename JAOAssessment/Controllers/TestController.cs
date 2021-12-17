using Microsoft.AspNetCore.Mvc;

namespace JAOAssessment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");
        }

    }
}

