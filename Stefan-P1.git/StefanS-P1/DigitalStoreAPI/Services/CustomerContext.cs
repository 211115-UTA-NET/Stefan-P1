using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using DigitalStoreAPI.Controllers;

namespace DigitalStoreAPI.Models
{
    public class CustomerContext : DbContext
    {
        static List<Customer> customers { get; }
        static CustomerContext()
        {
            customers = new List<Customer>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }
        //get all
        public static List<Customer> GetAll(SqlConnection connection)
        {
            List<Customer> customers = new();

            string sql = "SELECT * FROM ExistingCustomers";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var catalog = new Customer()
                {
                    username = reader[0].ToString(),
                    id = (int)reader[1],
                };
                customers.Add(catalog);
            }
            reader.Close();
            connection.Close();
            return customers;
        }
        //get specific
        public static List<Customer> Get(string user, SqlConnection connection)
        {
            List<Customer> customers = new();

            string sql = $"SELECT * FROM ExistingCustomers WHERE Username = '{user}'";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var catalog = new Customer()
                {
                    username = reader[0].ToString(),
                    id = (int)reader[1],
                    firstname = reader[2].ToString(), 
                };
                customers.Add(catalog);
            }
            reader.Close();
            connection.Close();
            return customers;
        }
    }
}
