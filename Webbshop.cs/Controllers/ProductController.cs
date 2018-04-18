using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Webbshop.cs.Controllers

{
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
                Product = connection.Query<ProductViewModel>("select * from Product").ToList();
            }
            return View(Product);
        }
    }
}