using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Qty { get; set; }

        public double Price { get; set; }

        // Navigation
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}