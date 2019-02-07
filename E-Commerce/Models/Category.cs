using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual List<Category> ChildCategory { get; set; }

    }
}