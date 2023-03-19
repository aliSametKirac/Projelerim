using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Case.Areas.Users.Models
{
    public class UserLoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
