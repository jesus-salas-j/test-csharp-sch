using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_csharp_sch_application.contracts;
using test_csharp_sch_domain.entities;

namespace test_csharp_sch_mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticator _authenticator;
        private readonly IUsers _users;
        private readonly INavigation _navigation;

        public LoginController(IAuthenticator authenticator, IUsers users,
            INavigation navigation)
        {
            _authenticator = authenticator;
            _users = users;
            _navigation = navigation;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View("Index");
        }

        [HttpPost]
        [ActionName("Signin")]
        public IActionResult Signin_Post([FromForm]string username, [FromForm]string password)
        {
            if (_authenticator.AreRegistered(new Credentials(username, password)))
            {
                HttpContext.Session.SetString("Username", username);
                User user = _users.GetUser(username);

                switch (_navigation.GetFirstAllowedPageFrom(user.Role))
                {
                    case Pages.PAGE_1:
                        return RedirectToAction("Page1", "App");
                    case Pages.PAGE_2:
                        return RedirectToAction("Page2", "App");
                    case Pages.PAGE_3:
                        return RedirectToAction("Page3", "App");
                }
            }

            return Unauthorized();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Signin", "Login");
        }
    }
}
