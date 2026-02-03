using ECommerceWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Auth
{
    public class AdminLogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["User"] as User;
            if (user != null && user.Type == "Admin")
                return true;

            return false;
        }
    }
}