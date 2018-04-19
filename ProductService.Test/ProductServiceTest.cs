using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit;
using FakeItEasy;

namespace ProductService.Test
{
    public class ProductServiceTest
    {
        private ProductService product;
        private IProductRepository productRepository;

        public void GetAllShouldReturnProducts()
        {
            var product = new List<ProductViewModel>
            {
                new ProductViewModel { id = 666 }
            };

            A.CallTo(() => this.productRepository.GetAll()).returns(Product);
        }
    }
}
