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
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            // Is the Model Valid : Return Login View
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            // Logic For Login
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email,
                loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName and Password");
                return View();
            }
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
            var result = await _userManager.CreateAsync(applicationUser, register.Password);
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
