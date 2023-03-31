using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CaseModels
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TamAdi
        {
            get { return Adi + " " + Soyadi; }
        }
        public string EMail { get; set; }
        public string Gorevi { get; set; }

        [Required]
        [Display(Name = "Sirket")]
        public int SirketId { get; set; }
        [ForeignKey("SirketId")]
        [ValidateNever]
        public Sirket Sirket { get; set; }
    }
}
