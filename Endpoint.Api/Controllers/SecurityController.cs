using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Api.Controllers
{
    [Route("&quotapi /[controller] & quot")]
    [ApiController]
    [Authorize]
    public class SecurityController : Controller
    {
        [HttpGet("&quotgetFruits & quot")]
        [AllowAnonymous]
        public ActionResult GetFruits()
        {
            List<string> mylist = new List<string>() { "&quotapples & quot, &quotbannanas & quot" };
            return Ok(mylist);
        }
        [HttpGet("&quotgetFruitsAuthenticated & quot")]
        public ActionResult GetFruitsAuthenticated()
        {
            List<string> mylist = new List<string>() { "&quotorganic apples & quot, &quotorganic bannanas & quot" };
            return Ok(mylist);
        }
    }
}
