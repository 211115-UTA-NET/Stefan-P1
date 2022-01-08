using System.Net.Http;
using System.Net.Http.Headers;

namespace tester
{
    public class program
    {
        public static void Main(string[] args)
        {
            Uri server = new("https://localhost:7146");

        }
    }


    public class Tester
    {
        private readonly HttpClient _httpClient = new();
        public Tester(Uri serverUri)
        {
            _httpClient.BaseAddress = serverUri;
        }

        public async void GetCatalog()
        {
            string requestUri = "/api/catalog";

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);



            HttpResponseMessage response = await _httpClient.SendAsync(request);


        }
    }
}