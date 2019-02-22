using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get
            {
                if (Product == null)
                    return 0;
                else
                return Product.Price * Quantity;
            } }
       
    }
}