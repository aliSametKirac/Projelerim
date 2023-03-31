using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Case.Areas.Users.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girmelisiniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre girmelisiniz.")]
        public string Password { get; set; }
    }
}
