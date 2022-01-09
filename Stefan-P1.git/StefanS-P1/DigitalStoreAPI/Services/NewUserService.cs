using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Models
{
    public class NewUserService : DbContext
    {
        static List<NewUser> newUser { get; }
        static NewUserService()
        {
            newUser = new List<NewUser>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //Post to DB
        public static void CreateUser(NewUser newUser, SqlConnection connection)
        {
            string sql1 = $"INSERT INTO CustomerPasswords (Password) VALUES ('{newUser.password}')";
            string sql2 = $"INSERT INTO ExistingCustomers SELECT '{newUser.username}',MAX(CustomerID),'{newUser.firstname}','{newUser.lastname}' FROM CustomerPasswords";

            connection.Open();
            using SqlCommand command1 = new(sql1, connection);
            using SqlCommand command2 = new(sql2, connection);

            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();

            connection.Close();
        }
    }
}
