using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Models
{
    class CheckoutViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
    }
}
