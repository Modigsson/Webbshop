using NUnit.Framework;
using FakeItEasy;
using Webbshop.Project.Core.Services;
using Webbshop.Project.Core.Repositories;
using System.Collections.Generic;
using Webbshop.Project.Core.Models;
using System.Linq;

namespace Webbshop.cs.Project.Core.UnitTests.Services
{
    public class ProductServiceTests
    {
        private ProductService productService;
        private IProductRepository productRepository;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake <IProductRepository>();
            this.productService = new ProductService(this.productRepository);
        }

        [Test]
        public void GetAll_ReturnsExpectedService()
        {
            // Arrange
            var product = new ProductViewModel { Id = 1337 };
            var products = new List<ProductViewModel>
            {
                product
            };

            A.CallTo(() => this.productRepository.GetAll()).Returns(products);

            // Act
            var result = this.productService.GetAll();

            // Assert
            Assert.That(result, Is.EqualTo(products));
            Assert.That(result.Count, Is.EqualTo(1));

            var returnedProduct = result.Single();
            Assert.That(product, Is.EqualTo(returnedProduct));
            Assert.That(returnedProduct.Id, Is.EqualTo(1337));
        }
    }
}
