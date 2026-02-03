using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Auth
{
    public class Logged: AuthorizeAttribute
    {
        // Check if user is logged in
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session["User"] != null;
        }

        // Redirect unauthorized requests to Login page
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" },
                    { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                }
            );
        }
    }
}