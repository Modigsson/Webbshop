using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Webbshop.cs.Controllers

{
    using System;
    using System.Data.SqlClient;
    using Webbshop.Project.Core.Models;
    using Webbshop.Project.Core.Repositories.Implementations;
    using Webbshop.Project.Core.Services;

    public class ProductController : Controller
    {
        private static List<ProductViewModel> Product = new List<ProductViewModel>();

        private readonly ProductService productService;

        private string connectionString;

        public ProductController(IConfiguration configuration)
        {

            this.connectionString = configuration.GetConnectionString("ConnectionString");

            this.productService = new ProductService(new ProductRepository(configuration.GetConnectionString("ConnectionString")));
        }

        public IActionResult Index()
        {
            List<ProductViewModel> Product;

            using (var connection = new SqlConnection(this.connectionString))
            {
                Product = connection.Query<ProductViewModel>("SELECT * from Shop").ToList();
            }
            return View(Product);
        }

        [HttpPost]
        public IActionResult AddToCart(string Id)
        {
            var cartId = this.GetCartCookie();

            using (var connection = new SqlConnection(this.connectionString))
            {

                var ProductAdd = connection.QuerySingleOrDefault<ProductViewModel>("SELECT * FROM Shop WHERE Id = @Id", new { Id });
                connection.Execute("INSERT INTO Cart (Productid, Price, Customerid) VALUES (@Productid, @Price, @Customerid)", new { Productid = ProductAdd.Id, Price = ProductAdd.Price, Customerid = cartId });
            }
            return RedirectToAction("Index");
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
    }
}