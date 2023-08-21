using Microsoft.AspNetCore.Mvc;

namespace CommandsService
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }
        
        //http://acme.com/api/c/platforms/
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Platforms Controller" );
        }

    }
}