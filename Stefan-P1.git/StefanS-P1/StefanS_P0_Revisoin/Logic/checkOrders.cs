using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StefanS_P0_Revisoin.Dtos;
using StefanS_P0_Revisoin.HttpRequests;

namespace StefanS_P0_Revisoin.Logic
{
    public class checkOrders
    {
        public async Task GetOrders(string username)
        {
            var CustomerOrderHistory = await ExistingOrdersTask.GetOrders(username);

            foreach (var I in CustomerOrderHistory)
            {
                Console.WriteLine($"\tStoreLocation: {I.location} || Item: {I.item_name} || Quantity: {I.quantity} || Price: {I.price} || OrderDate: {I.date} ");
            }
        }

        public void history(string user)
        {
            string connect = File.ReadAllText("C:/Users/schwe/Revature/Stefan-P1.git/StefanS-P1/StefanS_P0_Revisoin/connection.txt");
            SqlConnection connection = new(@connect);

            string userData = $"SELECT * FROM ExistingCustomers WHERE Username = '{user}'";

            connection.Open();
            SqlCommand step1 = new(userData, connection);
            SqlDataReader reader = step1.ExecuteReader();

            reader.Read();
            int CusID = reader.GetInt32(1);
            reader.Close();

            string history = $"SELECT * FROM OrderedItems WHERE CustomerID = {CusID} ORDER BY _TimeDate DESC";
            SqlCommand step2 = new(history, connection);
            reader = step2.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\tStore: {reader.GetString(4)} | Item: {reader.GetString(5)} | Price: {reader.GetDecimal(7)} | Quantity: {reader.GetInt32(6)} | Date: {reader.GetDateTime(8)}");
            }
            reader.Close();
            connection.Close();

        }
    }
}
