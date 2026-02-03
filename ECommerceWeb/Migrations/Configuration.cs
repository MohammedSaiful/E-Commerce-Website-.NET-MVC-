namespace ECommerceWeb.Migrations
{
    using ECommerceWeb.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerceWeb.DataAccessFactory.ECommerceDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerceWeb.DataAccessFactory.ECommerceDB context)
        {
            // ---------- STATUS ----------
            context.Statuses.AddOrUpdate(
                s => s.Name,
                new Status { Id = 1, Name = "Pending" },
                new Status { Id = 2, Name = "Confirmed" },
                new Status { Id = 3, Name = "Shipped" },
                new Status { Id = 4, Name = "Delivered" }
            );
            context.SaveChanges();

            // ---------- CUSTOMERS ----------
            context.Customers.AddOrUpdate(
                c => c.Email,
                new Customer { Id = 1, Name = "Rahim", Username = "rahim01", Address = "Dhaka", Email = "rahim@gmail.com", Phone = "0170000001" },
                new Customer { Id = 2, Name = "Karim", Username = "karim02", Address = "Chittagong", Email = "karim@gmail.com", Phone = "0170000002" },
                new Customer { Id = 3, Name = "Jamal", Username = "jamal03", Address = "Sylhet", Email = "jamal@gmail.com", Phone = "0170000003" },
                new Customer { Id = 4, Name = "Salma", Username = "salma04", Address = "Khulna", Email = "salma@gmail.com", Phone = "0170000004" }
            );
            context.SaveChanges();

            // ---------- USERS ----------
            context.Users.AddOrUpdate(
                u => u.Username,
                new User { Id = 1, Name = "Admin", Username = "admin", Password = "admin123", Email = "admin@shop.com", Type = "Admin" },
                new User { Id = 2, Name = "Rahim", Username = "rahim01", Password = "1234", Email = "rahim@gmail.com", Type = "Customer", CustomerId = 1 },
                new User { Id = 3, Name = "Karim", Username = "karim02", Password = "1234", Email = "karim@gmail.com", Type = "Customer", CustomerId = 2 },
                new User { Id = 4, Name = "Salma", Username = "salma04", Password = "1234", Email = "salma@gmail.com", Type = "Customer", CustomerId = 4 }
            );
            context.SaveChanges();

            // ---------- PRODUCTS ----------
            context.Products.AddOrUpdate(
                p => p.Name,
                new Product { Id = 1, Name = "Laptop", Qty = 10, Price = 80000 },
                new Product { Id = 2, Name = "Mobile Phone", Qty = 20, Price = 25000 },
                new Product { Id = 3, Name = "Headphone", Qty = 30, Price = 3000 },
                new Product { Id = 4, Name = "Keyboard", Qty = 15, Price = 1500 }
            );
            context.SaveChanges();

            // ---------- ORDERS ----------
            context.Orders.AddOrUpdate(
                o => o.Id,
                new Order { Id = 1, CustomerId = 1, StatusId = 1, Date = DateTime.Now.AddDays(-3), Total = 83000 },
                new Order { Id = 2, CustomerId = 2, StatusId = 2, Date = DateTime.Now.AddDays(-2), Total = 25000 },
                new Order { Id = 3, CustomerId = 3, StatusId = 3, Date = DateTime.Now.AddDays(-1), Total = 4500 },
                new Order { Id = 4, CustomerId = 4, StatusId = 4, Date = DateTime.Now, Total = 1500 }
            );
            context.SaveChanges();

            // ---------- ORDER DETAILS ----------
            context.OrderDetails.AddOrUpdate(
                od => od.Id,
                new OrderDetail { Id = 1, OId = 1, PId = 1, Qty = 1, Price = 80000 },
                new OrderDetail { Id = 2, OId = 1, PId = 3, Qty = 1, Price = 3000 },
                new OrderDetail { Id = 3, OId = 2, PId = 2, Qty = 1, Price = 25000 },
                new OrderDetail { Id = 4, OId = 3, PId = 4, Qty = 3, Price = 4500 }
            );
            context.SaveChanges();
        }
    }
}
