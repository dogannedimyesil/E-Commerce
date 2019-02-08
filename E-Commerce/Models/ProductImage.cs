using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public virtual Product Product { get; set; }
    }
}