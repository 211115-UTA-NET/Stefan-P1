using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;


namespace DigitalStoreAPI.Models
{
    public class ShoppingCartContext
    {
        //instructions for http data transfer
        public static void AddToCart(ShoppingCart cart, SqlConnection connection)
        {
            string sql = $"INSERT INTO ShoppingCart (OrderID,ItemID,ItemName,Price,Quantity,Location) VALUES ({cart.OrderID},{cart.ItemID},'{cart.ItemName}',{cart.Price},{cart.Quantity},'{cart.Location}')";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }

   
}
