using Microsoft.AspNetCore.Mvc;
using testcsharpschmvc.Models;

namespace test_csharp_sch_mvc.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Signin()
        {
            SigninViewModel model = new SigninViewModel();
            return View("Index", model);
        }

        [HttpPost]
        [ActionName("Signin")]
        public IActionResult Signin_Post([FromForm]string username, [FromForm]string password)
        {
            SigninViewModel model = new SigninViewModel(username);
            return View("Index", model);
        }
    }
}
