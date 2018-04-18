using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Models
{
    public class CartViewModel
    {
        public int Productid { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
