using Microsoft.AspNetCore.Mvc;

namespace testcsharpschmvc.Controllers
{
    public class AppController : Controller
    {
        [HttpGet]
        public IActionResult Page1()
        {
            if (!HttpContext.Session.TryGetValue("Username", out byte[] username)) 
            {
                return new BadRequestResult();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Page2()
        {
            if (!HttpContext.Session.TryGetValue("Username", out byte[] username))
            {
                return new BadRequestResult();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Page3()
        {
            if (!HttpContext.Session.TryGetValue("Username", out byte[] username))
            {
                return new BadRequestResult();
            }

            return View();
        }
    }
}
