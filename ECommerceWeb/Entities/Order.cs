using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public DateTime Date { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public double Total { get; set; }

        // Navigation
        public virtual Status Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}