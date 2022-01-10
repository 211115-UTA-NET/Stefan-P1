using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using DigitalStoreAPI.Controllers;
using DigitalStoreAPI.Models;

namespace DigitalStoreAPI.Services
{
    public class ExistingOrderService : DbContext
    {
        static List<ExistingOrders> customerHistory { get; }
        static ExistingOrderService()
        {
            customerHistory = new List<ExistingOrders>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }
        public static List<ExistingOrders> Get(string user, SqlConnection connection)
        {
            List<ExistingOrders> customerHistory = new();

            string sql1 = $"SELECT * FROM ExistingCustomers WHERE Username = '{user}'";

            connection.Open();
            SqlCommand step1 = new(sql1, connection);
            SqlDataReader reader = step1.ExecuteReader();

            reader.Read();
            int CusID = reader.GetInt32(1);
            reader.Close();

            string sql2 = $"SELECT * FROM OrderedItems WHERE CustomerID = {CusID} ORDER BY _TimeDate DESC";
            SqlCommand step2 = new(sql2, connection);
            reader = step2.ExecuteReader();
            while (reader.Read())
            {
                var orderHistory = new ExistingOrders()
                {
                    location = reader[4].ToString(),
                    item_name = reader[5].ToString(),
                    price = (decimal)reader[7],
                    quantity = (int)reader[6],
                    date = reader.GetDateTime(8),
                };
                customerHistory.Add(orderHistory);
            }
            reader.Close();
            connection.Close();
            return customerHistory;

        }
    }
}
