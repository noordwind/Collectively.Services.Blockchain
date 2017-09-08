using Microsoft.AspNetCore.Mvc;

namespace Collectively.Services.Blockchain.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() 
            => Content("Welcome to the Collectively.Services.Blockchain API!.");
    }
}