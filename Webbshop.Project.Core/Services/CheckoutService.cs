using System;
using System.Collections.Generic;
using System.Text;

namespace Webbshop.Project.Core.Services
{
    public class CheckoutService
    {
        private readonly CheckoutRepository checkoutRepository;
        public CheckoutService(CheckoutRepository checkoutRepository)
        {
            this.checkoutRepository = checkoutRepository;
        }

        public List<ProductModel> GetCheckout()
        {
            return checkoutRepository.GetCheckout();
        }
    }
