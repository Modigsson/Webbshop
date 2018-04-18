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

        private string ConnectionString;

        public CheckoutRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }


    }
}
