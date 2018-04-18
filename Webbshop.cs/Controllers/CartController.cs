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
            List<CartViewModel> cart;
            using (var connection = new SqlConnection(this.connectionString))
            {
                cart = connection.Query<CartViewModel>("SELECT Product.Id, Product.Product, Product.Price, Product.Picture").ToList();
            }
            return View(cart);
        }
    }
}