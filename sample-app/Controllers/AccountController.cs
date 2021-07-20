using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    // Auth : Login , Logout and Register
    [Route("Account")] // Common Prefix
    public class AccountController : Controller
    {
        // Manage the User
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [Route("Login/{username:minlength(4)}/{password:minlength(4)}")]
        public IActionResult Login(string username, string password)
        {
            return Content("Login Page");
        }


        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            // If the Register information is InValid  Then show same view
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            // If its valid the Add New User
            // UserName Null
            var applicationUser = _mapper.Map<ApplicationUser>(register);

            

            // While Creating UserName Mandatory
            var result =await _userManager.CreateAsync(applicationUser, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description); // Logging
                }
                return View(register);
            }

            await _userManager.AddToRoleAsync(applicationUser, "User");
            return RedirectToAction("Index", "Home");

        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            return Content("Logout Page");
        }
    }
}
