using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webbshop.cs.Models;
using Microsoft.Extensions.Configuration;

namespace Webbshop.cs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Testing page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
