using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseModels.ViewModels
{
    public class KullaniciVM
    {
        public Kullanici Kullanici { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SirketList { get; set; }
    }
}
