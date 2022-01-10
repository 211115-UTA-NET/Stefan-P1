using System.Net.Http.Headers;
using System.Text.Json;
using StefanS_P0_Revisoin.Dtos;

namespace StefanS_P0_Revisoin.HttpRequests
{
    public class LoginTasks
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Customer_Dtos>> GetUser(string username)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"https://localhost:7298/api/Customers/username?user={username}");
            //var streamTask = client.GetStreamAsync($"dockerstoreapi.eastus.azurecontainer.io/api/Customers/username?user={username}");
            //var streamTask = client.GetStreamAsync($"http://localhost:8080/api/Customers/username?user={username}");
            var customers = await JsonSerializer.DeserializeAsync<List<Customer_Dtos>>(await streamTask);
            return customers;
        }

        public static async Task<List<Password_Dtos>> GetPass(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"https://localhost:7298/api/Password/password?id={id}");
            //var streamTask = client.GetStreamAsync($"dockerstoreapi.eastus.azurecontainer.io/api/Password/password?id={id}");
            //var streamTask = client.GetStreamAsync($"http://localhost:8080/api/Password/password?id={id}");
            var password = await JsonSerializer.DeserializeAsync<List<Password_Dtos>>(await streamTask);
            return password;
        }
    }
}
