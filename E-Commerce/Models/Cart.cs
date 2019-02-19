using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual List<Product> Products { get; set; } 
        public virtual List<Customer> Customers { get; set; }  
        public virtual CartDetail CartDetail { get; set; }
        public bool IsActive { get; set; }
    }
}