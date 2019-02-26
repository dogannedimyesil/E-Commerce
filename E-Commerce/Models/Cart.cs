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
        public DateTime CreateDate { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<CartDetail> CartDetail { get; set; } 

        public Cart()
        {
            CreateDate = DateTime.Now;
        }

        public decimal SubTotal
        {
            get
            {
                return Products == null ? 0 : CartDetail.Sum(x => x.Total);
            }
        }

    }
}