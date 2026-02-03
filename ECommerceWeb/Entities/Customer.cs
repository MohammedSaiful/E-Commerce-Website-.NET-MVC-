using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        // Navigation
        public virtual ICollection<Order> Orders { get; set; }
    }
}