using Microsoft.AspNetCore.Mvc;

namespace test_csharp_sch_mvc.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Signin()
        {
            return View("Index");
        }

    }
}
