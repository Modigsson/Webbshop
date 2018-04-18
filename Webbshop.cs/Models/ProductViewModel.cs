using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbshop.cs.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
    }
}
