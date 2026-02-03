# E-Commerce Web Application

A simple E-Commerce web application built using **ASP.NET MVC** and **Entity Framework**, allowing users to browse products, manage their cart, place orders, and for admins to approve or manage orders.

---

## Features

### For Customers:
- Browse available products.
- Add products to the cart.
- Increase/decrease quantity in cart.
- Place orders.
- View order history and details.
- Cancel orders before approval.

### For Admins:
- View all orders placed by users.
- Approve or cancel user orders.
- Track order status from Pending Approval → Delivered.

### Order Status Flow:
1. PendingApproval  
2. Approved  
3. Processing  
4. OnTheWay  
5. Delivered  
6. CancelledByUser / CancelledByAdmin

---

## Technologies Used
- **Backend:** ASP.NET MVC (C#)
- **Database:** SQL Server / Entity Framework (Code First)
- **Frontend:** HTML, CSS, Bootstrap
- **Mapping:** AutoMapper for DTOs
- **Authentication:** Session-based user login system
- **Version Control:** Git & GitHub

---

## Project Structure
ECommerceWeb/
│
├── Controllers/ # MVC Controllers (Order, Customer, Login, Admin)
├── Models/ # Entity models (Product, Order, User, etc.)
├── DTOs/ # Data Transfer Objects
├── Views/ # Razor views for all pages
├── Auth/ # Authorization attribute for login
├── Scripts/ # JS and libraries
├── Content/ # CSS styles
└── DataAccessFactory/ # Database access and context