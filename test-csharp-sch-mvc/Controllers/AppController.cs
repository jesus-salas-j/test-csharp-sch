using System.Text;
using Microsoft.AspNetCore.Mvc;
using test_csharp_sch_application.contracts;
using test_csharp_sch_domain.entities;
using test_csharp_sch_domain.enums;

namespace testcsharpschmvc.Controllers
{
    public class AppController : Controller
    {
        private readonly IUsers _usersService;

        public AppController(IUsers usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Page1()
        {
            HttpContext.Session.TryGetValue("Username", out byte[] usernameBytes);
            User user = GetUserFrom(usernameBytes);

            if (user == null || user.Role != Roles.PAGE_1)
            {
                return Forbidden();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Page2()
        {
            HttpContext.Session.TryGetValue("Username", out byte[] usernameBytes);
            User user = GetUserFrom(usernameBytes);

            if (user == null || user.Role != Roles.PAGE_2)
            {
                return Forbidden();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Page3()
        {
            HttpContext.Session.TryGetValue("Username", out byte[] usernameBytes);
            User user = GetUserFrom(usernameBytes);

            if (user == null || user.Role != Roles.PAGE_3)
            {
                return Forbidden();
            }

            return View();
        }


        private User GetUserFrom(byte[] usernameBytes)
        {
            return _usersService.GetUser
            (
                username: usernameBytes == null
                    ? ""
                    : Encoding.UTF8.GetString(usernameBytes, 0, usernameBytes.Length)
            );
        }

        private StatusCodeResult Forbidden()
        {
            return StatusCode(403);
        }
    }
}
