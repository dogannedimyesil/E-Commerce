using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public OrderDetail()
        {

        }
    }
}