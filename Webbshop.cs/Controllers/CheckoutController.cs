using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webbshop.Project.Core.Models;
using Webbshop.Project.Core.Repositories.Implementations;
using Webbshop.Project.Core.Services;

namespace Webbshop.cs.Controllers
{
    public class CheckoutController : Controller
    {
        private static List<CheckoutViewModel> checkout = new List<CheckoutViewModel>();
        private readonly string connectionString;
        private CheckoutService checkoutService;

        public CheckoutController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.checkoutService = new CheckoutService(new CheckoutRepository(this.connectionString));
        }

        public IActionResult Index()
        {
            var Cart = this.checkoutService.GetAll();

            return View(Cart);
        }

        public string GetCartCookie()
        {
            var cartId = Request.Cookies["CartID"];
            if (cartId == null)
            {
                Guid guid = Guid.NewGuid();
                Response.Cookies.Append("CartID", guid.ToString());
                return guid.ToString();
            }

            return cartId;
        }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            this.checkoutService.ToOrder(model.Firstname, model.Lastname, model.Phonenumber, model.Email, model.Adress, model.City, model.Zipcode);
            return View("Index");
        }
    }
}