using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Colour { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int ProductQuantity { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [MaxLength(1000)]
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}