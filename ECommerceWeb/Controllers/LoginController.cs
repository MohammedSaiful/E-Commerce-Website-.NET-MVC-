using ECommerceWeb.DataAccessFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    public class LoginController : Controller
    {
        ECommerceDB db = new ECommerceDB();

        [HttpGet]
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password, string ReturnUrl)
        {
            password = GetMd5Hash(password);

            var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                user.Password = null;
                Session["User"] = user;

                // Redirect back to previous page if ReturnUrl exists
                if (!string.IsNullOrEmpty(ReturnUrl))
                    return Redirect(ReturnUrl);

                // Redirect based on user type
                if (user.Type == "Admin")
                    return RedirectToAction("Orders", "Admin"); // Admin dashboard
                else // Customer
                    return RedirectToAction("Index", "Customer");
            }

            TempData["Msg"] = "Invalid username or password";
            TempData["Class"] = "danger";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        static string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = md5.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}