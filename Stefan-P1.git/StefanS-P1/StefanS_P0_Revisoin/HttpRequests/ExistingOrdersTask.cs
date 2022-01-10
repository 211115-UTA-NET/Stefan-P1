using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using StefanS_P0_Revisoin.Dtos;
using StefanS_P0_Revisoin;

namespace StefanS_P0_Revisoin.HttpRequests
{
    public class ExistingOrdersTask
    {
        public static async Task<List<ExistingOrders_Dtos>> GetOrders(string username)
        {

            HttpClient client = new HttpClient();

            Program.Client().DefaultRequestHeaders.Accept.Clear();
            Program.Client().DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


            var streamTask = client.GetStreamAsync($"https://localhost:7298/api/Orders?user={username}");
            var orders = await JsonSerializer.DeserializeAsync<List<ExistingOrders_Dtos>>(await streamTask);
            return orders;
        }

    }
}
