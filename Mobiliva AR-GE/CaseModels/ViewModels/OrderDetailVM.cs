using CaseModels.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseModels.ViewModels
{
    public class OrderDetailVM
    {
        public OrderDetail OrderDetail { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> OrderList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ProductList { get; set; }

    }
}
