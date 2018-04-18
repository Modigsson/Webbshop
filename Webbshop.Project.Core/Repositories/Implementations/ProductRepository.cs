using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;
using Webbshop.Project.Core.Models;

namespace Webbshop.Project.Core.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString;

        public ProductRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public List<ProductViewModel> GetAll()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<ProductViewModel>("select * from Shop").ToList();
            }
        }

        List<ProductViewModel> IProductRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
