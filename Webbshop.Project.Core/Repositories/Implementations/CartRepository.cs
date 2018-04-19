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

        public List<CartViewModel> GetAll(string Id)
        {

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<CartViewModel>("SELECT Shop.Product, Shop.Price, Shop.Picture, Shop.Shopid FROM Shop JOIN Cart ON Cart.Productid = Shop.Id WHERE Customerid = @Customerid", new { Customerid = Id }).ToList();
            }
        }

        public void ToCart(int Id)
        {
            {
                string sqlQuery = @"INSERT INTO Cart (Productid, Price, Customerid) VALUES (@Productid, @Price, @Customerid)";

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Execute(sqlQuery, new { Id });
                }
            }
        }
    }
}
