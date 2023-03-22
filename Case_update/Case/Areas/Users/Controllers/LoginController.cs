using Case.Areas.Users.Models;
using CaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;

namespace Case.Areas.Users.Controllers
{
    [Area("Users")]
    [Route("Users/[controller]/[action]/{id?}")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "",Route = "Default" });
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı şifre girdiniz..");
                }
            }

            return View(p);
        }
    }
}
