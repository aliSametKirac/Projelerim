using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CaseModels
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}
