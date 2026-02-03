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
    public class OrderController : Controller
    {
        ECommerceDB db = new ECommerceDB();

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        // GET: Order
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            var products = GetMapper().Map<List<ProductDTO>>(data);
            return View(products);
        }
        public ActionResult AddToCart(int id)
        {
            var p = db.Products.Find(id);
            var pr = GetMapper().Map<ProductDTO>(p);
            pr.Qty = 1;

            List<ProductDTO> cart;

            if (Session["cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else
            {
                cart = (List<ProductDTO>)Session["cart"];
            }

            var existing = cart.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                existing.Qty++;
            }
            else
            {
                pr.Qty = 1;
                cart.Add(pr);
            }

            Session["cart"] = cart;


            return RedirectToAction("Index");

        }

        public ActionResult Increase(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty++;

            return RedirectToAction("ShowCart");

        }

        public ActionResult Decrease(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();


            if (p != null)
            {
                p.Qty--;
                if (p.Qty <= 0)
                    cart.Remove(p);
            }

            if (!cart.Any())
                Session["cart"] = null;

            return RedirectToAction("ShowCart"); ;
        }

        public ActionResult ShowCart()
        {
            if (Session["cart"] == null)
            {
                TempData["Msg"] = "Cart is Empty";
                return RedirectToAction("Index");
            }

            var cart = (List<ProductDTO>)Session["cart"];
            return View(cart);
        }
        [HttpPost]
        [Logged]
        public ActionResult PlaceOrder(double gTotal)
        {

            var user = (User)Session["User"];
            var order = new Order()
            {
                Total = gTotal,
                CustomerId = (int)user.CustomerId,
                StatusId = (int)OrderStatus.PendingApproval,
                Date = DateTime.Now,
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var cart = (List<ProductDTO>)Session["cart"];
            foreach (var item in cart)
            {
                var od = new OrderDetail()
                {
                    PId = item.Id,
                    Qty = item.Qty,
                    Price = item.Price,
                    OId = order.Id
                };
                db.OrderDetails.Add(od);
            }
            db.SaveChanges();
            Session["cart"] = null;
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Details(int id)
        {
            var od = db.Orders.Find(id);
            var mapper = CustomerController.GetMapper();
            var order = mapper.Map<OrderProductDTO>(od);
            return View(order);
        }
        public ActionResult CancelByUser(int id)
        {
            var order = db.Orders.Find(id);
            order.StatusId = (int)OrderStatus.CancelledByUser;
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }

}