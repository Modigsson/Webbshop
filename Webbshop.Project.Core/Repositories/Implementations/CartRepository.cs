using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Webbshop.Project.Core.Repositories.Implementations
{
    public class CartRepository
    {
        private string ConnectionString;

        public CartRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
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
