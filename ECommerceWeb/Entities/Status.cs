using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Entities
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation
        public virtual ICollection<Order> Orders { get; set; }
    }
}