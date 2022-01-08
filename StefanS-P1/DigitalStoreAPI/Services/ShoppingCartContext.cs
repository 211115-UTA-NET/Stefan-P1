using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;


namespace DigitalStoreAPI.Models
{
    public class ShoppingCartContext
    {
        //instructions for http data transfer
        public static void AddToCart(int id, int quantity, int orderID, SqlConnection connection)
        {
            string sql = $"INSERT INTO ShoppingCart (OrderID,ItemID,ItemName,Price,Quantity) VALUES (ItemID,ItemName,Price,{quantity}) FROM _Catalog WHERE ItemID = {id}";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            connection.Close();


        }
    }

   
}
