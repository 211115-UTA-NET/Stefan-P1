using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using StefanS_P0_Revisoin.Dtos;


namespace StefanS_P0_Revisoin.HttpRequests
{
    public class CheckoutTask
    {
        public static async void AddToCart(List<ShoppingCart_Dtos> cart)
        {

            string jsonString = JsonConvert.SerializeObject(cart);

            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var url = "https://localhost:7298/api/OrderedItems";

            var response = await Program.Client().PostAsync(url, data);

        }
    }
}