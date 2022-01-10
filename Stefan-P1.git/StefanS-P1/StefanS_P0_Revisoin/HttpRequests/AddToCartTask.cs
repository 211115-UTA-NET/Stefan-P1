using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using StefanS_P0_Revisoin.Dtos;


namespace StefanS_P0_Revisoin.HttpRequests
{
    public class AddToCartTask
    {
        public static async void AddToCart(ShoppingCart_Dtos item)
        {

            string jsonString = JsonConvert.SerializeObject(item);

            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //var url = "http://dockerstoreapi.eastus.azurecontainer.io//api/ShoppingCart";
            var url = "https://localhost:7298/api/ShoppingCart";

            var response = await Program.Client().PostAsync(url, data);

        }
    }
}
