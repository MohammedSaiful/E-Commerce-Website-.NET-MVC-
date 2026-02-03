using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Enums
{
    public enum OrderStatus
    {
        OrderPlaced = 1,       // Customer just placed order
        PendingApproval,        // Waiting for admin confirmation
        Processing,             // Admin confirmed and preparing order
        CancelledByUser,
        CancelledByAdmin,
        OnTheWay,
        Delivered


    }
    public class StatusEnums
    {
    }
}