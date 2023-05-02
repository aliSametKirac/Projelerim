using CaseUtility.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseModels.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your Description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter your Category.")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter your Unit.")]
        public int Unit { get; set; }
        [Required(ErrorMessage = "Please enter your UnitPrice.")]
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount
        {
            get { return Unit * UnitPrice; }
        }
        [Required(ErrorMessage = "Please enter your Status.")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "Please enter your Create Date.")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Please enter your Update Date.")]
        public DateTime UpdateDate { get; set; }
    }
}
