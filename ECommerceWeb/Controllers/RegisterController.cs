using ECommerceWeb.DataAccessFactory;
using ECommerceWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    public class RegisterController : Controller
    {
        ECommerceDB db = new ECommerceDB();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer c, string username, string password)
        {
            if (db.Users.Any(u => u.Username == username))
            {
                TempData["Msg"] = "Username already exists";
                TempData["Class"] = "danger";
                return View();
            }

            db.Customers.Add(c);
            db.SaveChanges();

            User user = new User()
            {
                Name = c.Name,
                Username = username,
                Password = GetMd5Hash(password),
                Email = c.Email,
                Type = "Customer",
                CustomerId = c.Id
            };

            db.Users.Add(user);
            db.SaveChanges();

            TempData["Msg"] = "Registration successful. Please login.";
            TempData["Class"] = "success";

            return RedirectToAction("Index", "Login");
        }

        static string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = md5.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}