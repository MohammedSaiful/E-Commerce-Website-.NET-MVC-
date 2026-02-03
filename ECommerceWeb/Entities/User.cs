using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        // Admin / Customer
        [Required]
        public string Type { get; set; }

        // Nullable FK
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        // Navigation
        public virtual Customer Customer { get; set; }
    }
}