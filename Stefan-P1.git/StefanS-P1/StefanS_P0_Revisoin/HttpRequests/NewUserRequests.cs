using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using StefanS_P0_Revisoin.Dtos;


namespace StefanS_P0_Revisoin.HttpRequests
{
    public class NewUserRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async void CreateUser(string username, string first, string last, string pass)
        {

            NewCustomer_Dtos U = new();
            U.Username = username;
            U.FirstName = first;
            U.LastName = last;
            U.Password = pass;

            string jsonString = JsonConvert.SerializeObject(U);

            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var url = "https://localhost:7298/api/NewUser";

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(result);
            
        }
    }
}
