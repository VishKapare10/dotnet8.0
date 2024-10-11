using Microsoft.AspNetCore.Mvc;
using FiltersDemo.Filters;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomActionFilter))]
    [ServiceFilter(typeof(CustomResultFilter))]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("Executing action");
            return Ok("Hello, World!");
        }

        [HttpGet("error")]
        public IActionResult GetError()
        {
            throw new Exception("This is an intentional exception.");
        }
    }
}
