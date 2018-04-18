using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Models
{
    class CartViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
