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
                Console.WriteLine($"\tLocation: {I.location} | Item: {I.item_name} | Quantity: {I.quantity} | Price: {I.price} | OrderDate: {I.date} ");
            }
        }
    }
}
