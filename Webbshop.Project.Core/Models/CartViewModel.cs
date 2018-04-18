using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
    }
}
