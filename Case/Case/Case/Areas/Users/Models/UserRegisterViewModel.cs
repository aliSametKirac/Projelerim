using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Case.Areas.Users.Models
{
    public class UserRegisterViewModel
    {

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string? Role { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords not compatible")]
        public string ConfingPassword { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }

    }
}
