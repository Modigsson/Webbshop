using System;
using System.Collections.Generic;
using System.Text;
using Webbshop.Project.Core.Models;
using Webbshop.Project.Core.Repositories.Implementations;

namespace Webbshop.Project.Core.Services
{
    public class CheckoutService
    {
        private readonly CheckoutRepository checkoutRepository;
        public CheckoutService(CheckoutRepository checkoutRepository)
        {
            this.checkoutRepository = checkoutRepository;
        }

        public void ToOrder(string Firstname, string Lastname, int Phonenumber, string Email, string Adress, string City, int Zipcode)
        {
            this.checkoutRepository.ToOrder(Firstname, Lastname, Phonenumber, Email, Adress, City, Zipcode);
        }
    }
}
