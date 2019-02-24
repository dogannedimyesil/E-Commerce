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
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int ProductQuantity { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public Size Size { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<Cart> Cart { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
      
    }
    public enum Size
    {
        XS,
        S,
        M,
        L,
        XL
    }
}