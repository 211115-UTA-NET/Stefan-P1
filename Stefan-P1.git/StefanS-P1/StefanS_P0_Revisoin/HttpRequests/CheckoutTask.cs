using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using StefanS_P0_Revisoin.Dtos;


namespace StefanS_P0_Revisoin.HttpRequests
{
    public class CheckoutTask
    {
        public static async void AddToCart(List<ExistingOrders_Dtos> cart)
        {

            string jsonString = JsonConvert.SerializeObject(cart);

            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //var url = "dockerstoreapi.eastus.azurecontainer.io/api/Checkout";
            var url = "https://localhost:7298/api/Checkout";

            var response = await Program.Client().PostAsync(url, data);

        }
    }
}