using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;

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

        public void ToOrder(string Firstname, string Lastname, int Phonenumber, string Email, string Adress, string City, int Zipcode)
        {

            {
                string sqlQuery = @"INSERT INTO Customer (Firstname, Lastname, Email, Phonenumber, City, Zipcode) VALUES (@Firstname, @Lastname, @Email, @Phonenumber, @City, @Zipcode)";

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Execute(sqlQuery, new { Firstname, Lastname, Phonenumber, Email, Adress, City, Zipcode });
                }
            }
        }
    }
}
