using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace TestAPIConnection
{
    public class program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            //var repositories = await ProcessRepositories();
            var inventory = await GetCatalogItems();


            //foreach (var repo in repositories)
            //{
            //    Console.WriteLine(repo.Name);
            //    Console.WriteLine(repo.Description);
            //    Console.WriteLine(repo.GitHubHomeUrl);
            //   Console.WriteLine(repo.Homepage);
            //    Console.WriteLine(repo.Watchers);   
            //    Console.WriteLine(repo.LastPush);
            //    Console.WriteLine();
            //}

            foreach (var item in inventory)
            {
                Console.WriteLine($"Item: {item.ItemName} || Price: {item.Price} || Stock: {item.quantity}");
            }
                
        }
        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            return repositories;
            
        }

        private static async Task<List<Catalog>> GetCatalogItems()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://localhost:7298/api/Catalog");
            var inventory = await JsonSerializer.DeserializeAsync<List<Catalog>>(await streamTask);
            return inventory;
        }
    }



}