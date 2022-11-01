
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public Double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public Double FinalPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public Double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public Double Price50 { get; set; }
        [Required]
        [Range(1,10000)]
        public Double Price100 { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }
        [Required]
        [ValidateNever]

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }
       
    }
}
