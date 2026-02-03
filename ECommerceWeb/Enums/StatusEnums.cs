using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Enums
{
    public enum OrderStatus
    {
        PendingApproval = 1,
        Approved,
        Processing,
        CancelledByUser,
        CancelledByAdmin,
        OnTheWay,
        Delivered


    }
    public class StatusEnums
    {
    }
}