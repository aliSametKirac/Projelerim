using Case.Areas.Users.Models;
using CaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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




        //public async Task OnGetAsync(string returnUrl = null)
        //{
        //    if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
        //    {
        //        _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
        //        _roleManager.CreateAsync(new IdentityRole(SD.Role_Yonetici)).GetAwaiter().GetResult();
        //        _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();
        //        _roleManager.CreateAsync(new IdentityRole(SD.Role_Kullanici)).GetAwaiter().GetResult();
        //    }
        //}
    }
}
