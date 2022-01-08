using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace StefanS_P0_Revisoin
{
    public class StoreService
    {
        private readonly HttpClient _httpClient = new();

        public StoreService(Uri serverUri)
        {
            _httpClient.BaseAddress = serverUri;
        }

        public void GetUserInfo(string name)
        {
            Dictionary<string, string> query = new() { ["Username"] = name };

            string requestUri = QueryHelpers.AddQueryString("/api/Customer", query);

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);

            HttpResponseMessage response;
            try
            {
                response = _httpClient.Send(request);
            }
            catch (HttpRequestException e)
            {
               Console.WriteLine("network error: ", e);
            }

            var name = response.Content.ReadFromJson<name>;
        }
    }
}
