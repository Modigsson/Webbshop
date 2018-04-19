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
        private readonly CartRepository cartRepository;

        public CheckoutService(CheckoutRepository checkoutRepository, CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
            this.checkoutRepository = checkoutRepository;
        }

        public void ToOrder(string Firstname, string Lastname, int Phonenumber, string Email, string Adress, string City, int Zipcode)
        {
            this.checkoutRepository.ToCheckout(Firstname, Lastname, Phonenumber, Email, Adress, City, Zipcode);
        }

        public CheckoutViewModel GetAll( string Id)
        {
            var cart = this.cartRepository.GetAll( Id);
            var checkoutModel = new CheckoutViewModel { Cart = cart };

            return checkoutModel;
        }
    }
}
