using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Models
{
    public class CheckoutService : DbContext
    {
        static List<ExistingOrders> order { get; }
        static CheckoutService()
        {
            order = new List<ExistingOrders>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //Post to DB
        public static void BuyStuff(List<ExistingOrders> order, SqlConnection connection)
        {

            foreach (var I in order)
            {
                string uploadData = $"INSERT OrderedItems (CustomerID,FirstName,OrderID,StoreLocation,ItemName,Quantity,Price,_TimeDate) VALUES ({I.customer_id},'{I.first_name}',{I.order_id},'{I.location}','{I.item_name}',{I.quantity},{I.price},GETDATE())";
                string updateCatalog = $"UPDATE _Catalog SET Quantity = Quantity - {I.quantity} WHERE ItemID = {I.item_id}";

                connection.Open();
                SqlCommand sql1 = new(uploadData, connection);
                SqlCommand sql2 = new(updateCatalog, connection);

                sql1.ExecuteNonQuery();
                sql2.ExecuteNonQuery();
                connection.Close();
            }
            
        }
    }
}
