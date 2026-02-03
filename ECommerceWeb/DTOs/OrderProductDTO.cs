using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWeb.DTOs
{
    public class OrderProductDTO : OrderDTO
    {
        public List<OrderDetailDTO> OrderDetails { get; set; }
        public OrderProductDTO()
        {
            OrderDetails = new List<OrderDetailDTO>();
        }
    }
}