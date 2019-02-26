using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual Cart Cart { get; set; } 
        public Customer()
        {
           
        }
    }
    
}