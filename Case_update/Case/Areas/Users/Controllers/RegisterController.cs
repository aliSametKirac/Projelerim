using Case.Areas.Users.Models;
using CaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Case.Areas.Users.Controllers
{
    [Area("Users")]
    [Route("Users/[controller]/[action]/{id?}")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser r = new ApplicationUser()
                {
                    UserName = p.UserName,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail
                };


                if (p.ConfingPassword == p.Password)
                {
                    var result = await _userManager.CreateAsync(r, p.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return View(p);
        }
    }
}
