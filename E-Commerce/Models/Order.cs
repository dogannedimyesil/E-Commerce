using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public decimal SubTotal { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}