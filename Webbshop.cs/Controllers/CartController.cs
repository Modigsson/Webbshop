using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webbshop.Project.Core.Repositories.Implementations;
using Dapper;
using Webbshop.Project.Core.Models;
using Webbshop.Project.Core.Services;
using System.Data.SqlClient;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Webbshop.cs.Controllers
{
    public class CartController : Controller
    {
        private static List<CartViewModel> cart = new List<CartViewModel>();
        private readonly string connectionString;
        private CartService cartService;

        public CartController(IConfiguration configuration)
        {
            
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(
            new CartRepository(
            configuration.GetConnectionString("ConnectionString")));
        }


        public IActionResult Index()
        {
            var cartId = this.GetCartCookie();
            List<CartViewModel> cart;
            using (var connection = new SqlConnection(this.connectionString))
            {
                cart = connection.Query<CartViewModel>("SELECT Shop.Product, Shop.Price, Shop.Picture, Shop.Shopid FROM Shop JOIN Cart ON Cart.Productid = Shop.Id WHERE Customerid = @Customerid", new { Customerid = cartId }).ToList();
            }
            return View(cart);
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
            public IActionResult Add(ProductViewModel model)
            {
                this.cartService.ToCart(model.Id);
                return RedirectToAction("Index");
            }
    }
}