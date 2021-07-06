using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    // Auth : Login , Logout and Register
    [Route("Authorize")] // Common Prefix
    public class AccountController : Controller
    {
        [Route("Login/{username:minlength(4)}/{password:minlength(4)}")]
        public IActionResult Login(string username, string password)
        {
            return Content("Login Page");
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return Content("Register Page");
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            return Content("Logout Page");
        }
    }
}
