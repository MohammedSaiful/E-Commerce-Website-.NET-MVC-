using ECommerceWeb.Auth;
using ECommerceWeb.DataAccessFactory;
using ECommerceWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    [Logged]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        ECommerceDB db = new ECommerceDB();

        // Show all pending orders
        public ActionResult PendingOrders()
        {
            var orders = db.Orders
                           .Where(o => o.StatusId == (int)OrderStatus.PendingApproval)
                           .ToList();
            return View(orders);
        }

        // Approve order
        public ActionResult ApproveOrder(int id)
        {
            var order = db.Orders.Find(id);
            order.StatusId = (int)OrderStatus.Processing; // Admin confirmed
            db.SaveChanges();
            return RedirectToAction("PendingOrders");
        }

        // Cancel order
        public ActionResult CancelOrder(int id)
        {
            var order = db.Orders.Find(id);
            order.StatusId = (int)OrderStatus.CancelledByAdmin;
            db.SaveChanges();
            return RedirectToAction("PendingOrders");
        }
    }
}