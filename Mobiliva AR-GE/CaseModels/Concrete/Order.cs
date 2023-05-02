using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseModels.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your Customer Name.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please enter your Customer Email.")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Please enter your Customer GSM.")]
        public string CustomerGSM { get; set; }
        [Required(ErrorMessage = "Please enter your Total Amount.")]
        public decimal TotalAmount { get; set; }
    }
}
