using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Webbshop.Project.Core.Models;

namespace Webbshop.Project.Core.Repositories.Implementations
{
    public class CartRepository
    {
        private string ConnectionString;

        public CartRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<CartViewModel> GetAll()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<CartViewModel>("select * from Cart").ToList();
            }
        }

        public void ToOrder(int Id)
        {
            {
                string sqlQuery = @"INSERT INTO Cart (Productid, Price, Amount) VALUES (@Productid, @Price, @Amount)";

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Execute(sqlQuery, new { Id });
                }
            }
        }
    }
}
