using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_csharp_sch_application.contracts;
using testcsharpschmvc.Models;

namespace test_csharp_sch_mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticator _authenticator;

        public LoginController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

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
            if (_authenticator.IsAllowed(username, password))
            {
                HttpContext.Session.SetString("Username", username);
                SigninViewModel model = new SigninViewModel(username);
                return View("Index", model);
            }

            return Unauthorized();
        }
    }
}
