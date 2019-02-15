using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int CustomerId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
    }
}