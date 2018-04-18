using System;
using System.Collections.Generic;
using System.Text;
using Webbshop.Project.Core.Repositories.Implementations;

namespace Webbshop.Project.Core.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public void ToCart(int Id)
        {
            this.cartRepository.ToOrder(Id);
        }
    }
}
