using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using StefanS_P0_Revisoin.Dtos;

namespace StefanS_P0_Revisoin.HttpRequests
{
    public class ExistingOrdersTask
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<ExistingOrders_Dtos>> GetOrders(string username)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"https://localhost:7298/api/Orders?user={username}");
            var orders = await JsonSerializer.DeserializeAsync<List<ExistingOrders_Dtos>>(await streamTask);
            return orders;
        }

    }
}
