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
                string sqlQuery = @"INSERT INTO Customers (Firstname, Lastname, Email, Phone, City, Zipcode) VALUES (@Firstname, @Lastname, @Email, @Phone, @City, @Zipcode)";

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Execute(sqlQuery, new { Id });
                }
            }
        }
    }
}
