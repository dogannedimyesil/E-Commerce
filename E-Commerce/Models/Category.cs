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
        [Key, ForeignKey("ParentCategory")]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        
        public List<Category> SubCategories { get; set; }
        public Category ParentCategory { get; set; }
    }

}