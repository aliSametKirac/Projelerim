using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseModels
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Surname{ get; set; }
    }
}
