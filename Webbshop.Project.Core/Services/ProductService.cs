using System;
using System.Collections.Generic;
using System.Text;
using Webbshop.Project.Core.Models;
using Webbshop.Project.Core.Repositories;

namespace Webbshop.Project.Core.Services
{
    public class ProductService
    {
        private IProductRepository ProductRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public List<ProductViewModel> GetAll()
        {
            return this.ProductRepository.GetAll();
        }

        public void InsertIntoCart(ProductModel model)
        {
            productRepository.InsertIntoCart(model);
        }
    }
}
