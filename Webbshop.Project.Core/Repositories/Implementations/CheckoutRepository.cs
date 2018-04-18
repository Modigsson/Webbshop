using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Repositories.Implementations
{
    public class CheckoutRepository
    {
        private readonly CheckoutRepository checkoutRepository;

        public CheckoutRepository(CheckoutRepository checkoutRepository)
        {
            this.checkoutRepository = checkoutRepository;
        }

        public void Order(string Firstname, string Lastname, int Phonenumber, string Email, string Adress, string City, int Zipcode)
        {
            this.checkoutRepository.ToOrder(Firstname, Lastname, Phonenumber, Email, Adress, City, Zipcode);
        }
    }
}
