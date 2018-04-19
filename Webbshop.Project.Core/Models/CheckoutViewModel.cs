using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Models
{
    public class CheckoutViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }

        public int Productid { get; set; }
        public int Price { get; set; }
        public  List<CartViewModel> Cart { get; set; }
    }

}
