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
        public Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int OrderQuantity { get; set; }
    }
}