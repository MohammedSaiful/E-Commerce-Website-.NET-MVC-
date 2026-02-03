using AutoMapper;
using ECommerceWeb.Auth;
using ECommerceWeb.DataAccessFactory;
using ECommerceWeb.DTOs;
using ECommerceWeb.Entities;
using ECommerceWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    [AdminLogged]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        ECommerceDB db = new ECommerceDB();

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            return new Mapper(config);
        }

        // Pending orders list
        public ActionResult Orders()
        {
            var orders = db.Orders
                .Where(o => o.StatusId == (int)OrderStatus.PendingApproval)
                .ToList();

            var data = GetMapper().Map<List<OrderDTO>>(orders);
            return View(data);
        }

        // Approve order
        public ActionResult Approve(int id)
        {
            var order = db.Orders.Find(id);
            order.StatusId = (int)OrderStatus.Approved;
            db.SaveChanges();
            return RedirectToAction("Orders");
        }

        // Cancel order
        public ActionResult Cancel(int id)
        {
            var order = db.Orders.Find(id);
            order.StatusId = (int)OrderStatus.CancelledByAdmin;
            db.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}