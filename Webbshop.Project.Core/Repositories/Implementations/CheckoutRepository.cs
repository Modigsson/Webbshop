using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using Webbshop.Project.Core.Models;

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

        public void ToCheckout(string Firstname, string Lastname, int Phonenumber, string Email, string Adress, string City, int Zipcode)
        {
            string sql = @"INSERT INTO Customer 
                         (Firstname, Lastname, Phonenumber, Email, Adress, City, Zipcode) 
                         VALUES 
                         (@Firstname, @Lastname, @Phonenumber, @Email, @Adress, @City, @Zipcode)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname, Lastname, Phonenumber, Email, Adress, City, Zipcode });
            }
        }


    }
}
