using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Models
{
    public class PasswordContext : DbContext
    {
        static List<Password> pass { get; }
        static PasswordContext()
        {
            pass = new List<Password>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //get specific
        public static List<Password> Get(int id, SqlConnection connection)
        {
            string sql = $"SELECT * FROM CustomerPasswords WHERE CustomerID = {id}";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var catalog = new Password()
                {
                    id = (int)reader[0],
                    password = reader[1].ToString()
                };
                pass.Add(catalog);
            }
            reader.Close();
            connection.Close();
            return pass;
        }
    }
}
